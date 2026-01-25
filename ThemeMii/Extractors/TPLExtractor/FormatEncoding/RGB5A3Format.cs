using System;
using System.Buffers.Binary;
using SixLabors.ImageSharp.PixelFormats;

namespace ThemeMii.Extractors.FormatEncoding;

public class RGB5A3Format : IEncodedFormat
{
    public int BitsPerPixel => 16;
    public int BlockWidth => 4;
    public int BlockHeight => 4;

    public void ConvertAndStoreToByteArray(byte[] inputArray, byte[] outputArray, int currentInputPosition,
        int currentOutputPosition)
    {
        var rawInput = BinaryPrimitives
            .ReadUInt16BigEndian(inputArray.AsSpan(currentInputPosition, 2));

        //Fuck it, this probably isn't the best, but fairly certain it will work...
        var isUsingAlphaChannel = (rawInput & 0x8000) == 0;
        var alphaValue = (byte)(isUsingAlphaChannel ? (rawInput & 0x7000) << 5 : 0);
        var redValue = (byte)(isUsingAlphaChannel ? (rawInput >> 8) & 0x0F << 4 : (rawInput >> 10 & 0x1F) << 3);
        var greenValue = (byte)(isUsingAlphaChannel ? (rawInput >> 4) & 0x0F << 4 : (rawInput >> 5 & 0x1F) << 3);
        var blueValue = (byte)(isUsingAlphaChannel ? rawInput & 0x0F << 4 : (rawInput & 0x1F) << 3);
        
        
        outputArray[currentOutputPosition] = alphaValue;
        outputArray[currentOutputPosition + 1] = redValue;
        outputArray[currentOutputPosition + 2] = greenValue;
        outputArray[currentOutputPosition + 3] = blueValue;
    }

    public void ConvertAndStoreToByteArray(byte[] inputArray, Rgba32[] outputArray, int currentInputPosition,
        int currentOutputPosition)
    {
        
        var rawInput = BinaryPrimitives
            .ReadUInt16BigEndian(inputArray.AsSpan(currentInputPosition, 2));

        //Fuck it, this probably isn't the best, but fairly certain it will work...
        var isUsingAlphaChannel = (rawInput & 0x8000) == 0;
        var alphaValue = (byte)(isUsingAlphaChannel ? (rawInput & 0x7000) << 5 : 0);
        var redValue = (byte)(isUsingAlphaChannel ? (rawInput >> 8) & 0x0F << 4 : (rawInput >> 10 & 0x1F) << 3);
        var greenValue = (byte)(isUsingAlphaChannel ? (rawInput >> 4) & 0x0F << 4 : (rawInput >> 5 & 0x1F) << 3);
        var blueValue = (byte)(isUsingAlphaChannel ? rawInput & 0x0F << 4 : (rawInput & 0x1F) << 3);
        
        
        outputArray[currentOutputPosition] = new Rgba32(255, 0, 0, 1);
    }
}