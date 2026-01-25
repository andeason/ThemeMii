using SixLabors.ImageSharp.PixelFormats;

namespace ThemeMii.Extractors.FormatEncoding;

public class IA8Format : IEncodedFormat
{
    public int BitsPerPixel => 16;
    public int BlockWidth => 4;
    public int BlockHeight => 4;

    public void ConvertAndStoreToByteArray(byte[] inputArray, byte[] outputArray, int currentInputPosition,
        int currentOutputPosition)
    {
        throw new System.NotImplementedException();
    }

    public void ConvertAndStoreToByteArray(byte[] inputArray, Rgba32[] outputArray, int currentInputPosition,
        int currentOutputPosition)
    {
        throw new System.NotImplementedException();
    }
}