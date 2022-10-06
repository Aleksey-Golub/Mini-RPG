using Mini_RPG_Data.Controllers.Screens;

namespace Mini_RPG_Data.Viewes;

public interface IIntroScreenView
{
    void SetActiveState(bool newState);
    void SetController(CharacterCreationScreenController controller);
}
