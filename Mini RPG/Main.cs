using Mini_RPG.Screens;
using Mini_RPG_Data.Controllers;
using Mini_RPG_Data.Controllers.Screens;
using Mini_RPG_Data.Services.Localization;
using Mini_RPG_Data.Services.PersistentProgress;
using Mini_RPG_Data.Services.Random_;
using Mini_RPG_Data.Services.SaveLoad;

namespace Mini_RPG;

public partial class Main : Form
{
    private readonly StartScreen _startScreen;
    private readonly CharacterCreationScreen _characterCreationScreen;
    private readonly IntroScreen _introScreen;
    private readonly GameProcessScreen _gameProcess;

    private ILocalizationService _localizationService = null!;
    private IPersistentProgressService _progressService = null!;
    private IRandomService _randomService = null!;
    private ISaveLoadService _saveLoadService = null!;

    public Main()
    {
        InitializeComponent();
        RegisterServices();

        
        _startScreen = new StartScreen(_localizationService);
        Controls.Add(_startScreen);

        _characterCreationScreen = new CharacterCreationScreen(_localizationService);
        Controls.Add(_characterCreationScreen);
        _characterCreationScreen.SetActiveState(false);

        _introScreen = new IntroScreen(_localizationService);
        Controls.Add(_introScreen);
        _introScreen.SetActiveState(false);

        _gameProcess = new GameProcessScreen();
        Controls.Add(_gameProcess);
        _gameProcess.SetActiveState(false);

        _startScreen.SetController(new StartScreenController(_startScreen, _characterCreationScreen));
        var characterCreationScreenController= new CharacterCreationScreenController(_characterCreationScreen, _introScreen, _progressService, _randomService, _saveLoadService);
        characterCreationScreenController.GameStarted += OnGameStarted;
        _characterCreationScreen.SetController(characterCreationScreenController);
        _introScreen.SetController(characterCreationScreenController);
    }

    private void OnGameStarted(CharacterCreationScreenController controller, Player createdPlayer)
    {
        controller.GameStarted -= OnGameStarted;
        _gameProcess.SetGameProcessController(new GameProcessController(_randomService, _gameProcess));
    }

    private void RegisterServices()
    {
        _localizationService = new SimpleLocalizationService();
        _progressService = new PersistentProgressService();
        _randomService = new RandomService();
        _saveLoadService = new JsonFileSaveLoadService(_progressService);
    }
}
