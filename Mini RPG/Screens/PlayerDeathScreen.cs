using Mini_RPG_Data.Controllers.Screens;
using Mini_RPG_Data.Services.Localization;
using Mini_RPG_Data.Viewes;
using System.Text;

namespace Mini_RPG.Screens;

public partial class PlayerDeathScreen : UserControl, IPlayerDeathView
{
    private readonly ILocalizationService _localizationService;

    private GameProcessController _controller = null!;

    public PlayerDeathScreen(ILocalizationService localizationService)
    {
        InitializeComponent();

        _localizationService = localizationService;
        _localizationService.LanguageChanged += SetTexts;
        SetTexts();
    }

    public void SetActiveState(bool newState) => Visible = newState;
    public void SetController(GameProcessController controller) => _controller = controller;
    public void DeInit() => _controller = null;
    public void ShowPlayerResult(Mini_RPG_Data.Controllers.Player player)
    {
        var character = player.Character;
        StringBuilder playerRes = new StringBuilder();

        playerRes.Append($"{character.Name}\n");
        playerRes.Append($"{_localizationService.Level()}: {character.Level.Value}\n");
        playerRes.Append($"{character.Level.CurrentExperience} / {character.Level.RequiredForNextLevelExperience}\n\n");
        playerRes.Append($"{_localizationService.Label_Abilities()}\n");
        playerRes.Append($"" +
            $"{_localizationService.Label_Strength()}: {character.AllAbilities.Strength.Value}\n" +
            $"{_localizationService.Label_Dexterity()}: {character.AllAbilities.Dexterity.Value}\n" +
            $"{_localizationService.Label_Constitution()}: {character.AllAbilities.Constitution.Value}\n" +
            $"{_localizationService.Label_Perception()}: {character.AllAbilities.Perception.Value}\n" +
            $"{_localizationService.Label_Charisma()}: {character.AllAbilities.Charisma.Value}\n\n");
        playerRes.Append($"{_localizationService.Label_Equipment()}\n");
        // 1
        // 2

        _label_PlayerResult.Text = playerRes.ToString();
    }

    private void SetTexts() => _button_GoToMainMenu.Text = _localizationService.Bitton_MainMenu();
    private void Button_GoToMainMenu_Click(object sender, EventArgs e) => _controller.GoToMainMenuAfterDeath();
}
