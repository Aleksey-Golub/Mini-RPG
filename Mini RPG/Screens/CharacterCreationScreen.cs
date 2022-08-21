namespace Mini_RPG.Screens
{
    public partial class CharacterCreationScreen : UserControl
    {
        private readonly int _maxNameLength = 15;

        public CharacterCreationScreen()
        {
            InitializeComponent();

            SetAllToolTips();
        }

        public event Action? StartGameButtonClicked;

        private void Button_StartGame_Click(object sender, EventArgs e)
        {
            // считать данные
            // создать модель персонажа

            // подписать view на модель
            StartGameButtonClicked?.Invoke();
        }

        private void Button_SelectCharacterAvatar_Click(object sender, EventArgs e)
        {
            using SelectingCharacterAvatar selectAvatarForm = new SelectingCharacterAvatar();
            if (selectAvatarForm.ShowDialog() == DialogResult.OK)
                _button_SelectCharacterAvatar.Image = selectAvatarForm.Avatar;
        }

        private void SetAllToolTips()
        {
            _toolTip.SetToolTip(_label_Race, "% Описание всех рас и их бонусов %");
            _toolTip.SetToolTip(_label_AbilityPoints, "% Доступные для распределения очки характеристик %");
            _toolTip.SetToolTip(_label_Strength, "% Описание СИЛ и за что она отвечает %");
            _toolTip.SetToolTip(_label_Dexterity, "% Описание ЛОВ и за что она отвечает %");
            _toolTip.SetToolTip(_label_Constitution, "% Описание ВЫН и за что она отвечает %");
            _toolTip.SetToolTip(_label_Perception, "% Описание ВОС и за что она отвечает %");
            _toolTip.SetToolTip(_label_Charisma, "% Описание ХАР и за что она отвечает %");
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
