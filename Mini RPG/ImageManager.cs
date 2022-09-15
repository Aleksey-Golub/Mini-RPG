namespace Mini_RPG;

internal class ImageManager
{
    internal Image GetTownEntrance() => Properties.Resources.Town_Entrance;

    internal Image GetTown() => Properties.Resources.Town;

    internal Image GetImageFromFile(string imagePath) => Image.FromFile(imagePath);
}
