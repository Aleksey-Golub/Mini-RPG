using Mini_RPG_Data.Controllers;
using Mini_RPG_Data.Controllers.Screens;
using Mini_RPG_Data.Controllers.Map_;
using Mini_RPG_Data.Controllers.Character_;
using Mini_RPG_Data.Controllers.Inventory_.Items;

namespace Mini_RPG_Data.Viewes;

public interface IGameProcessView
{
    void Init(IPlayer player);
    void DeInit();
    void SetGameProcessController(GameProcessScreenController controller);
    void SetActiveState(bool newState);
    void ShowMiniMap(IMap map, int fieldOfView);
    void ShowTownEntrance();
    void ShowTown();
    void ShowLocation(IMapCell cell);
    void ShowLootCellMessage(int money, IReadOnlyList<ItemBase> loot);
    void ShowFindChestMessage();
    void ShowSuccessPickLockedChestMessage(int money, IReadOnlyList<ItemBase> loot);
    void ShowFailPickLockedChestMessage();
    void ShowSuccessBreakChestMessage(int money, IReadOnlyList<ItemBase> loot);
    void ShowFailBreakChestMessage();
    void ShowSuccessFindHiddenLootMessage(int money, IReadOnlyList<ItemBase> loot);
    void ShowSuccessFindTrapMessage(TrapType trapType);
    void ShowFailFindTrapMessage(TrapType trapType);
    void ShowMap(IMap map);
    void ShowSuccessRestInTownMessage();
    void ShowFailRestInTownMessage();
    void ShowBattle(ICharacter enemy);
    void ShowBattleStartMessage();
    void HideBattle(BattleResult playerWon, IReadOnlyList<ItemBase> loot, int experience);
    void ShowMapExploredMessage();
    void ShowRestInTownDialog(int restCost);
    void ShowQuestMessage(string message);
}
