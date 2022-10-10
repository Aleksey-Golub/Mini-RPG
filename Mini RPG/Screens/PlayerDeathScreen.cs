using Mini_RPG_Data.Controllers;
using Mini_RPG_Data.Controllers.Inventory_.Items;
using Mini_RPG_Data.Controllers.Screens;
using Mini_RPG_Data.Services.Localization;
using Mini_RPG_Data.Viewes;
using System.Text;

namespace Mini_RPG.Screens;

public partial class PlayerDeathScreen : UserControl, IPlayerDeathView
{
    private readonly ILocalizationService _localizationService;

    private GameProcessScreenController _controller = null!;

    public PlayerDeathScreen(ILocalizationService localizationService)
    {
        InitializeComponent();

        _localizationService = localizationService;
        _localizationService.LanguageChanged += SetTexts;
        SetTexts();
    }

    public void SetActiveState(bool newState) => Visible = newState;
    public void SetController(GameProcessScreenController controller) => _controller = controller;
    public void DeInit() => _controller = null;
    public void ShowPlayerResult(IPlayer player)
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

        bool wasAdded = false;
        foreach (var item in character.Inventory.EquipmentSlots.Values)
            if (item != null)
            {

                if (character.Inventory.EquipmentSlots[EquipmentSlot.OffHand] == item && character.Inventory.EquipmentSlots[EquipmentSlot.MainHand] == item && wasAdded)
                {
                    continue;
                }
                else if (character.Inventory.EquipmentSlots[EquipmentSlot.OffHand] == item && character.Inventory.EquipmentSlots[EquipmentSlot.MainHand] == item && wasAdded == false)
                {
                    wasAdded = true;
                    playerRes.Append($"{item.LocalizedName}\n");

                }
                else
                {
                    playerRes.Append($"{item.LocalizedName}\n");
                }
            }

        playerRes.Append($"\n{_localizationService.Message_Coins()}: {player.Wallet.Money}");

        _label_PlayerResult.Text = playerRes.ToString();
    }

    private void SetTexts() => _button_GoToMainMenu.Text = _localizationService.Bitton_MainMenu();

    private void Button_GoToMainMenu_Click(object sender, EventArgs e) => _controller.GoToMainMenuAfterDeath();
}
