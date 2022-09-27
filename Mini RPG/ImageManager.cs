using Mini_RPG_Data.Controllers.Inventory_.Items;

namespace Mini_RPG;

internal static class ImageManager
{
    private const string ITEMS_PICTURE_DIRECTIRY = "Items";
    private const string ITEMS_PICTURE_SUFFIX = ".jpg";
    private const string EMPTY = "Empty";
    private static readonly List<Image> _locations;

    private static readonly Dictionary<string, Image> _images = new Dictionary<string, Image>();

    static ImageManager()
    {
        _locations = new List<Image>();
        _locations.Add(Properties.Resources.Forest_1);
        _locations.Add(Properties.Resources.Forest_2);
        _locations.Add(Properties.Resources.Forest_3);
        _locations.Add(Properties.Resources.Forest_4);
        _locations.Add(Properties.Resources.Forest_5);
        _locations.Add(Properties.Resources.Forest_6);
        _locations.Add(Properties.Resources.Forest_7);
        _locations.Add(Properties.Resources.Forest_8);
        _locations.Add(Properties.Resources.Forest_9);
        _locations.Add(Properties.Resources.Forest_10);
        _locations.Add(Properties.Resources.Forest_11);
        _locations.Add(Properties.Resources.Forest_12);
        _locations.Add(Properties.Resources.Forest_13);
        _locations.Add(Properties.Resources.Forest_14);
    }

    internal static Image GetTownEntrance() => Properties.Resources.Town_Entrance;

    internal static Image GetTown() => Properties.Resources.Town;

    internal static Image GetImageFromFile(string imagePath) => Image.FromFile(imagePath);

    internal static Image GetLocation(int imageIndex) => _locations[imageIndex];

    internal static Image GetItemImage(ItemBase item)
    {
        string pictureName = item == null ? EMPTY : item.PictureName;

        if (_images.ContainsKey(pictureName))
            return _images[pictureName];

        Image image = Image.FromFile($"{ITEMS_PICTURE_DIRECTIRY}\\{pictureName}{ITEMS_PICTURE_SUFFIX}");
        _images[pictureName] = image;
        return image;
    }
}
