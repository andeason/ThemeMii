using System;
using System.Buffers.Binary;
using System.IO;
using System.Threading.Tasks;
using Wii;

namespace ThemeMii.Extractors;

public static class U8Extractor
{
    /// <summary>
    /// Unpacks the given U8 archive
    /// If the archive is Lz77 compressed, it will be decompressed first!
    /// </summary>
    /// <param name="u8archive"></param>
    /// <param name="unpackpath"></param>
    public static async Task UnpackU8(string u8archive, string unpackpath)
    {
        byte[] u8 = await File.ReadAllBytesAsync(u8archive);
        UnpackU8(u8, unpackpath);
    }
    
    
    /// <summary>
    /// Unpacks the given U8 archive
    /// If the archive is Lz77 compressed, it will be decompressed first!
    /// </summary>
    /// <param name="u8archive"></param>
    /// <param name="unpackpath"></param>
    public static async void UnpackU8(byte[] u8archive, string unpackpath)
    {
        int lz77Offset = Lz77.GetLz77Offset(u8archive);
        if (lz77Offset != -1) 
            u8archive = Lz77.Decompress(u8archive, lz77Offset);

        if (!Directory.Exists(unpackpath)) 
            Directory.CreateDirectory(unpackpath);

        var u8Offset = -1;
        //TODO:  Is this something that actually happens on U8 files where there is a buffer to the magic string?
        var maxOffsetBufferLength = 2500;
        if (u8archive.Length < maxOffsetBufferLength) 
            maxOffsetBufferLength = u8archive.Length - 4;

        for (var i = 0; i < maxOffsetBufferLength; i++)
        {
            if (u8archive[i] == 0x55 && u8archive[i + 1] == 0xAA && u8archive[i + 2] == 0x38 && u8archive[i + 3] == 0x2D)
            {
                u8Offset = i;
                break;
            }
        }
        
        if (u8Offset == -1) 
            throw new Exception("File is not a valid U8 Archive!");
        
        //BitConverter looks to auto map assuming little endian.
        //U8 appears to be big endian, so we cannot do this.
        var nodeCount = BinaryPrimitives.ReadUInt32BigEndian(u8archive.AsSpan(0x28));
        var nodeOffset = 0x20;

        var nodes = new U8Node[nodeCount];
        
        for (var i = 0; i < nodeCount; i++)
        {
            nodes[i] = new U8Node
            {
                Type = BinaryPrimitives.ReadUInt16BigEndian(
                    u8archive.AsSpan(u8Offset + nodeOffset)), 
                NameOffset = BinaryPrimitives.ReadUInt16BigEndian(
                    u8archive.AsSpan(u8Offset + nodeOffset + 2)),
                DataOffset = BinaryPrimitives.ReadUInt32BigEndian(
                    u8archive.AsSpan(u8Offset + nodeOffset + 4)),
                Size = BinaryPrimitives.ReadUInt32BigEndian(
                    u8archive.AsSpan(u8Offset + nodeOffset + 8))
            };
            nodeOffset += 12;
        }

        var stringTablePos = u8Offset + nodeOffset;

        for (var i = 0; i < nodeCount; i++)
        {
            var currentOffset = nodes[i].NameOffset;
            var thisName = string.Empty;

            while (u8archive[stringTablePos + currentOffset] != 0x00)
            {
                thisName += Convert.ToChar(u8archive[stringTablePos + currentOffset]);
                currentOffset++;
            }
            
            nodes[i].Name = thisName;
        }

        var dirs = new string[nodeCount];
        dirs[0] = unpackpath;
        var dirCount = new int[nodeCount];
        var dirIndex = 0;

        try
        {
            //We can skip the root node, so start at 1
            for (var i = 1; i < nodeCount; i++)
            {
                switch ((U8Node.U8NodeTypes)nodes[i].Type)
                {
                    case U8Node.U8NodeTypes.Directory:
                        Directory.CreateDirectory(
                            Path.Combine(
                                dirs[dirIndex],
                                nodes[i].Name)
                        );
                        dirs[dirIndex + 1] = Path.Combine(dirs[dirIndex],nodes[i].Name);
                        dirIndex++;
                        dirCount[dirIndex] = (int)nodes[i].Size;
                        break;

                    default:
                        var filepos = (int)(u8Offset + nodes[i].DataOffset);
                        var filesize = nodes[i].Size;

                        using (var fs = new FileStream(Path.Combine(dirs[dirIndex], nodes[i].Name), FileMode.Create))
                            await fs.WriteAsync(u8archive, filepos, (int)filesize);
                        break;
                }

                while (dirIndex > 0 && dirCount[dirIndex] == i + 1)
                {
                    dirIndex--;
                }
            }
        }
        catch
        {
            
        }
    }

    //Taken from https://www.wiibrew.org/wiki/U8_archive
    public struct U8Node
    {
        public ushort Type { get; set; }
        public ushort NameOffset { get; set; }
        public uint DataOffset { get; set; }
        public uint Size { get; set; }
        
        //Derived, technically the u8node doesn't have, but I will force for now...
        public string Name { get; set; }

        public enum U8NodeTypes
        {
            Directory = 0x100
        }
    }
}