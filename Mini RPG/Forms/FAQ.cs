using Mini_RPG_Data.Services.Localization;
using System.Text;

namespace Mini_RPG;

public partial class FAQ : Form
{
    private readonly ILocalizationService _localizationService;

    public FAQ(ILocalizationService localizationService)
    {
        InitializeComponent();

        _localizationService = localizationService;
        
        SetText();
    }

    private void SetText()
    {
        StringBuilder text = new();
        // FAQ_Controls 
        // FAQ_DiceSystem 
        // FAQ_AbilityModifiers 
        // FAQ_AbilityChecks 
        // FAQ_Abilities 
        // FAQ_Races 
        // FAQ_Health 
        // FAQ_HungerAndThirst 
        // FAQ_ToHitCheck 
        // FAQ_OffensiveAndDefensiveModifiers 
        // FAQ_BodyParts 
        // FAQ_Damage 
        // FAQ_Traps 
        // FAQ_Potions 
        // FAQ_FoodAndDrink 
        // FAQ_Weapons 
        // FAQ_Armor 

        text.Append(_localizationService.GetLocalization("FAQ_Controls") + "\n\n\n");
        text.Append(_localizationService.GetLocalization("FAQ_DiceSystem") + "\n\n\n");
        text.Append(_localizationService.GetLocalization("FAQ_AbilityModifiers") + "\n\n\n");
        text.Append(_localizationService.GetLocalization("FAQ_AbilityChecks") + "\n\n\n");
        text.Append(_localizationService.GetLocalization("FAQ_Abilities") + "\n\n\n");
        text.Append(_localizationService.GetLocalization("FAQ_Races") + "\n\n\n");
        text.Append(_localizationService.GetLocalization("FAQ_Health") + "\n\n\n");
        text.Append(_localizationService.GetLocalization("FAQ_HungerAndThirst") + "\n\n\n");
        text.Append(_localizationService.GetLocalization("FAQ_ToHitCheck") + "\n\n\n");
        text.Append(_localizationService.GetLocalization("FAQ_OffensiveAndDefensiveModifiers") + "\n\n\n");
        text.Append(_localizationService.GetLocalization("FAQ_BodyParts") + "\n\n\n");
        text.Append(_localizationService.GetLocalization("FAQ_Damage") + "\n\n\n");
        text.Append(_localizationService.GetLocalization("FAQ_Traps") + "\n\n\n");
        text.Append(_localizationService.GetLocalization("FAQ_Potions") + "\n\n\n");
        text.Append(_localizationService.GetLocalization("FAQ_FoodAndDrink") + "\n\n\n");
        text.Append(_localizationService.GetLocalization("FAQ_Weapons") + "\n\n\n");
        text.Append(_localizationService.GetLocalization("FAQ_Armor") + "\n\n");

        _label_FAQ.Text = text.ToString();
    }
}
