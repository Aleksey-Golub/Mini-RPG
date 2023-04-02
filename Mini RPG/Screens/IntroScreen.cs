using Mini_RPG_Data.Controllers.Screens;
using Mini_RPG_Data.Viewes;
using Mini_RPG_Data.Services.Localization;

namespace Mini_RPG.Screens;

public partial class IntroScreen : UserControl, IIntroScreenView
{
    private readonly ILocalizationService _localizationService;
    private CharacterCreationScreenController _controller = null!;

    public IntroScreen(ILocalizationService localizationService)
    {
        InitializeComponent();

        _localizationService = localizationService;
        _localizationService.LanguageChanged += SetTexts;
        SetTexts();
    }

    public void SetActiveState(bool newState) => Visible = newState;

    public void SetController(CharacterCreationScreenController controller) => _controller = controller;

    private void Button_GoToGame_Click(object sender, EventArgs e) => _controller.GoToGame();

    private void SetTexts()
    {
        _button_GoToGame.Text = _localizationService.GetLocalization("GUI_Button_GoToGame");
        _label_Intro.Text = _localizationService.GetLocalization("GUI_Label_Intro");
    }
}
