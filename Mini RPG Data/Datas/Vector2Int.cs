namespace Mini_RPG_Data.Datas;

[Serializable]
public struct Vector2Int
{
    public int X;
    public int Y;

    public Vector2Int(int x, int y)
    {
        X = x;
        Y = y;
    }

    public static bool operator ==(Vector2Int v1, Vector2Int v2) => v1.X == v2.X && v1.Y == v2.Y;
    public static bool operator !=(Vector2Int v1, Vector2Int v2) => !(v1 == v2);
}
