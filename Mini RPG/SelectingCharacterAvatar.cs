namespace Mini_RPG;

public partial class SelectingCharacterAvatar : Form
{
    public SelectingCharacterAvatar()
    {
        InitializeComponent();

        Avatar = Image.FromFile(@"D:\Programming\Ресурсы для игр\мини РПГ_макеты\Аватар персонажа_1.png");

        // ширина 280 + 260 для каждой новой картинки

        // получитьт количество автаров в ресурсах игры
        // создать кнопки-картинки по количеству аватаров и добавить им картинки
        // добавить их дочерними к Panel формы
        // назначить им в button_Click установку своего Image в свойство Avatar Result.Ok

        string[] avatarPath =
        {
            @"D:\Programming\Ресурсы для игр\мини РПГ_макеты\Аватар персонажа_3.png",
            @"D:\Programming\Ресурсы для игр\мини РПГ_макеты\Аватар персонажа_2.png"
        };
        for (int i = 0; i < 2; i++)
        {

            Button btn = new Button();
            btn.Size = new Size(250, 300);
            //btn.Text = $"avatar{i}";
            btn.Image = Image.FromFile(avatarPath[i]);
            btn.DialogResult = DialogResult.OK;
            _flowLayoutPanel_Avatars.Controls.Add(btn);

            btn.Click += OnNewAvaratButtolClick;
        }
    }

    private void OnNewAvaratButtolClick(object? sender, EventArgs e)
    {
        var btn = sender as Button;
        btn.Click -= OnNewAvaratButtolClick;
        Avatar = btn.Image;
    }

    public Image Avatar { get; internal set; }
}
