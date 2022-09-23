using Mini_RPG_Data.Datas;
using Mini_RPG_Data.Controllers.Map_;
using Mini_RPG_Data.Services.Localization;
using System.Text;

namespace Mini_RPG.Screens.CharacterCreationScreen_;

internal class MapView
{
    private const string PLAYER_SYMBOL = "@";
    private const string UNEXPLORED_SYMBOL = "Q";
    private const string EMPTY_SYMBOL = "O";
    private const string TOWN_SYMBOL = "M";
    private const string ENEMY_SYMBOL = "D";
    private const string LOOT_SYMBOL = "U";

    private const string LOCKEDCHEST_SYMBOL = "G";
    private const string HIDDENLOOT_SYMBOL = "H";
    private const string TRAP_SYMBOL = "W";
    private const string NOMAPCELL_SYMBOL = "   ";
    private const string BOARDER_SYMBOL = "N";

    private readonly Label _label_Map;
    private readonly ToolTip _toolTip;

    private readonly ILocalizationService _localizationService;
    private string? _characterName;

    internal MapView(Label label_Map, ToolTip toolTip, ILocalizationService localizationService)
    {
        _label_Map = label_Map;
        _toolTip = toolTip;

        _localizationService = localizationService;
        _localizationService.LanguageChanged += SetToolTip;
    }

    internal void Init(string characterName)
    {
        _characterName = characterName;
        SetToolTip();
    }

    internal void DrawMap(IMap map, int fieldOfView) => _label_Map.Text = CalculateStringMiniMap(map, fieldOfView);
    internal void DrawOpenedMap(IMap map) => _label_Map.Text = CalculateStringForOpenedMap(map);

    private string CalculateStringForOpenedMap(IMap map)
    {
        StringBuilder mapSB = new StringBuilder();
        int minX = map.MinX - 1;
        int minY = map.MinY - 1;
        int maxX = map.MaxX + 1;
        int maxY = map.MaxY + 1;

        for (int y = maxY; y >= minY; y--)
        {
            for (int x = minX; x <= maxX; x++)
            {
                Vector2Int cellCoord = new Vector2Int(x, y);
                string simbol = GetStringForOpenedMap(cellCoord, map);
                mapSB.Append(simbol);
            }
            mapSB.Append("\n");
        }

        return mapSB.ToString();
    }
    private string GetStringForOpenedMap(Vector2Int cellCoord, IMap map)
    {
        if (map.Cells.ContainsKey(cellCoord))
        {
            if (map.Cells[cellCoord].Position == map.PlayerPosition)
                return PLAYER_SYMBOL;
            else
                return map.Cells[cellCoord].CellState switch
                {
                    CellState.Unexplored => NOMAPCELL_SYMBOL,
                    CellState.Explored => GetStringForCellType(map.Cells[cellCoord].CellType),
                    CellState.None => throw new NotImplementedException(),
                    _ => throw new NotImplementedException(),
                };
        }
        else
        {
            if (map.AnyCellContactWith(cellCoord, CellState.Explored))
                return BOARDER_SYMBOL;
            else
                return NOMAPCELL_SYMBOL;
        }
    }

    private string CalculateStringMiniMap(IMap map, int fieldOfView)
    {
        StringBuilder mapSB = new StringBuilder();
        var playerPosition = map.PlayerPosition;
        int minX = playerPosition.X - fieldOfView;
        int minY = playerPosition.Y - fieldOfView;
        int maxX = playerPosition.X + fieldOfView;
        int maxY = playerPosition.Y + fieldOfView;

        for (int y = maxY; y >= minY; y--)
        {
            for (int x = minX; x <= maxX; x++)
            {
                Vector2Int cellCoord = new Vector2Int(x, y);
                string simbol = GetStringForMiniMap(cellCoord, map);
                mapSB.Append(simbol);
            }
            mapSB.Append("\n");
        }

        return mapSB.ToString();
    }

    private string GetStringForMiniMap(Vector2Int cellCoord, IMap map)
    {
        if (map.Cells.ContainsKey(cellCoord))
        {
            if (map.Cells[cellCoord].Position == map.PlayerPosition)
                return PLAYER_SYMBOL;
            else
                return map.Cells[cellCoord].CellState switch
                {
                    CellState.Unexplored => UNEXPLORED_SYMBOL,
                    CellState.Explored => GetStringForCellType(map.Cells[cellCoord].CellType),
                    CellState.None => throw new NotImplementedException(),
                    _ => throw new NotImplementedException(),
                };
        }
        else
        {
            if (map.AnyCellContactWith(cellCoord))
                return BOARDER_SYMBOL;
            else
                return NOMAPCELL_SYMBOL;
        }
    }

    private string GetStringForCellType(CellType cellType)
    {
        return cellType switch
        {
            CellType.Empty => EMPTY_SYMBOL,
            CellType.Town => TOWN_SYMBOL,
            CellType.Enemy => ENEMY_SYMBOL,
            CellType.Loot => LOOT_SYMBOL,
            CellType.LockedChest => LOCKEDCHEST_SYMBOL,
            CellType.HiddedLoot => HIDDENLOOT_SYMBOL,
            CellType.Trap => TRAP_SYMBOL,
            CellType.None => throw new NotImplementedException(),
            _ => throw new NotImplementedException(),
        };
    }

    private void SetToolTip()
    {
        _toolTip.SetToolTip(_label_Map,
            $"{PLAYER_SYMBOL} - {_characterName}, {UNEXPLORED_SYMBOL} - {_localizationService.UnexploredLocation()}, {TOWN_SYMBOL} - {_localizationService.Town()}\n" +
            $"{EMPTY_SYMBOL} - {_localizationService.EmptyExploredLocation()}, {ENEMY_SYMBOL} - {_localizationService.Enemy()}, {BOARDER_SYMBOL} - {_localizationService.LevelBoarder()}");
    }
}
