using Mini_RPG_Data.Controllers.Screens;
using Mini_RPG_Data.Map;

namespace Mini_RPG_Data.Viewes;

public interface IGameProcessView : IView
{
    void SetGameProcessController(GameProcessController controller);
    void ShowMap(IMapData mapData);
    void SetActiveState(bool newState);
}
