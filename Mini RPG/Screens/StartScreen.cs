using Mini_RPG_Data.Viewes;

namespace Mini_RPG.Screens;

public partial class StartScreen : UserControl, IStartScreenView
{
    public StartScreen()
    {
        InitializeComponent();
    }

    public event Action? NewGameButtonClicked;
    public event Action? LoadGameButtonClicked;
    public event Action? ExitButtonClicked;

    private void Button_NewGame_Click(object sender, EventArgs e)
    {
        NewGameButtonClicked?.Invoke();
    }

    private void Button_Exit_Click(object sender, EventArgs e)
    {
        ExitButtonClicked?.Invoke();//Application.Exit();
    }
    
    private void Button_LoadGame_Click(object sender, EventArgs e)
    {
        LoadGameButtonClicked?.Invoke();
    }

    public void SetActiveState(bool newState) => Visible = newState;
}
