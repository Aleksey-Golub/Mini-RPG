using Mini_RPG_Data;
using Mini_RPG_Data.Map;
using Mini_RPG_Data.Services.Random_;
using System.Text;

public class Program
{

    public static void Main()
    {
        int cellsCount = 50;
        //string mapString = String.Empty;
        StringBuilder mapSB = new StringBuilder();
        MapData map = MapData.Generate(new RandomService(), cellsCount);

        int minX = int.MaxValue;
        int minY = int.MaxValue;
        int maxX = int.MinValue;
        int maxY = int.MinValue;
        foreach (Vector2Int key in map.Cells.Keys)
        {
            if (key.X < minX)
                minX = key.X;
            if (key.Y < minY)
                minY = key.Y;
            if (key.X > maxX)
                maxX = key.X;
            if (key.Y > maxY)
                maxY = key.Y;
        }

        for (int y = maxY; y >= minY; y--)
        {
            for (int x = minX; x <= maxX; x++)
            {
                Vector2Int cellCoord = new Vector2Int(x, y);
                if (map.Cells.ContainsKey(cellCoord))
                    mapSB.Append(GetStringBasedOnCellType(map.Cells[cellCoord].CellType));
                else
                    mapSB.Append(' ');
            }
            mapSB.Append("\n");
        }
        mapSB.Append("\n\n\n");

        int width = Math.Abs(minX) + Math.Abs(maxX) + 1;
        int height = Math.Abs(minY) + Math.Abs(maxY) + 1;
        mapSB.Append($"Empty =>'o', Town => 't', Enemy => 'e', Loot => 'l', LockedChest => 'c', HiddedLoot => 'h', Trap => 'r',\n" +
            $"mapSize = {width} x {height}, cellsCount = {cellsCount}");

        try
        {
            File.WriteAllText($"{DateTime.Now.Ticks}_chanse_{Settings.CELL_SPAWN_CHANCE}_thin.txt", mapSB.ToString());
            //using StreamWriter file = new($"{DateTime.Now}.txt");
            //file.Write(mapSB.ToString());

            Console.WriteLine("Map generated and write in file");
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }

    public static string GetStringBasedOnCellType(CellType cellType)
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