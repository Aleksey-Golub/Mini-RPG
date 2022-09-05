using Mini_RPG_Data.Controllers.Screens;
using Mini_RPG_Data.Map_;

namespace Mini_RPG_Data.Viewes;

public interface IGameProcessView : IView
{
    void SetGameProcessController(GameProcessController controller);
    void ShowMap(IMap mapData);
    void SetActiveState(bool newState);
}
