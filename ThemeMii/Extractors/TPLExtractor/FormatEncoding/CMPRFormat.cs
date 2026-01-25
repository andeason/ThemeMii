namespace ThemeMii.Extractors.FormatEncoding;

public class CMPRFormat : IEncodedFormat
{
    public int BitsPerPixel => 4;
    public int BlockWidth => 8;
    public int BlockHeight => 8;

    public void ConvertAndStoreToByteArray(byte[] inputArray, byte[] outputArray, int currentInputPosition,
        int currentOutputPosition)
    {
        throw new System.NotImplementedException();
    }
}