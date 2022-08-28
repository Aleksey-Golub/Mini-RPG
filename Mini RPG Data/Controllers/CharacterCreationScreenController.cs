using Mini_RPG_Data.Viewes;

namespace Mini_RPG_Data.Controllers;

public class CharacterCreationScreenController
{
    private readonly ICharacterCreationScreenView _characterCreationScreen;
    private readonly IIntroScreenView _introScreen;

    public CharacterCreationScreenController(ICharacterCreationScreenView characterCreationScreen, IIntroScreenView introScreen)
    {
        _characterCreationScreen = characterCreationScreen;
        _introScreen = introScreen;
    }
}
