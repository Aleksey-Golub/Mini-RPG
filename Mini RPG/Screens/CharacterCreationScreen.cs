using Mini_RPG_Data.Controllers;
using Mini_RPG_Data.Services.Localization;
using Mini_RPG_Data.Viewes;

namespace Mini_RPG.Screens
{
    public partial class CharacterCreationScreen : UserControl, ICharacterCreationScreenView
    {
        private CharacterCreationScreenController _controller = null!;
        private readonly int _maxNameLength = 15;

        private readonly ILocalizationService _localizationService;

        public CharacterCreationScreen(ILocalizationService localizationService)
        {
            InitializeComponent();

            _button_SelectCharacterAvatar.Image = Properties.Resources.Avatar_1;

            _localizationService = localizationService;
            _localizationService.LanguageChanged += SetTexts;
            SetTexts();

            string[] races = new string[] { _localizationService.Human(), _localizationService.Elf(), _localizationService.Dwarf()};
            _comboBox_Race.Items.AddRange(races);
            _comboBox_Race.SelectedIndex = 0;
            _comboBox_Race.SelectedIndexChanged += _comboBox_Race_SelectedIndexChanged;
        }

        private void _comboBox_Race_SelectedIndexChanged(object? sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public void SetActiveState(bool newState) => Visible = newState;

        public void SetController(CharacterCreationScreenController controller) => _controller = controller;
        
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

        private void Button_StartGame_Click(object sender, EventArgs e)
        {
            // считать данные
            // создать модель персонажа

            // подписать view на модель
        }

        private void Button_SelectCharacterAvatar_Click(object sender, EventArgs e)
        {
            using SelectingCharacterAvatar selectAvatarForm = new SelectingCharacterAvatar();
            if (selectAvatarForm.ShowDialog() == DialogResult.OK)
                _button_SelectCharacterAvatar.Image = selectAvatarForm.Avatar;
        }

        private void TextBox_Name_TextChanged(object sender, EventArgs e) => ValidateName();

        private void ValidateName()
        {
            if (_textBox_Name.Text.Length > _maxNameLength)
            {
                string name = _textBox_Name.Text.Substring(0, _maxNameLength);
                _textBox_Name.Text = name;
                _textBox_Name.SelectionStart = _textBox_Name.Text.Length;
            }
        }
    }
}
