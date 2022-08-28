using Mini_RPG_Data.Controllers;
using Mini_RPG_Data.Viewes;
using Mini_RPG_Data.Services.Localization;

namespace Mini_RPG.Screens;

public partial class StartScreen : UserControl, IStartScreenView
{
    private StartScreenController _startScreenController = null!;
    private readonly ILocalizationService _localizationService;

    public StartScreen(ILocalizationService localizationService)
    {
        InitializeComponent();

        _localizationService = localizationService;
        _localizationService.LanguageChanged += SetTexts;
        SetTexts();
    }

    private void SetTexts()
    {
        _button_NewGame.Text = _localizationService.Button_NewGame();
        _button_LoadGame.Text = _localizationService.Button_LoadGame();
        _button_Exit.Text = _localizationService.Button_Exit();
    }

    public void SetActiveState(bool newState) => Visible = newState;

    public void SetController(StartScreenController controller) => _startScreenController = controller;

    private void Button_NewGame_Click(object sender, EventArgs e) => _startScreenController.StartNewGame();

    private void Button_LoadGame_Click(object sender, EventArgs e) => _startScreenController.LoadSavedGame();

    private void Button_Exit_Click(object sender, EventArgs e) => Application.Exit();

}
