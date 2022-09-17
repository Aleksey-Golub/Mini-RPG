using Mini_RPG_Data;

namespace Mini_RPG;

internal class ImageManager
{
    private readonly List<Image> _locations;

    public ImageManager()
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

    internal Image GetTownEntrance() => Properties.Resources.Town_Entrance;

    internal Image GetTown() => Properties.Resources.Town;

    internal Image GetImageFromFile(string imagePath) => Image.FromFile(imagePath);

    internal Image GetLocation(int imageIndex) => _locations[imageIndex];
}
