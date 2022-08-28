using Mini_RPG_Data.Viewes;

namespace Mini_RPG_Data.Controllers;

public class StartScreenController
{
    private readonly IStartScreenView _startScreenView;
    private readonly ICharacterCreationScreenView _characterCreationScreenView;

    public StartScreenController(
        IStartScreenView startScreenView, 
        ICharacterCreationScreenView characterCreationScreenView) 
    {
        _startScreenView = startScreenView;
        _characterCreationScreenView = characterCreationScreenView;
    }

    public void LoadSavedGame()
    {
        // load game with ISaveLoadService
    }

    public void StartNewGame()
    {
        _startScreenView.SetActiveState(false);
        _characterCreationScreenView.SetActiveState(true);
    }
}
