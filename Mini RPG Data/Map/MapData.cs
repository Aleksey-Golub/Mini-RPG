using Mini_RPG_Data.Services.Random;

namespace Mini_RPG_Data.Map;

internal class MapData
{
    private readonly Dictionary<Vector2Int, MapCell> _cells;

    public IReadOnlyDictionary<Vector2Int, IMapCell> Cells => _cells.ToDictionary(x => x.Key, x => x.Value as IMapCell);

    private MapData()
    {
        _cells = new Dictionary<Vector2Int, MapCell>();

        Vector2Int townCell = new Vector2Int(0, 0);
        _cells[townCell] = new MapCell(townCell, CellType.Town, CellState.Explored);
    }

    /// <summary>
    /// 0,0 cell is always a town
    /// </summary>
    /// <param name="cellsCount">Size of map without town cell. Have to be greate then 0</param>
    /// <returns></returns>
    public static MapData Generate(IRandomService randomService, int cellsCount)
    {
        if (cellsCount <= 0)
            throw new ArgumentOutOfRangeException(nameof(cellsCount), "CellsCount have to be greate then 0");

        MapData map = new MapData();

        while (cellsCount > 0)
        {
            // get a collection of cell neighbors with unique elements to avoid duplication
            List<Vector2Int> neighborsPositions = new List<Vector2Int>(50);
            foreach (var cell in map._cells.Values)
            {
                Vector2Int[] cellNs = cell.GetNeighborsPositions();
                foreach (var n in cellNs)
                {
                    if (map._cells.ContainsKey(n) == false)
                        neighborsPositions.Add(n);
                }
            }

            // try generate new cells
            // revers for diversity
            if (cellsCount % 2 == 0)
                neighborsPositions.Reverse();

            foreach (var nP in neighborsPositions)
            {
                int cellSpawnValue = randomService.GetIntInclusive(1, 100);
                if (cellSpawnValue <= Settings.CELL_SPAWN_CHANCE)
                {
                    int value = randomService.GetIntInclusive(1, 100);

                    CellType cellType = Settings.GetCellTypeByRandomValue(value);

                    map._cells[nP] = new MapCell(nP, cellType);
                    cellsCount--;

                    if (cellsCount <= 0)
                        break;
                }
            }
        }

        return map;
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

    internal Vector2Int[] GetNeighborsPositions()
    {
        int neighborsCount = 4;
        Vector2Int[] result = new Vector2Int[neighborsCount];

        result[0] = new Vector2Int(Position.X - 1, Position.Y);
        result[1] = new Vector2Int(Position.X + 1, Position.Y);
        result[2] = new Vector2Int(Position.X, Position.Y - 1);
        result[3] = new Vector2Int(Position.X, Position.Y + 1);

        return result;
    }
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
