using Mini_RPG_Data;
using Mini_RPG_Data.Map;
using System.Text;

internal class WriteTextFileGameProcessView : IGameProcessView
{
    private GameProcessController _gameProcessController = null!;

    public void SetGameProcessController(GameProcessController gameProcessController)
    {
        _gameProcessController = gameProcessController;
    }

    public void ShowMap(MapDTO mapDTO)
    {
        StringBuilder mapSB = new StringBuilder();
        IMapData map = mapDTO.MapData;

        int minX = mapDTO.MinX;
        int minY = mapDTO.MinY;
        int maxX = mapDTO.MaxX;
        int maxY = mapDTO.MaxY;

        for (int y = maxY; y >= minY; y--)
        {
            for (int x = minX; x <= maxX; x++)
            {
                Vector2Int cellCoord = new Vector2Int(x, y);
                if (map.Cells.ContainsKey(cellCoord))
                {

                    CellType cellType = map.Cells[cellCoord].CellType;
                    mapSB.Append(GetCellVierBasedOnCellType(cellType));
                }
                else
                    mapSB.Append(' ');
            }
            mapSB.Append("\n");
        }
        mapSB.Append("\n\n\n");

        int width = Math.Abs(minX) + Math.Abs(maxX) + 1;
        int height = Math.Abs(minY) + Math.Abs(maxY) + 1;
        mapSB.Append($"Empty =>'o', Town => 't', Enemy => 'e' {map.EnemyCount}, Loot => 'l' {map.LootCount}, LockedChest => 'c' {map.LockedChestCount}, " +
            $"HiddedLoot => 'h' {map.HiddenLootCount}, Trap => 'r' {map.TrapCount},\n" +
            $"mapSize = {width} x {height}, cellsCount = {map.Cells.Count}, not empty = {map.EnemyCount + map.LootCount + map.LockedChestCount + map.HiddenLootCount + map.TrapCount}");

        try
        {
            File.WriteAllText($"{DateTime.Now.Ticks}_chanse_{Settings.CELL_SPAWN_CHANCE}_new.txt", mapSB.ToString());

            Console.WriteLine("Map generated and write in file");
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }

    private string GetCellVierBasedOnCellType(CellType cellType)
    {
        return cellType switch
        {
            CellType.Empty => "o",
            CellType.Town => "t",
            CellType.Enemy => "e",
            CellType.Loot => "l",
            CellType.LockedChest => "c",
            CellType.HiddedLoot => "h",
            CellType.Trap => "r",
            CellType.None => throw new NotImplementedException(),
            _ => throw new NotImplementedException($"unnoun {cellType}"),
        };
    }
}