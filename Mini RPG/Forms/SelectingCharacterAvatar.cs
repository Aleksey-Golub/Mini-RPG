using Mini_RPG_Data;

namespace Mini_RPG;

public partial class SelectingCharacterAvatar : Form
{
    public SelectingCharacterAvatar()
    {
        InitializeComponent();

        AvatarPath = GameRules.DefaultAvatarPath;
        int startWidth = 20;
        int pictureWidth = 260;
        // ширина 280 + 260 для каждой новой картинки
        // 2шт 280 + 260 = 540

        startWidth = SpawnAvatars(startWidth, pictureWidth);
        Size = new Size(6 * 260 + 30, 300 * 2 + 40);
    }

    public string AvatarPath { get; internal set; } = null!;

    private int SpawnAvatars(int startWidth, int pictureWidth)
    {
        var avatarsPaths = new List<string>();
        foreach (var path in Directory.GetFiles(GameRules.AvatarsDirectory))
            avatarsPaths.Add(path);
        
        for (int i = 0; i < avatarsPaths.Count; i++)
        {
            var picture = new PictureBox();
            picture.Size = new Size(250, 300);
            picture.ImageLocation = avatarsPaths[i];
            _flowLayoutPanel_Avatars.Controls.Add(picture);
            startWidth += pictureWidth;

            picture.Click += OnNewAvaratButtolClick;
        }

        return startWidth;
    }

    private void OnNewAvaratButtolClick(object? sender, EventArgs e)
    {
        var picture = sender as PictureBox;
        picture.Click -= OnNewAvaratButtolClick;
        AvatarPath = picture.ImageLocation;

        DialogResult = DialogResult.OK;
    }
}
