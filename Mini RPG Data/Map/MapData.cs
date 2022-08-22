namespace Mini_RPG_Data.Map;

internal class MapData
{
    private readonly Dictionary<Vector2Int, MapCell> _cells;

    public IReadOnlyDictionary<Vector2Int, IMapCell> CellMap => _cells.ToDictionary(x => x.Key, x => x.Value as IMapCell);

    private MapData()
    {
        _cells = new Dictionary<Vector2Int, MapCell>();
    }
}

public interface IMapCell
{
    Vector2Int Position { get; }
    CellType CellType { get; }
    CellState CellState { get; }
}

internal class MapCell : IMapCell
{
    public MapCell(Vector2Int position, CellType cellType = CellType.Empty, CellState cellState = CellState.Unexplored)
    {
        Position = position;
        CellType = cellType;
        CellState = cellState;
    }

    public Vector2Int Position { get; }
    public CellType CellType { get; set; }
    public CellState CellState { get; set; }
}

public enum CellState
{
    None,
    Explored,
    Unexplored,
}

public enum CellType
{
    None,
    Empty,
    Town,
    Enemy,
    Loot,
    LockedChest,
    HiddedLoot,
    Trap,
}
