using Mini_RPG_Data.Datas;
using Mini_RPG_Data.Map_;
using Mini_RPG_Data.Services.Localization;
using Mini_RPG_Data.Services.PersistentProgress;
using System.Text;

namespace Mini_RPG;

internal class MapView
{
    private const int FIELD_OF_VIEW = 2;
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
    private readonly Label _label_Map;
    private readonly ToolTip _toolTip;

    private readonly ILocalizationService _localizationService;
    private readonly IPersistentProgressService _progressService;

    public MapView(Label label_Map, ToolTip toolTip, ILocalizationService localizationService, IPersistentProgressService progressService)
    {
        _label_Map = label_Map;
        _toolTip = toolTip;

        _progressService = progressService;
        _localizationService = localizationService;
        _localizationService.LanguageChanged += SetToolTip;
    }

    public void Init() => SetToolTip();

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
            $"{PLAYER_SYMBOL} - {_progressService.Progress.PlayerData.CharacterData.Name}, {UNEXPLORED_SYMBOL} - {_localizationService.UnexploredLocation()}  \n" +
            $"{EMPTY_SYMBOL} - {_localizationService.EmptyExploredLocation()}, {TOWN_SYMBOL} - {_localizationService.Town()}, {ENEMY_SYMBOL} - {_localizationService.Enemy()}");
    }
}
