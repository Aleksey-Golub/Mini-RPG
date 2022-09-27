using Mini_RPG_Data.Controllers;
using Mini_RPG_Data.Controllers.Screens;
using Mini_RPG_Data.Controllers.Map_;

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
    void ShowLootCellMessage(int money);
    void ShowFindChestMessage();
    void ShowSuccessPickLockedChestMessage(int money);
    void ShowFailPickLockedChestMessage();
    void ShowSuccessBreakChestMessage(int money);
    void ShowFailBreakChestMessage();
    void ShowSuccessFindHiddenLootMessage(int money);
    void ShowSuccessFindTrapMessage(TrapType trapType);
    void ShowFailFindTrapMessage(TrapType trapType);
    void ShowMap(IMap map);
}
