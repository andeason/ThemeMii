using System;
using System.Buffers.Binary;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using ThemeMii.Extractors.FormatEncoding;

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
        
        public IEncodedFormat EncodedFormat { get; set; }
        
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

            var imageFormat = (ImageFormats)BinaryPrimitives
                .ReadUInt32BigEndian(byteArray.AsSpan((int)OffsetElement.ImageOffset + 4, 4));
            ImageHeader = new ImageHeader
            {
                Height =
                    BinaryPrimitives.
                        ReadUInt16BigEndian(byteArray.AsSpan((int)OffsetElement.ImageOffset, 2)),
                Width = BinaryPrimitives
                    .ReadUInt16BigEndian(byteArray.AsSpan((int)OffsetElement.ImageOffset + 2, 2)),
                Format = imageFormat,
                EncodedFormat = FormatEncodingCreator.CreateFormatEncoder(imageFormat),
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

            var maximumImageSize = ImageHeader.Width * ImageHeader.Height * (ImageHeader.EncodedFormat.BitsPerPixel / 8);
            //The output in this case will be 32 bits.
            var imageOutputArray = new byte[ImageHeader.Width * ImageHeader.Height * 32];
            int currentImageOutputPosition = 0;
            
            
            if (ImageHeader.Width % ImageHeader.EncodedFormat.BlockWidth != 0)
                throw new Exception("Width is not divisible by the block width.  Verify this file is a correct tpl.");
            if (ImageHeader.Height % ImageHeader.EncodedFormat.BlockHeight != 0)
                throw new Exception("Height is not divisible by the block height.  Verify this file is a correct tpl.");
            
            
            var currentOffsetPosition = ImageHeader.ImageDataAddress;
            while (currentOffsetPosition < maximumImageSize)
            {
                ImageHeader.EncodedFormat.ConvertAndStoreToByteArray(
                    byteArray,
                    imageOutputArray,
                    (int)(currentOffsetPosition - ImageHeader.ImageDataAddress),
                    currentImageOutputPosition);
                
                currentOffsetPosition += (uint)Math.Max(ImageHeader.EncodedFormat.BitsPerPixel / 8, 1);
                currentImageOutputPosition += 4;
            }
            
            Console.WriteLine("Finished writing output array");
        }
        
    }
}
