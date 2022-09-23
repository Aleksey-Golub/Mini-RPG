using Mini_RPG_Data.Controllers.Character_;
using Mini_RPG_Data.Controllers.Character_.Abilities_;
using Mini_RPG_Data.Controllers.Screens;
using Mini_RPG_Data.Services.Localization;

namespace Mini_RPG;

public partial class CharacterProgress : Form
{
    private readonly ILocalizationService _localizationService;
    private readonly ICharacter _character;

    private readonly CharacterProgressController _controller;

    public CharacterProgress(ILocalizationService localizationService, ICharacter character)
    {
        InitializeComponent();

        _localizationService = localizationService;
        _character = character;
        _character.Changed += OnCharacterDataChanged;

        _controller = new CharacterProgressController(_character as Character);

        ShowCharacterStats();

        SetTexts();
        SetAllToolTips();
    }

    private void ShowCharacterStats()
    {
        _label_CharacterName.Text = _character.Name;
        _pictureBox_CharacterAvatar.ImageLocation = _character.AvatarPath;
        _label_CharacterRace.Text = _localizationService.RaceName(_character.Race);
        _label_LevelAndExperience.Text = $"{_character.Level.Value} {_localizationService.Level()}: {_character.Level.CurrentExperience} / {_character.Level.RequiredForNextLevelExperience}";

        OnCharacterDataChanged(_character);
    }
    private void OnCharacterDataChanged(ICharacter character)
    {
        _label_AbilityPointsCount.Text = character.AllAbilities.AbilityPoints.ToString();

        _label_StrengthPoints.Text = character.AllAbilities.Strength.Value.ToString();
        _label_DexterityPoints.Text = character.AllAbilities.Dexterity.Value.ToString();
        _label_ConstitutionPoints.Text = character.AllAbilities.Constitution.Value.ToString();
        _label_PerceptionPoints.Text = character.AllAbilities.Perception.Value.ToString();
        _label_CharismaPoints.Text = character.AllAbilities.Charisma.Value.ToString();

        // TO DO activate/deactivate buttons
    }

    private void SetTexts()
    {
        _button_CloseCharacterProgress.Text = _localizationService.Button_Close();

        _label_AbilityPoints.Text = _localizationService.Label_AbilityPoints();
        _label_Charisma.Text = _localizationService.Label_Charisma();
        _label_Constitution.Text = _localizationService.Label_Constitution();
        _label_Dexterity.Text = _localizationService.Label_Dexterity();
        _label_Perception.Text = _localizationService.Label_Perception();
        _label_Strength.Text = _localizationService.Label_Strength();

        SetAllToolTips();
    }

    private void SetAllToolTips()
    {
        _toolTip.SetToolTip(_label_AbilityPoints, _localizationService.ToolTip_AbilityPoints());
        _toolTip.SetToolTip(_label_Strength, _localizationService.ToolTip_Strength());
        _toolTip.SetToolTip(_label_Dexterity, _localizationService.ToolTip_Dexterity());
        _toolTip.SetToolTip(_label_Constitution, _localizationService.ToolTip_Constitution());
        _toolTip.SetToolTip(_label_Perception, _localizationService.ToolTip_Perception());
        _toolTip.SetToolTip(_label_Charisma, _localizationService.ToolTip_Charisma());
    }

    #region Controls Events Handlers
    private void Button_CloseCharacterProgress_Click(object sender, EventArgs e)
    {
        _character.Changed -= OnCharacterDataChanged;
        DialogResult = DialogResult.OK;
    }

    private void Button_DecreaseStrength_Click(object sender, EventArgs e) => _controller.DecreaseAbility(AbilityType.Strength);
    private void Button_IncreaseStrength_Click(object sender, EventArgs e) => _controller.IncreaseAbility(AbilityType.Strength);
    private void Button_DecreaseDexterity_Click(object sender, EventArgs e) => _controller.DecreaseAbility(AbilityType.Dexterity);
    private void Button_IncreaseDexterity_Click(object sender, EventArgs e) => _controller.IncreaseAbility(AbilityType.Dexterity);
    private void Button_DecreaseConstitution_Click(object sender, EventArgs e) => _controller.DecreaseAbility(AbilityType.Constitution);
    private void Button_IncreaseConstitution_Click(object sender, EventArgs e) => _controller.IncreaseAbility(AbilityType.Constitution);
    private void Button_DecreasePerception_Click(object sender, EventArgs e) => _controller.DecreaseAbility(AbilityType.Perception);
    private void Button_IncreasePerception_Click(object sender, EventArgs e) => _controller.IncreaseAbility(AbilityType.Perception);
    private void Button_DecreaseCharisma_Click(object sender, EventArgs e) => _controller.DecreaseAbility(AbilityType.Charisma);
    private void Button_IncreaseCharisma_Click(object sender, EventArgs e) => _controller.IncreaseAbility(AbilityType.Charisma);
    #endregion
}
