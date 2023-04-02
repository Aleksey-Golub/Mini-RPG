using Mini_RPG_Data.Viewes;
using Mini_RPG_Data.Services.Localization;
using Mini_RPG_Data.Controllers.Screens;

namespace Mini_RPG.Screens;

public partial class StartScreen : UserControl, IStartScreenView
{
    private StartScreenController _controller = null!;
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
        _button_NewGame.Text = _localizationService.GetLocalization("GUI_Button_NewGame");
        _button_LoadGame.Text = _localizationService.GetLocalization("GUI_Button_LoadGame");
        _button_Exit.Text = _localizationService.GetLocalization("GUI_Button_Exit");
    }

    public void SetActiveState(bool newState) => Visible = newState;
    public void SetController(StartScreenController controller) => _controller = controller;
    public void SetLoadButtonState(bool state) => _button_LoadGame.Enabled = state;

    public void ShowSaves(List<StartScreenController.SaveDTO> savesDTO)
    {
        if(savesDTO == null)
            throw new ArgumentNullException(nameof(savesDTO));

        using SelectingLoadGame selectLoadGamesForm = new SelectingLoadGame(savesDTO, _localizationService);
        if (selectLoadGamesForm.ShowDialog() == DialogResult.OK)
            _controller.LoadGame(selectLoadGamesForm.SelectedSave);
    }

    private void Button_NewGame_Click(object sender, EventArgs e) => _controller.StartNewGame();
    private void Button_LoadGame_Click(object sender, EventArgs e) => _controller.ShowSavedGames();
    private void Button_Exit_Click(object sender, EventArgs e) => Application.Exit();
}
