﻿using Mini_RPG_Data.Controllers;
using Mini_RPG_Data.Controllers.Screens;

namespace Mini_RPG_Data.Viewes;

public interface IPlayerDeathView
{
    void DeInit();
    void SetActiveState(bool newState);
    void SetController(GameProcessScreenController controller);
    void ShowPlayerResult(IPlayer player);
}
