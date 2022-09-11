using Mini_RPG_Data.Controllers.Screens;

namespace Mini_RPG_Data.Viewes;

public interface IStartScreenView : IView
{
    void SetActiveState(bool newState);
    void SetController(StartScreenController controller);
    void ShowSaves(List<StartScreenController.SaveDTO> savesDTO);
    void SetLoadButtonState(bool v);
}
