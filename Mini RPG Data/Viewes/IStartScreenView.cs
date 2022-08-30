﻿using Mini_RPG_Data.Controllers;

namespace Mini_RPG_Data.Viewes;

public interface IStartScreenView : IView
{
    void SetActiveState(bool newState);
    void SetController(StartScreenController controller);
}