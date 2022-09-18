﻿using Mini_RPG_Data.Controllers;
using Mini_RPG_Data.Controllers.Screens;
using Mini_RPG_Data.Map_;

namespace Mini_RPG_Data.Viewes;

public interface IGameProcessView : IView
{
    void Init(IPlayer player);
    void DeInit();
    void SetGameProcessController(GameProcessController controller);
    void SetActiveState(bool newState);
    void ShowMap(IMap map, int fieldOfView);
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
}
