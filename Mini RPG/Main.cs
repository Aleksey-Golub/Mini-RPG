using Mini_RPG.Screens;
using Mini_RPG_Data.Controllers;
using Mini_RPG_Data.Viewes;

namespace Mini_RPG;

public partial class Main : Form, IStartScreenView, ICharacterCreationScreenView
{
    private readonly StartScreen _startScreen;
    private readonly CharacterCreationScreen _characterCreationScreen;
    private readonly IntroScreen _introScreen;
    private readonly GameProcessScreen _gameProcess;

    private StartScreenController _startScreenController = null!;

    public Main()
    {
        InitializeComponent();

        _startScreen = new StartScreen();
        Controls.Add(_startScreen);
        _startScreen.NewGameButtonClicked += OnStartScreen_NewGameButtonClicked;
        _startScreen.LoadGameButtonClicked += OnStartScreen_LoadGameButtonClicked;
        _startScreen.ExitButtonClicked += OnStartScreen_ExitButtonClicked;

        _characterCreationScreen = new CharacterCreationScreen();
        Controls.Add(_characterCreationScreen);
        _characterCreationScreen.SetActiveState(false);
        _characterCreationScreen.StartGameButtonClicked += OnCharacterCreationScreen_StartGameButtonClicked;

        _introScreen = new IntroScreen();
        Controls.Add(_introScreen);
        _introScreen.SetActiveState(false);
        _introScreen.GoToGameButtonClicled += OnIntroScreen_GoToGameButtonClicled;

        _gameProcess = new GameProcessScreen();
        Controls.Add(_gameProcess);
        _gameProcess.SetActiveState(false);
        _gameProcess.SaveAndExitClicked += OnGameProcess_SaveAndExitClicked;

        SetControllers(new StartScreenController(this, this));
    }

    private void SetControllers(StartScreenController startScreenController)
    {
        _startScreenController = startScreenController;

    }

    private void OnGameProcess_SaveAndExitClicked()
    {
        // сохранить игру

        // выйти в главное меню
        _gameProcess.Hide();
        _startScreen.Show();
    }

    private void OnIntroScreen_GoToGameButtonClicled()
    {
        _introScreen.Hide();
        _gameProcess.Show();
    }

    private void OnCharacterCreationScreen_StartGameButtonClicked()
    {
        // получить данные созданного персонажа и отдать в контроллер
        _characterCreationScreen.Hide();
        _introScreen.Show();
    }

    #region StartScrenn
    private void OnStartScreen_ExitButtonClicked() => Application.Exit();

    private void OnStartScreen_LoadGameButtonClicked() => _startScreenController.LoadSavedGame();

    private void OnStartScreen_NewGameButtonClicked() => _startScreenController.StartNewGame();
    #endregion

    void ICharacterCreationScreenView.SetActiveState(bool newState) => _characterCreationScreen.SetActiveState(newState);

    void IStartScreenView.SetActiveState(bool newState) => _startScreen.SetActiveState(newState);
}
