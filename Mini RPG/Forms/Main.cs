using Mini_RPG.Screens;
using Mini_RPG_Data;
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
    private readonly GameProcessScreen _gameProcessScreen;
    private readonly PlayerDeathScreen _playerDeathScreen;

    private readonly StartScreenController _startScreenController;
    private readonly CharacterCreationScreenController _characterCreationScreenController;
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
        _startScreen.SetActiveState(false);

        _characterCreationScreen = new CharacterCreationScreen(_localizationService);
        Controls.Add(_characterCreationScreen);
        _characterCreationScreen.SetActiveState(false);

        _introScreen = new IntroScreen(_localizationService);
        Controls.Add(_introScreen);
        _introScreen.SetActiveState(false);

        _gameProcessScreen = new GameProcessScreen(_localizationService);
        Controls.Add(_gameProcessScreen);
        _gameProcessScreen.SetActiveState(false);

        _startScreenController = new StartScreenController(_startScreen, _characterCreationScreen, _saveLoadService, _progressService);
        _startScreenController.Init();
        _startScreenController.GameLoaded += StartGameProcess;
        _startScreen.SetController(_startScreenController);

        _characterCreationScreenController = new CharacterCreationScreenController(_characterCreationScreen, _introScreen, _progressService, _randomService, _saveLoadService);
        _characterCreationScreenController.GameStarted += StartGameProcess;
        _characterCreationScreenController.Init();
        _characterCreationScreen.SetController(_characterCreationScreenController);
        _introScreen.SetController(_characterCreationScreenController);

        _playerDeathScreen = new PlayerDeathScreen(_localizationService);
        Controls.Add(_playerDeathScreen);
        _playerDeathScreen.SetActiveState(false);
    }

    private void StartGameProcess()
    {
        var gameProcessController = new GameProcessController(_gameProcessScreen, _gameProcessScreen, _playerDeathScreen, _progressService, _saveLoadService, _localizationService);
        gameProcessController.SaveAndExit += GoToMainMenu;
        gameProcessController.PlayerDied += GoToMainMenu;
        gameProcessController.Run();
    }

    private void GoToMainMenu(GameProcessController oldController)
    {
        oldController.SaveAndExit -= GoToMainMenu;
        oldController.PlayerDied += GoToMainMenu;

        // _saveLoadService.SaveProgress();

        _startScreenController.Init();
        _characterCreationScreenController.Init();
    }

    private void RegisterServices()
    {
        _localizationService = new SimpleLocalizationService();
        _progressService = new PersistentProgressService();
        _randomService = new RandomService();
        _saveLoadService = new JsonFileSaveLoadService(_progressService);

        Settings.RandomService = _randomService;
    }
}
