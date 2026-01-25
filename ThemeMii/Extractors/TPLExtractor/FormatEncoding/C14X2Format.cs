namespace ThemeMii.Extractors.FormatEncoding;

public class C14X2Format : IEncodedFormat
{
    public int BitsPerPixel => 16;
    public int BlockWidth => 4;
    public int BlockHeight => 4;

    public void ConvertAndStoreToByteArray(byte[] inputArray, byte[] outputArray, int currentInputPosition,
        int currentOutputPosition)
    {
        throw new System.NotImplementedException();
    }
}