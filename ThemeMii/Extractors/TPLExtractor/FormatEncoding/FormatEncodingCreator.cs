using System;

namespace ThemeMii.Extractors.FormatEncoding;

public class FormatEncodingCreator
{
    public static IEncodedFormat CreateFormatEncoder(ImageFormats format)
    {
        switch (format)
        {
            case ImageFormats.I8:
                return new I8Format();
            case ImageFormats.IA4:
                return new IA4Format();
            case ImageFormats.IA8:
                return new IA8Format();
            case ImageFormats.RGB565:
                return new RGB565Format();
            case ImageFormats.RGB5A3:
                return new RGB5A3Format();
            case ImageFormats.C8:
                return new C8Format();
            case ImageFormats.C14X2:
                return new C14X2Format();
            case ImageFormats.I4:
                return new I4Format();
            case ImageFormats.C4:
                return new C4Format();
            case ImageFormats.CMPR:
                return new CMPRFormat();
            default:
                throw new NotImplementedException();
        }
    }
}