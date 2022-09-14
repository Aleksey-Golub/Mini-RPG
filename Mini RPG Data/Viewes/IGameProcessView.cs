using Mini_RPG_Data.Controllers;
using Mini_RPG_Data.Controllers.Character_;
using Mini_RPG_Data.Controllers.Screens;
using Mini_RPG_Data.Map_;

namespace Mini_RPG_Data.Viewes;

public interface IGameProcessView : IView
{
    void Init(ICharacter character, IWallet wallet);
    void DeInit();
    void SetGameProcessController(GameProcessController controller);
    void SetActiveState(bool newState);
    void ShowMap(IMap map);
    void ShowTownEntrance();
    void ShowTown();
}
