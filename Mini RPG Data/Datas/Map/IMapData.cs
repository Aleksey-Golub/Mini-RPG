namespace Mini_RPG_Data.Map;

public interface IMapData
{
    IReadOnlyDictionary<Vector2Int, IMapCell> Cells { get; }
    int EnemyCount { get; }
    int LootCount { get; }
    int LockedChestCount { get; }
    int HiddenLootCount { get; }
    int TrapCount { get; }
    int MinX { get; }
    int MaxX { get; }
    int MinY { get; }
    int MaxY { get; }
}
