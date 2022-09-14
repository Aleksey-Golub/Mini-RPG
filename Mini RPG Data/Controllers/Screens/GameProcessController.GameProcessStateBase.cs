﻿namespace Mini_RPG_Data.Controllers.Screens;

public partial class GameProcessController
{
    private abstract class GameProcessStateBase
    {
        protected readonly GameProcessController Controller;

        public GameProcessStateBase(GameProcessController controller)
        {
            Controller = controller;
        }

        internal abstract void Exit();
        internal abstract void Execute();
        internal abstract void Enter();
        protected abstract bool CheckNeedAndDoTransition();
    }
}