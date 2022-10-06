using Mini_RPG_Data.Controllers.Map_;
using System.Text.Json.Serialization;

namespace Mini_RPG_Data.Datas;

[Serializable]
public class MapData
{
    public MapCell[] Values { get; set; }

    public MapData()
    {
        Cells = new Dictionary<Vector2Int, MapCell>();
        Values = new MapCell[0];
    }

    [JsonIgnore]
    public Dictionary<Vector2Int, MapCell> Cells { get; set; }
    public int EnemyCount { get; set; }
    public int LootCount { get; set; }
    public int LockedChestCount { get; set; }
    public int HiddenLootCount { get; set; }
    public int TrapCount { get; set; }
    public int MinX { get; set; }
    public int MaxX { get; set; }
    public int MinY { get; set; }
    public int MaxY { get; set; }
    public Vector2Int PlayerPosition { get; set; }
    public Vector2Int TownPosition { get; set; }

    public void PrepareForSerialize()
    {
        Values = new MapCell[0];
        Values = Cells.Values.ToArray();
    }

    public void PrepareForDeserialize()
    {
        for (int i = 0; i < Values.Length; i++)
            Cells.Add(Values[i].Position, Values[i]);
    }

    internal void IncrementCounters(CellType cellType)
    {
        switch (cellType)
        {
            case CellType.None:
                return;
            case CellType.Empty:
                return;
            case CellType.Town:
                return;
            case CellType.Enemy:
                EnemyCount++;
                return;
            case CellType.Loot:
                LootCount++;
                return;
            case CellType.LockedChest:
                LockedChestCount++;
                return;
            case CellType.HiddedLoot:
                HiddenLootCount++;
                return;
            case CellType.Trap:
                TrapCount++;
                return;
            default:
                throw new NotImplementedException($"unnoun {cellType}");
        }
    }

    internal void CalculateSize()
    {
        MinX = int.MaxValue;
        MinY = int.MaxValue;
        MaxX = int.MinValue;
        MaxY = int.MinValue;

        foreach (Vector2Int key in Cells.Keys)
        {
            if (key.X < MinX)
                MinX = key.X;
            if (key.Y < MinY)
                MinY = key.Y;
            if (key.X > MaxX)
                MaxX = key.X;
            if (key.Y > MaxY)
                MaxY = key.Y;
        }
    }
}
