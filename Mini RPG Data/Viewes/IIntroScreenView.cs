using Mini_RPG_Data.Controllers;

namespace Mini_RPG_Data.Viewes;

public interface IIntroScreenView : IView
{
    void SetActiveState(bool newState);
    void SetController(CharacterCreationScreenController controller);
}
