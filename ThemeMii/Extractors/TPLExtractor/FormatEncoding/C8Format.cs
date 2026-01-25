namespace ThemeMii.Extractors.FormatEncoding;

public class C8Format : IEncodedFormat
{
    public int BitsPerPixel => 8;
    public int BlockWidth => 8;
    public int BlockHeight => 4;

    public void ConvertAndStoreToByteArray(byte[] inputArray, byte[] outputArray, int currentInputPosition,
        int currentOutputPosition)
    {
        throw new System.NotImplementedException();
    }
}