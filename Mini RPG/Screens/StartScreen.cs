using Mini_RPG_Data.Viewes;
using Mini_RPG_Data.Services.Localization;
using Mini_RPG_Data.Services.AppSettings;
using Mini_RPG_Data.Controllers.Screens;

namespace Mini_RPG.Screens;

public partial class StartScreen : UserControl, IStartScreenView
{
    private StartScreenController _controller = null!;
    private readonly ILocalizationService _localizationService;
    private readonly IAppSettingsService _appSettingsService;

    public StartScreen(ILocalizationService localizationService, IAppSettingsService appSettingsService)
    {
        InitializeComponent();

        _appSettingsService = appSettingsService;
        _localizationService = localizationService;
        _localizationService.LanguageChanged += SetTexts;

        string[] availableLanguages = _localizationService.AvailableLanguages.ToArray();
        _comboBox_Language.Items.AddRange(availableLanguages);
        _comboBox_Language.SelectedItem = _appSettingsService.GetCurrentLauguage();

        SetTexts();
    }

    private void SetTexts()
    {
        _button_NewGame.Text = _localizationService.GetLocalization("GUI_Button_NewGame");
        _button_LoadGame.Text = _localizationService.GetLocalization("GUI_Button_LoadGame");
        _button_Exit.Text = _localizationService.GetLocalization("GUI_Button_Exit");
        _button_Help.Text = _localizationService.GetLocalization("GUI_Button_Help");
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

    #region Controls Event Handlers
    private void Button_NewGame_Click(object sender, EventArgs e) => _controller.StartNewGame();
    private void Button_LoadGame_Click(object sender, EventArgs e) => _controller.ShowSavedGames();
    private void Button_Exit_Click(object sender, EventArgs e) => Application.Exit();

    private void Button_Help_Click(object sender, EventArgs e)
    {
        using var mapForm = new FAQ(_localizationService);
        if (mapForm.ShowDialog() == DialogResult.OK)
        { }
    }

    private void СomboBox_Language_SelectedIndexChanged(object sender, EventArgs e)
    {
        string selectedLanguage = (sender as ComboBox).SelectedItem as string;
        _localizationService.SetCurrentLanguage(selectedLanguage);
    }
    #endregion
}
