using Mini_RPG_Data;
using Mini_RPG_Data.Controllers;
using Mini_RPG_Data.Controllers.Character_;
using Mini_RPG_Data.Controllers.Screens;
using Mini_RPG_Data.Datas;
using Mini_RPG_Data.Controllers.Map_;
using Mini_RPG_Data.Viewes;
using System.Text;
using Mini_RPG_Data.Controllers.Inventory_.Items;

internal class WriteTextFileGameProcessView : IGameProcessView
{
    private GameProcessScreenController _gameProcessController = null!;

    private bool _isActive;

    public void Init(ICharacter character, IWallet wallet)
    {
        throw new NotImplementedException();
    }

    public void DeInit()
    {
        throw new NotImplementedException();
    }

    public void SetActiveState(bool newState) => _isActive = newState;

    public void SetGameProcessController(GameProcessScreenController gameProcessController)
    {
        _gameProcessController = gameProcessController;
    }

    public void ShowTownEntrance() => throw new NotImplementedException();
    public void ShowTown() => throw new NotImplementedException();

    public void ShowMap(IMap mapData)
    {
        StringBuilder mapSB = new StringBuilder();
        IMap map = mapData;

        int minX = mapData.MinX;
        int minY = mapData.MinY;
        int maxX = mapData.MaxX;
        int maxY = mapData.MaxY;

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

    public void Init(IPlayer player)
    {
        throw new NotImplementedException();
    }

    public void ShowLocation(IMapCell cell)
    {
        throw new NotImplementedException();
    }

    public void ShowLootCellMessage(int money, IReadOnlyList<ItemBase> loot)
    {
        throw new NotImplementedException();
    }

    public void ShowMiniMap(IMap map, int fieldOfView)
    {
        throw new NotImplementedException();
    }

    public void ShowFindChestMessage()
    {
        throw new NotImplementedException();
    }

    public void ShowSuccessPickLockedChestMessage(int money, IReadOnlyList<ItemBase> loot)
    {
        throw new NotImplementedException();
    }

    public void ShowFailPickLockedChestMessage()
    {
        throw new NotImplementedException();
    }

    public void ShowSuccessBreakChestMessage(int money, IReadOnlyList<ItemBase> loot)
    {
        throw new NotImplementedException();
    }

    public void ShowFailBreakChestMessage()
    {
        throw new NotImplementedException();
    }

    public void ShowSuccessFindHiddenLootMessage(int money, IReadOnlyList<ItemBase> loot)
    {
        throw new NotImplementedException();
    }

    public void ShowSuccessFindTrapMessage(TrapType trapType)
    {
        throw new NotImplementedException();
    }

    public void ShowFailFindTrapMessage(TrapType trapType)
    {
        throw new NotImplementedException();
    }

    public void ShowSuccessRestInTownMessage()
    {
        throw new NotImplementedException();
    }

    public void ShowFailRestInTownMessage()
    {
        throw new NotImplementedException();
    }

    public void ShowBattleStartMessage()
    {
        throw new NotImplementedException();
    }

    public void HideBattle(BattleResult battleResult, IReadOnlyList<ItemBase> items, int experience)
    {
        throw new NotImplementedException();
    }

    public void ShowBattle(ICharacter enemy)
    {
        throw new NotImplementedException();
    }

    public void ShowMapExploredMessage()
    {
        throw new NotImplementedException();
    }

    public void ShowRestInTownDialog(int restCost)
    {
        throw new NotImplementedException();
    }
}