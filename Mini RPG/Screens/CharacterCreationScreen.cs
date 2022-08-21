namespace Mini_RPG.Screens
{
    public partial class CharacterCreationScreen : UserControl
    {
        public CharacterCreationScreen()
        {
            InitializeComponent();
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
    }
}
