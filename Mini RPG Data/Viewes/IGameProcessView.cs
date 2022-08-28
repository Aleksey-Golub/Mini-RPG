using Mini_RPG_Data.Controllers;
using Mini_RPG_Data.Map;

namespace Mini_RPG_Data.Viewes;

public interface IGameProcessView : IView
{
    void SetGameProcessController(GameProcessController gameProcessController);
    void ShowMap(IMapData mapData);
    void SetActiveState(bool newState);
}
