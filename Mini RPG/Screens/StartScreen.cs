namespace Mini_RPG.Screens;

public partial class StartScreen : UserControl
{
    public StartScreen()
    {
        InitializeComponent();
    }

    public event Action? NewGameButtonClicked;
    public event Action? LoadGameButtonClicked;

    private void Button_NewGame_Click(object sender, EventArgs e)
    {
        NewGameButtonClicked?.Invoke();
    }

    private void Button_Exit_Click(object sender, EventArgs e)
    {
        Application.Exit();
    }
    
    private void Button_LoadGame_Click(object sender, EventArgs e)
    {
        LoadGameButtonClicked?.Invoke();
    }
}
