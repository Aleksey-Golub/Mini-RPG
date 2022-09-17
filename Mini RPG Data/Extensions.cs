namespace Mini_RPG_Data;

public static class Extensions
{
    private static readonly System.Random _rnd = new System.Random();

    public static T GetRandomItem<T>(this List<T> list)
    {
        int v = _rnd.Next(0, list.Count);

        return list[v];
    }
}
