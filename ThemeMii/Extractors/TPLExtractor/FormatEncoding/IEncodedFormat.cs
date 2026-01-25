using SixLabors.ImageSharp.PixelFormats;

namespace ThemeMii.Extractors.FormatEncoding;

public interface IEncodedFormat
{
    public int BitsPerPixel { get; }

    public int BlockWidth { get; }

    public int BlockHeight { get; }

    public void ConvertAndStoreToByteArray(
        byte[] inputArray, byte[] outputArray,
        int currentInputPosition, int currentOutputPosition);
    
    public void ConvertAndStoreToByteArray(
        byte[] inputArray, Rgba32[] outputArray,
        int currentInputPosition, int currentOutputPosition);
}

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