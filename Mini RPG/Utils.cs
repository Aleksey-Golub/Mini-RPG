namespace Mini_RPG;

internal static class Utils
{
    public static byte[] ToByteArray(this Image image)
    {
        using var ms = new MemoryStream();

        image.Save(ms, image.RawFormat);
        return ms.ToArray();
    }

    public static Image? ImageFromByteArray(byte[] data)
    {
        using var ms = new MemoryStream(data);
        try
        {
            return Image.FromStream(ms);
        }
        catch { }

        return null;
    }
}
