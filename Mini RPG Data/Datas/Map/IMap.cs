using Mini_RPG_Data.Datas;

namespace Mini_RPG_Data.Map_;

public interface IMap
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
    public Vector2Int PlayerPosition { get; }
    public Vector2Int TownPosition { get; }

    bool AnyCellContactWith(Vector2Int cellCoord);
}
