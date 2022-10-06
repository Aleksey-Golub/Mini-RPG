using Mini_RPG_Data.Controllers.Screens;

namespace Mini_RPG_Data.Viewes;

public interface IStartScreenView
{
    void SetActiveState(bool newState);
    void SetController(StartScreenController controller);
    void ShowSaves(List<StartScreenController.SaveDTO> savesDTO);
    void SetLoadButtonState(bool v);
}
