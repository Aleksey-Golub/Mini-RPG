using Mini_RPG_Data.Controllers;
using Mini_RPG_Data.Controllers.Screens;
using Mini_RPG_Data.Controllers.Map_;
using Mini_RPG_Data.Controllers.Character_;

namespace Mini_RPG_Data.Viewes;

public interface IGameProcessView : IView
{
    void Init(IPlayer player);
    void DeInit();
    void SetGameProcessController(GameProcessScreenController controller);
    void SetActiveState(bool newState);
    void ShowMiniMap(IMap map, int fieldOfView);
    void ShowTownEntrance();
    void ShowTown();
    void ShowLocation(IMapCell cell);
    void ShowLootCellMessage(int money, List<Controllers.Inventory_.Items.ItemBase> loot);
    void ShowFindChestMessage();
    void ShowSuccessPickLockedChestMessage(int money, List<Controllers.Inventory_.Items.ItemBase> loot);
    void ShowFailPickLockedChestMessage();
    void ShowSuccessBreakChestMessage(int money, List<Controllers.Inventory_.Items.ItemBase> loot);
    void ShowFailBreakChestMessage();
    void ShowSuccessFindHiddenLootMessage(int money, List<Controllers.Inventory_.Items.ItemBase> loot);
    void ShowSuccessFindTrapMessage(TrapType trapType);
    void ShowFailFindTrapMessage(TrapType trapType);
    void ShowMap(IMap map);
    void ShowSuccessRestInTownMessage();
    void ShowFailRestInTownMessage();
    void ShowBattle(ICharacter enemy);
    void ShowBattleStartMessage();
    void HideBattle();
}
