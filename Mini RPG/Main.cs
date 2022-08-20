namespace Mini_RPG;

public partial class Main : Form
{
    // ability points
    // Dexterity Constitution Perception Charisma
    public Main()
    {
        InitializeComponent();

        SetAllToolTips();
    }

    #region Start Screen
    private void Button_Exit_Click(object sender, EventArgs e)
    {
        Application.Exit();
    }

    private void Button_NewGame_Click(object sender, EventArgs e)
    {
        _panel_StartScreen.Hide();
        _panel_CharacterCreation.Show();
    }

    private void Button_LoadGame_Click(object sender, EventArgs e)
    {
        // загрузка сохранения
    }
    #endregion

    #region Character creation screen
    private void Button_StartGame_Click(object sender, EventArgs e)
    {
        // считать данные
        // создать модель персонажа

        _panel_CharacterCreation.Hide();
        _panel_Intro.Show();
        // подписать view на модель
    }

    private void Button_SelectCharacterAvatar_Click(object sender, EventArgs e)
    {
        using SelectingCharacterAvatar selectAvatarForm = new SelectingCharacterAvatar();
        if (selectAvatarForm.ShowDialog() == DialogResult.OK)
            _button_SelectCharacterAvatar.Image = selectAvatarForm.Avatar;
    }
    #endregion

    #region Intro
    private void Button_GoToGame_Click(object sender, EventArgs e)
    {
        _panel_Intro.Hide();
        _panel_GameProcess.Show();
    }
    #endregion
    
    #region Game Process

    #endregion

    private void SetAllToolTips()
    {
        _toolTip.SetToolTip(_label_Race, "Описание всех рас и их бонусов");
        _toolTip.SetToolTip(_label_AbilityPoints, "Доступные для распределения очки характеристик");
        _toolTip.SetToolTip(_label_Strength, "Описание СИЛ и за что она отвечает");
        _toolTip.SetToolTip(_label_Dexterity, "Описание ЛОВ и за что она отвечает");
        _toolTip.SetToolTip(_label_Constitution, "Описание ВЫН и за что она отвечает");
        _toolTip.SetToolTip(_label_Perception, "Описание ВЫН и за что она отвечает");
        _toolTip.SetToolTip(_label_Charisma, "Описание ХАР и за что она отвечает");
    }

}
