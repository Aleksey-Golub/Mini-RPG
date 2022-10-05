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

        internal abstract void Enter();
        internal abstract bool TryMove(Direction direction);
        internal abstract void Tick(PlayerAction playerAction);
        internal abstract void Exit();
    }
}