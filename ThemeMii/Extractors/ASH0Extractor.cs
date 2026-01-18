using System;
using System.Buffers.Binary;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace ThemeMii.Extractors;

//All of the logic for this was taken from https://github.com/NinjaCheetah/ASH0-tools
//Converted to the best of my abilities to C#
public class ASH0Extractor
{
    private static uint SystemBits => 9;
    private static uint DistanceBits => 11;
    private static uint SystemMax => (uint)(1 << (int)SystemBits);
    private static uint DistanceMax => (uint)(1 << (int)DistanceBits);
    
    public static async Task DeASH(string fileName)
    {
        var byteArray = await File.ReadAllBytesAsync(fileName);
        
        if (BitConverter.ToString(byteArray, 0, 4) != "ASH0")
            throw new Exception("File is not ASH0!");
        
        var uncompressedSize = BinaryPrimitives.ReadUInt32BigEndian(
            byteArray.AsSpan(4, 4)) & 0x00FFFFFF;
        var outputSize = uncompressedSize;
        var outputBuffer = new byte[uncompressedSize];
        var outputPosition = 0;

        
        var reader1 = new BitReader(byteArray, 
            (uint)byteArray.Length, 
            BinaryPrimitives.ReadUInt32BigEndian(byteArray.AsSpan(8, 4)));
        var reader2 = new BitReader(
            byteArray,
            (uint)byteArray.Length,
            0xC);
        
        
        //Sets up SymRoot(?)
        var systemLeftTree = new uint[2 * SystemMax - 1];
        var systemRightTree = new uint[2 * SystemMax - 1];
        var distanceLeftTree = new uint[2 * DistanceMax - 1];
        var distanceRightTree = new uint[2 * DistanceMax - 1];
        
        
        var systemRoot = reader1.ReadTree(SystemBits,systemLeftTree, systemRightTree);
        var distanceRoot = reader2.ReadTree(DistanceBits,distanceLeftTree,distanceRightTree);

        do
        {
            var sym = systemRoot;
            while (sym >= SystemMax)
                sym = reader2.ReadBit() == 0 
                    ? systemLeftTree[sym] 
                    : systemRightTree[sym];

            //I assume we can fill this since it will be under 9 bits, right?
            if (sym < 0x100)
            {
                outputBuffer[outputPosition++] = (byte)sym;
                uncompressedSize -= 1;
            }
            else
            {
                var distSystem = distanceRoot;
                while (distSystem >= DistanceMax)
                    sym = reader2.ReadBit() == 0 
                        ? systemLeftTree[sym] 
                        : systemRightTree[sym];

                var copyLength = (sym - 0x100) + 3;
                var sourcePosition = outputPosition - distSystem - 1;

                uncompressedSize -= copyLength;
                while (copyLength != 0)
                {
                    outputBuffer[outputPosition++] = byteArray[sourcePosition++];
                    copyLength -= 1;
                }
            }
        } while (uncompressedSize > 0);

        //This assumes we just write as an arc, so we will do that.
        //Perhaps it is possible to be non u8?
        await using var fs = new FileStream($"{fileName}_arc", FileMode.Open);
        await fs.WriteAsync(outputBuffer);
    }

    public static async Task DeASH(iniEntry mymC, string appOut)
    {
        throw new NotImplementedException();
    }
}

public struct BitReader
{
    public byte[] ByteArray { get; set; }
    public uint Size { get; set; }
    public uint SourcePos { get; set; }
    public uint Word { get; set; }
    public uint BitCapacity { get; set; }
    
    public uint TreeRight => 0x80000000;
    public uint TreeLeft => 0x40000000;

    public uint TreeValMask => 0x3FFFFFFF;


    public BitReader(byte[] byteArray, uint size, uint startPos)
    {
        ByteArray = byteArray;
        Size = size;
        SourcePos = startPos;
        FeedWord();
    }

    public void FeedWord()
    {
        Word = BinaryPrimitives.ReadUInt32BigEndian(ByteArray.AsSpan((int)SourcePos, 4));
        BitCapacity = 0;
        SourcePos += 4;
    }

    //This looks to basically be read the bit and shift.
    public uint ReadBit()
    {
        var bit = Word >> 31;
        if(BitCapacity == 31)
            FeedWord();
        else
        {
            BitCapacity++;
            Word <<= 1;
        }

        return bit;
    }

    public uint ReadBits(uint numberOfBits)
    {
        uint bitsToReturn = 0;
        var next = BitCapacity + numberOfBits;
        if (next <= 32)
        {
            bitsToReturn = (Word >> (int)(32 - numberOfBits));
            if (next != 32)
            {
                Word <<= (int)numberOfBits;
                BitCapacity += numberOfBits;
            }
            else
            {
                FeedWord();
            }
        }
        else
        {
            bitsToReturn = Word >> (int)(32 - numberOfBits);
            FeedWord();
            bitsToReturn |= Word >> (int)(64 - next);
            Word <<= (int)(next - 32);
            BitCapacity = next - 32;
        }

        return bitsToReturn;
    }
    public uint ReadTree(uint width, uint[] leftTree, uint[] rightTree)
    {
        uint[] work = new uint[2 * (1 << (int)width)];
        uint r23 = (uint)(1 << (int)width);
        uint numberOfNodes = 0;
        int workPosition = 0;
        uint symRoot = ReadBits(width);

        
        do
        {
            if (ReadBit() != 0)
            {
                work[workPosition++] = r23 | TreeRight;
                work[workPosition++] = r23 | TreeLeft;
                numberOfNodes += 2;
                r23++;
            }
            else
            {
                symRoot = ReadBits(width);
                do
                {
                    var nodeVal = work[workPosition--];
                    var idx = nodeVal & TreeValMask;
                    numberOfNodes -= 1;
                    if ((nodeVal & TreeRight) != 0)
                    {
                        rightTree[idx] = symRoot;
                        symRoot = idx;
                    }
                    else
                    {
                        leftTree[idx] = symRoot;
                    }
                } while (numberOfNodes > 0);
            }
            
        } while (numberOfNodes > 0);

        return symRoot;
    }
    
}