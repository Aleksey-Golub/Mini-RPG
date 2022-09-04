using Mini_RPG_Data.Datas;
using Mini_RPG_Data.Services.Random_;

namespace Mini_RPG_Data.Map;

[Serializable]
public class MapData : IMapData
{
    private readonly Dictionary<Vector2Int, MapCell> _cells;

    public IReadOnlyDictionary<Vector2Int, IMapCell> Cells => _cells.ToDictionary(x => x.Key, x => x.Value as IMapCell);

    public int EnemyCount { get; private set; }
    public int LootCount { get; private set; }
    public int LockedChestCount { get; private set; }
    public int HiddenLootCount { get; private set; }
    public int TrapCount { get; private set; }
    public int MinX { get; private set; }
    public int MaxX { get; private set; }
    public int MinY { get; private set; }
    public int MaxY { get; private set; }

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
    internal static MapData Generate(IRandomService randomService)
    {
        int cellsCount = randomService.GetIntInclusive(Settings.MIN_MAP_CELL_COUNT, Settings.MAX_MAP_CELL_COUNT);

        if (cellsCount <= 0)
            throw new ArgumentOutOfRangeException(nameof(cellsCount), "CellsCount have to be greate then 0");

        MapData map = new MapData();
        int counter = cellsCount;

        List<MapCell> lastCells;
        while (counter > 0)
        {
            int minFreeNCount = 2;
            do
            {
                lastCells = map._cells.Values.ToList();
            
                for (int i = 0; i < lastCells.Count; i++)
                {
                    MapCell? c = lastCells[i];
                    int freeN = 0;
                    var cNs = c.GetNeighborsPositions();

                    foreach (var cN in cNs)
                        if (map._cells.ContainsKey(cN) == false)
                            freeN++;

                    if (freeN <= minFreeNCount)
                    {
                        lastCells.Remove(c);
                        i--;
                    }
                }
                minFreeNCount--;
            }
            while (lastCells.Count == 0);

            // get a collection of cell neighbors with unique elements to avoid duplication
            List<Vector2Int> neighborsPositions = new List<Vector2Int>(50);

            // get all cells
            //foreach (var cell in map._cells.Values)

            // get last cells
            foreach (var cell in lastCells)
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
            if (counter % 2 == 0)
                neighborsPositions.Reverse();

            foreach (var nP in neighborsPositions)
            {
                if (map._cells.ContainsKey(nP))
                    continue;

                int cellSpawnValue = randomService.GetIntInclusive(1, 100);
                if (cellSpawnValue <= Settings.CELL_SPAWN_CHANCE)
                {
                    int value = randomService.GetIntInclusive(1, 100);

                    CellType cellType = Settings.GetCellTypeBasedOnRandomValue(value);

                    MapCell newCell = new MapCell(nP, cellType);
                    map._cells[nP] = newCell;
                    map.IncrementCounters(cellType);
                    counter--;

                    if (counter <= 0)
                        break;
                }
            }
        }

        map.CalculateSize();
        return map;
    }

    private void IncrementCounters(CellType cellType)
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

    private void CalculateSize()
    {
        MinX = int.MaxValue;
        MinY = int.MaxValue;
        MaxX = int.MinValue;
        MaxY = int.MinValue;

        foreach (Vector2Int key in _cells.Keys)
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
