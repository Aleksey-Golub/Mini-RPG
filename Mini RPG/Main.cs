using Mini_RPG.Screens;
using Mini_RPG_Data.Controllers;
using Mini_RPG_Data.Services.Localization;
using Mini_RPG_Data.Viewes;

namespace Mini_RPG;

public partial class Main : Form
{
    private readonly StartScreen _startScreen;
    private readonly CharacterCreationScreen _characterCreationScreen;
    private readonly IntroScreen _introScreen;
    private readonly GameProcessScreen _gameProcess;
    
    private readonly SimpleLocalizationService _localizationService;

    //private StartScreenController _startScreenController = null!;

    public Main()
    {
        InitializeComponent();

        _localizationService = new SimpleLocalizationService();

        _startScreen = new StartScreen(_localizationService);
        Controls.Add(_startScreen);

        _characterCreationScreen = new CharacterCreationScreen(_localizationService);
        Controls.Add(_characterCreationScreen);
        _characterCreationScreen.SetActiveState(false);

        _introScreen = new IntroScreen();
        Controls.Add(_introScreen);
        _introScreen.SetActiveState(false);

        _gameProcess = new GameProcessScreen();
        Controls.Add(_gameProcess);
        _gameProcess.SetActiveState(false);
        //_gameProcess.SaveAndExitClicked += OnGameProcess_SaveAndExitClicked;

        _startScreen.SetController(new StartScreenController(_startScreen, _characterCreationScreen));
        var characterCreationScreenController= new CharacterCreationScreenController(_characterCreationScreen, _introScreen);
        _characterCreationScreen.SetController(characterCreationScreenController);
        _introScreen.SetController(characterCreationScreenController);
    }

    private void OnGameProcess_SaveAndExitClicked()
    {
        // сохранить игру

        // выйти в главное меню
        _gameProcess.Hide();
        _startScreen.Show();
    }

    private void OnIntroScreen_GoToGameButtonClicked()
    {
        _introScreen.Hide();
        _gameProcess.Show();
    }
}
