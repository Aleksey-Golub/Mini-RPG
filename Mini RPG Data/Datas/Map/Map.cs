using Mini_RPG_Data.Datas;
using Mini_RPG_Data.Services.Random_;

namespace Mini_RPG_Data.Map_;

[Serializable]
public class Map : IMap
{
    private readonly MapData _data;

    public IReadOnlyDictionary<Vector2Int, IMapCell> Cells => _data.Cells.ToDictionary(x => x.Key, x => x.Value as IMapCell);

    public int EnemyCount { get => _data.EnemyCount; private set => _data.EnemyCount = value; }
    public int LootCount { get => _data.LootCount; private set => _data.LootCount = value; }
    public int LockedChestCount { get => _data.LockedChestCount; private set => _data.LockedChestCount = value; }
    public int HiddenLootCount { get => _data.HiddenLootCount; private set => _data.HiddenLootCount = value; }
    public int TrapCount { get => _data.TrapCount; private set => _data.TrapCount = value; }
    public int MinX { get => _data.MinX; }
    public int MaxX { get => _data.MaxX; }
    public int MinY { get => _data.MinY; }
    public int MaxY { get => _data.MaxY; }
    public Vector2Int PlayerPosition { get => _data.PlayerPosition; private set => _data.PlayerPosition = value; }
    public Vector2Int TownPosition => _data.TownPosition;
    public bool IsPlayerOnTownCell => PlayerPosition == TownPosition;

    Vector2Int IMap.PlayerPosition => PlayerPosition;
    Vector2Int IMap.TownPosition => TownPosition;

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
        Vector2Int townCellPos = new Vector2Int(0, 0);
        MapCell townCell = new MapCell(townCellPos, CellType.Town, CellState.Explored);
        mapData.Cells[townCellPos] = townCell;
        mapData.TownPosition = townCellPos;
        mapData.PlayerPosition = townCellPos;

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
