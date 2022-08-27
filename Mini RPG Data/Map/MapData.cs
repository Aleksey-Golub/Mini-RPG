using Mini_RPG_Data.Services.Random_;

namespace Mini_RPG_Data.Map;

public class MapData : IMapData
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
                    lastCells.Add(newCell);
                    map._cells[nP] = newCell;
                    counter--;

                    if (counter <= 0)
                        break;
                }
            }
        }

        return map;
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
