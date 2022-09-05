using Mini_RPG_Data.Datas;
using Mini_RPG_Data.Services.Random_;

namespace Mini_RPG_Data.Map_;

[Serializable]
public class Map : IMap
{
    private readonly MapData _data;

    public IReadOnlyDictionary<Vector2Int, IMapCell> Cells => _data.Cells.ToDictionary(x => x.Key, x => x.Value as IMapCell);

    public int EnemyCount { get => _data.EnemyCount; private set => _data.EnemyCount = value; }
    public int LootCount { get; private set; }
    public int LockedChestCount { get; private set; }
    public int HiddenLootCount { get; private set; }
    public int TrapCount { get; private set; }
    public int MinX { get; private set; }
    public int MaxX { get; private set; }
    public int MinY { get; private set; }
    public int MaxY { get; private set; }

    public Map(MapData data)
    {
        _data = data;
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

        var mapData = new MapData();
        mapData.Cells = new Dictionary<Vector2Int, MapCell>();
        Vector2Int townCell = new Vector2Int(0, 0);
        mapData.Cells[townCell] = new MapCell(townCell, CellType.Town, CellState.Explored);

        int counter = cellsCount;

        List<MapCell> lastCells;
        while (counter > 0)
        {
            int minFreeNCount = 2;
            do
            {
                lastCells = mapData.Cells.Values.ToList();
            
                for (int i = 0; i < lastCells.Count; i++)
                {
                    MapCell? c = lastCells[i];
                    int freeN = 0;
                    var cNs = c.GetNeighborsPositions();

                    foreach (var cN in cNs)
                        if (mapData.Cells.ContainsKey(cN) == false)
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
                    if (mapData.Cells.ContainsKey(n) == false)
                        neighborsPositions.Add(n);
                }
            }

            // try generate new cells
            // revers for diversity
            if (counter % 2 == 0)
                neighborsPositions.Reverse();

            foreach (var nP in neighborsPositions)
            {
                if (mapData.Cells.ContainsKey(nP))
                    continue;

                int cellSpawnValue = randomService.GetIntInclusive(1, 100);
                if (cellSpawnValue <= Settings.CELL_SPAWN_CHANCE)
                {
                    int value = randomService.GetIntInclusive(1, 100);

                    CellType cellType = Settings.GetCellTypeBasedOnRandomValue(value);

                    MapCell newCell = new MapCell(nP, cellType);
                    mapData.Cells[nP] = newCell;
                    mapData.IncrementCounters(cellType);
                    counter--;

                    if (counter <= 0)
                        break;
                }
            }
        }

        mapData.CalculateSize();
        return mapData;
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
