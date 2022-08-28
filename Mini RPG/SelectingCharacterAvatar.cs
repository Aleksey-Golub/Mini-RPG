namespace Mini_RPG;

public partial class SelectingCharacterAvatar : Form
{
    public SelectingCharacterAvatar()
    {
        InitializeComponent();

        Avatar = Properties.Resources.Avatar_1;//Image.FromFile(@"D:\Programming\Ресурсы для игр\мини РПГ_макеты\Аватар персонажа_1.png");
        int startWidth = 20;
        int btnWidth = 260;
        // ширина 280 + 260 для каждой новой картинки
        // 2шт 280 + 260 = 540

        startWidth = SpawnAvatars(startWidth, btnWidth);
        Size = new Size(startWidth, Size.Height);
    }

    public Image Avatar { get; internal set; }

    private int SpawnAvatars(int startWidth, int btnWidth)
    {
        //string[] avatarPath =
        //{
        //    @"D:\Programming\Ресурсы для игр\мини РПГ_макеты\Аватар персонажа_3.png",
        //    @"D:\Programming\Ресурсы для игр\мини РПГ_макеты\Аватар персонажа_2.png"
        //};
        Image[] avatars =
        {
            Properties.Resources.Avatar_1,
            Properties.Resources.Avatar_2,
            Properties.Resources.Avatar_3,
            Properties.Resources.Avatar_4,
        };
        for (int i = 0; i < avatars.Length; i++)
        {
            Button btn = new Button();
            btn.Size = new Size(250, 300);
            //btn.Image = Image.FromFile(avatarPath[i]);
            btn.Image = avatars[i];
            btn.DialogResult = DialogResult.OK;
            _flowLayoutPanel_Avatars.Controls.Add(btn);
            startWidth += btnWidth;

            btn.Click += OnNewAvaratButtolClick;
        }

        return startWidth;
    }

    private void OnNewAvaratButtolClick(object? sender, EventArgs e)
    {
        var btn = sender as Button;
        btn.Click -= OnNewAvaratButtolClick;
        Avatar = btn.Image;
    }
}
