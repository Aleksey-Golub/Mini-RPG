using Mini_RPG.Screens;

namespace Mini_RPG;

public partial class Main : Form
{
    private readonly StartScreen _startScreen;
    private readonly CharacterCreationScreen _characterCreationScreen;
    private readonly IntroScreen _introScreen;
    private readonly GameProcessScreen _gameProcess;

    public Main()
    {
        InitializeComponent();

        _startScreen = new StartScreen();
        Controls.Add(_startScreen);
        _startScreen.NewGameButtonClicked += OnStartScreen_NewGameButtonClicked;
        _startScreen.LoadGameButtonClicked += OnStartScreen_LoadGameButtonClicked;

        _characterCreationScreen = new CharacterCreationScreen();
        Controls.Add(_characterCreationScreen);
        _characterCreationScreen.Hide();
        _characterCreationScreen.StartGameButtonClicked += OnCharacterCreationScreen_StartGameButtonClicked;

        _introScreen = new IntroScreen();
        Controls.Add(_introScreen);
        _introScreen.Hide();
        _introScreen.GoToGameButtonClicled += OnIntroScreen_GoToGameButtonClicled;

        _gameProcess = new GameProcessScreen();
        Controls.Add(_gameProcess);
        _gameProcess.Hide();
        _gameProcess.SaveAndExitClicked += OnGameProcess_SaveAndExitClicked;

        SetAllToolTips();
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

    private void OnStartScreen_LoadGameButtonClicked()
    {
        // организовать загрузку сохраненных игр
    }

    private void OnStartScreen_NewGameButtonClicked()
    {
        _startScreen.Hide();
        _characterCreationScreen.Show();
    }

    private void SetAllToolTips()
    {
        //_toolTip.SetToolTip(_label_Race, "Описание всех рас и их бонусов");
        //_toolTip.SetToolTip(_label_AbilityPoints, "Доступные для распределения очки характеристик");
        //_toolTip.SetToolTip(_label_Strength, "Описание СИЛ и за что она отвечает");
        //_toolTip.SetToolTip(_label_Dexterity, "Описание ЛОВ и за что она отвечает");
        //_toolTip.SetToolTip(_label_Constitution, "Описание ВЫН и за что она отвечает");
        //_toolTip.SetToolTip(_label_Perception, "Описание ВЫН и за что она отвечает");
        //_toolTip.SetToolTip(_label_Charisma, "Описание ХАР и за что она отвечает");
    }

}
