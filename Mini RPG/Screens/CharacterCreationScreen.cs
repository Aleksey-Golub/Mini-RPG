using Mini_RPG_Data.Controllers;
using Mini_RPG_Data.Services.Localization;
using Mini_RPG_Data.Viewes;
using Mini_RPG_Data.Character_;

namespace Mini_RPG.Screens
{
    public partial class CharacterCreationScreen : UserControl, ICharacterCreationScreenView
    {
        private CharacterCreationScreenController _controller = null!;
        private ICharacterData _characterData;

        private readonly ILocalizationService _localizationService;
        private readonly int _maxNameLength = 15;

        public CharacterCreationScreen(ILocalizationService localizationService)
        {
            InitializeComponent();

            _localizationService = localizationService;
            _localizationService.LanguageChanged += SetTexts;
            SetTexts();

            _button_SelectCharacterAvatar.Image = Properties.Resources.Avatar_1;

            string[] races = new string[]
            {
                _localizationService.Human(),   // 0
                _localizationService.Elf(),     // 1
                _localizationService.Dwarf()    // 2
            };
            _comboBox_Race.Items.AddRange(races);
            //_comboBox_Race.SelectedIndex = 0;
        }

        public void SetActiveState(bool newState) => Visible = newState;

        public void SetController(CharacterCreationScreenController controller)
        {
            _controller = controller;
            _comboBox_Race.SelectedIndex = 0;
        }

        public void SetModel(ICharacterData characterData)
        {
            _characterData = characterData;
            _characterData.Changed += OnCharacterDataChanged;
        }

        private void OnCharacterDataChanged(ICharacterData data)
        {
            _label_StrengthPoints.Text = data.Abilities.Strength.Value.ToString();
            _label_DexterityPoints.Text = data.Abilities.Dexterity.Value.ToString();
            _label_ConstitutionPoints.Text = data.Abilities.Constitution.Value.ToString();
            _label_PerceptionPoints.Text = data.Abilities.Perception.Value.ToString();
            _label_CharismaPoints.Text = data.Abilities.Charisma.Value.ToString();
            _label_AbilityPointsCount.Text = data.Abilities.AbilityPoints.ToString();

            // TO DO activate/deactivate buttons

        }

        private void ValidateName()
        {
            if (_textBox_Name.Text.Length > _maxNameLength)
            {
                string name = _textBox_Name.Text.Substring(0, _maxNameLength);
                _textBox_Name.Text = name;
                _textBox_Name.SelectionStart = _textBox_Name.Text.Length;
            }
        }

        private void SetTexts()
        {
            _button_StartGame.Text = _localizationService.Button_StartGame();
            _label_AbilityPoints.Text = _localizationService.Label_AbilityPoints();
            _label_Charisma.Text = _localizationService.Label_Charisma();
            _label_Constitution.Text = _localizationService.Label_Constitution();
            _label_Dexterity.Text = _localizationService.Label_Dexterity();
            _label_Perception.Text = _localizationService.Label_Perception();
            _label_Race.Text = _localizationService.Label_Race();
            _label_Strength.Text = _localizationService.Label_Strength();
            _textBox_Name.Text = _localizationService.TextBox_Name();

            SetAllToolTips();
        }

        private void SetAllToolTips()
        {
            _toolTip.SetToolTip(_label_Race, _localizationService.ToolTip_Race());
            _toolTip.SetToolTip(_label_AbilityPoints, _localizationService.ToolTip_AbilityPoints());
            _toolTip.SetToolTip(_label_Strength, _localizationService.ToolTip_Strength());
            _toolTip.SetToolTip(_label_Dexterity, _localizationService.ToolTip_Dexterity());
            _toolTip.SetToolTip(_label_Constitution, _localizationService.ToolTip_Constitution());
            _toolTip.SetToolTip(_label_Perception, _localizationService.ToolTip_Perception());
            _toolTip.SetToolTip(_label_Charisma, _localizationService.ToolTip_Charisma());
        }

        #region Controls Event Handlers
        private void ComboBox_Race_SelectedIndexChanged(object? sender, EventArgs e)
        {
            int selectedIndex = (sender as ComboBox).SelectedIndex;
            var newRace = Get();
            _controller.SetRace(newRace);

            CharacterRace Get()
            {
                return selectedIndex switch
                {
                    0 => CharacterRace.Human,
                    1 => CharacterRace.Elf,
                    2 => CharacterRace.Dwarf,
                    _ => throw new NotImplementedException($"CharacterRace not implemented for {selectedIndex}"),
                };
            }
        }

        private void Button_StartGame_Click(object sender, EventArgs e) =>
            _controller.StartGame(_button_SelectCharacterAvatar.Image.ToByteArray(), _textBox_Name.Text);

        private void Button_SelectCharacterAvatar_Click(object sender, EventArgs e)
        {
            using SelectingCharacterAvatar selectAvatarForm = new SelectingCharacterAvatar();
            if (selectAvatarForm.ShowDialog() == DialogResult.OK)
                _button_SelectCharacterAvatar.Image = selectAvatarForm.Avatar;
        }

        private void TextBox_Name_TextChanged(object sender, EventArgs e) => ValidateName();
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
}