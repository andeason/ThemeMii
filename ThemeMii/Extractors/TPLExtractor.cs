using System;
using System.Buffers.Binary;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ThemeMii.Extractors;

//Most of the info I have taken from https://wiki.tockdom.com/wiki/TPL_(File_Format)
public class TPLExtractor
{
    public async static Task ExtractTPLFile(string fileName, string outputPath)
    {
        var byteArray = File.ReadAllBytes(fileName);

        if (byteArray[0] != 0x00 || byteArray[1] != 0x20 || byteArray[2] != 0xAF || byteArray[3] != 0x30)
            throw new Exception("File is not a TPL!");
        
        var numberOfImages = BinaryPrimitives.ReadUInt32BigEndian(byteArray.AsSpan(4,4));
        var calculatedTableSize = numberOfImages * 8;
        var imageTableOffset =  BinaryPrimitives.ReadUInt32BigEndian(byteArray.AsSpan(8,4));
        
        var currentImageOffset = imageTableOffset;
        var Images = new List<TplImage>();
        
        
        while (currentImageOffset < imageTableOffset + calculatedTableSize)
        {
            Images.Add(new TplImage((int)currentImageOffset, byteArray));
            currentImageOffset += 8;
        }

        foreach (var tplImage in Images)
            tplImage.DecodeImage(byteArray);
    }

    private class ImageOffsetElement
    {
        public uint ImageOffset { get; set; }
        
        //This value can be null (I assume this is.... 0?)
        public uint PaletteOffset { get; set; }
    }

    private struct PaletteHeader
    {
        public ushort EntryCount { get; set; }
        
        public byte Unpacked { get; set; }
        
        public uint PaletteFormat { get; set; }
        
        public uint PaletteDataAddress { get; set; }
    }

    public struct ImageHeader
    {
        public ushort Height { get; set; }
        
        public ushort Width { get; set; }
        
        public ImageFormats Format { get; set; }
        
        public ImageFormatTranscoding TranscodedFormat { get; set; }
        
        public uint ImageDataAddress { get; set; }
        
        public uint WrapS { get; set; }
        
        public uint WrapT { get; set; }
        
        public uint MinFilter { get; set; }
        
        public uint MagFilter { get; set; }
        
        public float LODBias { get; set; }
        
        public byte EdgeLODEnable  { get; set; }
        
        public byte MinLOD { get; set; }
        
        public byte MaxLOD { get; set; }

        public byte UnPacked { get; set; }

        public enum ImageFormats
        {
            I4 = 0x0,
            I8 = 0x1,
            IA4 = 0x2,
            IA8 = 0x3,
            RGB565 = 0x4,
            RGB5A3 = 0x5,
            //Also known as RGBA8
            RGBA32 = 0x6,
            //Also known as CI4
            C4 = 0x8,
            //Also known as CI8
            C8 = 0x9,
            //Also known as CI14x2
            C14X2 = 0xA,
            CMPR = 0x0E
        }
    }

    private class TplImage
    {
        public PaletteHeader PaletteHeader { get; set; }

        public ImageOffsetElement OffsetElement { get; set; }
        
        public ImageHeader ImageHeader { get; set; }

        public TplImage(int originalImageOffsetPosition, byte[] byteArray)
        {
            OffsetElement = new ImageOffsetElement
            {
                ImageOffset = BinaryPrimitives
                    .ReadUInt32BigEndian(byteArray.AsSpan(originalImageOffsetPosition, 4)),
                PaletteOffset = BinaryPrimitives
                    .ReadUInt32BigEndian(byteArray.AsSpan(originalImageOffsetPosition + 4, 4))
            };

            if (OffsetElement.ImageOffset != 0)
            {
                PaletteHeader = new PaletteHeader
                {
                    EntryCount = BinaryPrimitives
                        .ReadUInt16BigEndian(byteArray.AsSpan((int)OffsetElement.PaletteOffset, 2)),
                    Unpacked = byteArray[(int)OffsetElement.PaletteOffset + 2],
                    PaletteFormat = BinaryPrimitives
                        .ReadUInt32BigEndian(byteArray.AsSpan((int)OffsetElement.PaletteOffset + 4, 4)),
                    PaletteDataAddress = BinaryPrimitives
                        .ReadUInt32BigEndian(byteArray.AsSpan((int)OffsetElement.PaletteOffset + 8, 4))
                };
            }
            
            ImageHeader = new ImageHeader
            {
                Height =
                    BinaryPrimitives.
                        ReadUInt16BigEndian(byteArray.AsSpan((int)OffsetElement.ImageOffset, 2)),
                Width = BinaryPrimitives
                    .ReadUInt16BigEndian(byteArray.AsSpan((int)OffsetElement.ImageOffset + 2, 2)),
                
                Format = (ImageHeader.ImageFormats)BinaryPrimitives
                    .ReadUInt32BigEndian(byteArray.AsSpan((int)OffsetElement.ImageOffset + 4, 4)),
                TranscodedFormat = new ImageFormatTranscoding((ImageHeader.ImageFormats)BinaryPrimitives
                    .ReadUInt32BigEndian(byteArray.AsSpan((int)OffsetElement.ImageOffset + 4, 4))),
                
                ImageDataAddress = BinaryPrimitives
                    .ReadUInt32BigEndian(byteArray.AsSpan((int)OffsetElement.ImageOffset + 8, 4)),
                WrapS = BinaryPrimitives
                    .ReadUInt32BigEndian(byteArray.AsSpan((int)OffsetElement.ImageOffset + 12, 4)),
                WrapT = BinaryPrimitives
                    .ReadUInt32BigEndian(byteArray.AsSpan((int)OffsetElement.ImageOffset + 16, 4)),
                LODBias = BinaryPrimitives
                    .ReadSingleBigEndian(byteArray.AsSpan((int)OffsetElement.ImageOffset + 20, 4)),
                EdgeLODEnable = byteArray[(int)OffsetElement.ImageOffset + 4],
                MinLOD = byteArray[(int)OffsetElement.ImageOffset + 5],
                MaxLOD = byteArray[(int)OffsetElement.ImageOffset + 6],
                UnPacked = byteArray[(int)OffsetElement.ImageOffset + 7]
            };
        }

        /*
         * https://wiki.tockdom.com/wiki/Image_Formats#RGBA32_(RGBA8)
         * Pretty critical to this, I think, is that we decode in terms of blocks for tpl files.
         * We will essentially need to figure out the row and columns for this and jump in the array for those positions
         * Rather than reading 1 by 1
         */
        public void DecodeImage(byte[] byteArray)
        {
            var currentByteOffset = ImageHeader.ImageDataAddress;
            if (ImageHeader.Width % ImageHeader.TranscodedFormat.BlockWidth != 0)
                throw new Exception("Width is not divisible by the block width.  Verify this file is a correct tpl.");
            if (ImageHeader.Height % ImageHeader.TranscodedFormat.BlockHeight != 0)
                throw new Exception("Height is not divisible by the block height.  Verify this file is a correct tpl.");
            
            
            var totalBlockRows = ImageHeader.Width / ImageHeader.TranscodedFormat.BlockWidth;
            var totalBlockColumns = ImageHeader.Height / ImageHeader.TranscodedFormat.BlockHeight;

            for (var currentBlockRow = 0; currentBlockRow < totalBlockRows; currentBlockRow++)
            {
                for (var currentBlockColumn = 0; currentBlockColumn < totalBlockColumns; currentBlockColumn++)
                {
                    Console.WriteLine($"At row {currentBlockRow} column {currentBlockColumn}");
                }
            }
        }


        private void DecodeBlock()
        {
            
        }
    }

    public class ImageFormatTranscoding
    {
        public int BitsPerPixel { get; set; }
        
        public int BlockWidth { get; set; }
        
        public int BlockHeight { get; set; }

        private void SetBitsPerPixel(ImageHeader.ImageFormats imageFormat)
        {
            int valueToGet;
            switch (imageFormat)
            {
                case ImageHeader.ImageFormats.I4:
                case ImageHeader.ImageFormats.C4:
                case ImageHeader.ImageFormats.CMPR:
                    valueToGet = 4;
                    break;
                case ImageHeader.ImageFormats.I8:
                case ImageHeader.ImageFormats.C8:
                case ImageHeader.ImageFormats.IA4:
                    valueToGet = 8;
                    break;
                case ImageHeader.ImageFormats.IA8:
                case ImageHeader.ImageFormats.RGB565:
                case ImageHeader.ImageFormats.RGB5A3:
                case ImageHeader.ImageFormats.C14X2:
                    valueToGet = 16;
                    break;
                case ImageHeader.ImageFormats.RGBA32:
                    valueToGet = 32;
                    break;
                default:
                    throw new NotImplementedException();
                    
            }
            
            BitsPerPixel = valueToGet;
        }

        private void SetBlockWidth(ImageHeader.ImageFormats imageFormat)
        {
            int valueToGet;
            switch (imageFormat)
            {
                case ImageHeader.ImageFormats.IA8:
                case ImageHeader.ImageFormats.RGB565:
                case ImageHeader.ImageFormats.RGB5A3:
                case ImageHeader.ImageFormats.RGBA32:
                case ImageHeader.ImageFormats.C14X2:
                    valueToGet = 4;
                    break;
                case ImageHeader.ImageFormats.I4:
                case ImageHeader.ImageFormats.I8:
                case ImageHeader.ImageFormats.IA4:
                case ImageHeader.ImageFormats.C4:
                case ImageHeader.ImageFormats.C8:
                case ImageHeader.ImageFormats.CMPR:
                    valueToGet = 8;
                    break;
                default:
                    throw new NotImplementedException();
                    
            }
            
            BlockWidth = valueToGet;
        }

        private void SetBlockHeight(ImageHeader.ImageFormats imageFormat)
        {
            int valueToGet;
            switch (imageFormat)
            {
                case ImageHeader.ImageFormats.IA8:
                case ImageHeader.ImageFormats.RGB565:
                case ImageHeader.ImageFormats.RGB5A3:
                case ImageHeader.ImageFormats.RGBA32:
                case ImageHeader.ImageFormats.C14X2:
                case ImageHeader.ImageFormats.I8:
                case ImageHeader.ImageFormats.IA4:
                case ImageHeader.ImageFormats.C8:
                    valueToGet = 4;
                    break;
                case ImageHeader.ImageFormats.I4:
                case ImageHeader.ImageFormats.C4:
                case ImageHeader.ImageFormats.CMPR:
                    valueToGet = 8;
                    break;
                default:
                    throw new NotImplementedException();
                    
            }
            
            BlockHeight = valueToGet;
        }

        public ImageFormatTranscoding(ImageHeader.ImageFormats imageFormat)
        {
            SetBitsPerPixel(imageFormat);
            SetBlockWidth(imageFormat);
            SetBlockHeight(imageFormat);
        }
    }
}
