using Mini_RPG_Data.Controllers.Character_;
using Mini_RPG_Data.Controllers.Screens;

namespace Mini_RPG_Data.Viewes;

public interface ICharacterCreationScreenView
{
    void SetActiveState(bool newState);
    void SetController(CharacterCreationScreenController controller);
    void SetCharacter(ICharacter characterData);
}
