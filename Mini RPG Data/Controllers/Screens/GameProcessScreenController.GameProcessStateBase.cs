namespace Mini_RPG_Data.Controllers.Screens;

public partial class GameProcessScreenController
{
    private abstract class GameProcessStateBase
    {
        protected readonly GameProcessScreenController Controller;

        public GameProcessStateBase(GameProcessScreenController controller)
        {
            Controller = controller;
        }

        internal abstract void Exit();
        internal abstract bool TryMove(Direction direction);
        internal abstract void Enter();
    }
}