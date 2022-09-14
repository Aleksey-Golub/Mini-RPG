using Mini_RPG_Data.Datas;
using Mini_RPG_Data.Map_;
using System.Text;

namespace Mini_RPG;

internal class MapView
{
    private const int FIELD_OF_VIEW = 2;
    private readonly Label _label_Map;

    public MapView(Label label_Map)
    {
        _label_Map = label_Map;
    }

    internal void DrawMap(IMap map) => _label_Map.Text = CalculateString(map);

    private string CalculateString(IMap map)
    {
        StringBuilder mapSB = new StringBuilder();
        var playerPosition = map.PlayerPosition;
        int minX = playerPosition.X - FIELD_OF_VIEW;
        int minY = playerPosition.Y - FIELD_OF_VIEW;
        int maxX = playerPosition.X + FIELD_OF_VIEW;
        int maxY = playerPosition.Y + FIELD_OF_VIEW;

        for (int y = maxY; y >= minY; y--)
        {
            for (int x = minX; x <= maxX; x++)
            {
                Vector2Int cellCoord = new Vector2Int(x, y);
                string simbol = GetStringFor(cellCoord, map);
                mapSB.Append(simbol);
            }
            mapSB.Append("\n");
        }

        return mapSB.ToString();
    }

    private string GetStringFor(Vector2Int cellCoord, IMap map)
    {
        if (map.Cells.ContainsKey(cellCoord))
        {
            if (map.Cells[cellCoord].Position == map.PlayerPosition)
                return "@";
            else
                return map.Cells[cellCoord].CellState switch
                {
                    CellState.Unexplored => "Q",
                    CellState.Explored => GetStringForCellType(map.Cells[cellCoord].CellType),
                    CellState.None => throw new NotImplementedException(),
                    _ => throw new NotImplementedException(),
                };
        }
        else
        {
            return "   ";
        }
    }

    private string GetStringForCellType(CellType cellType)
    {
        return cellType switch
        {
            CellType.Empty => "O",
            CellType.Town => "M",
            CellType.Enemy => "D",
            CellType.Loot => "U",
            CellType.LockedChest => "G",
            CellType.HiddedLoot => "H",
            CellType.Trap => "W",
            CellType.None => throw new NotImplementedException(),
            _ => throw new NotImplementedException(),
        };
    }
}
