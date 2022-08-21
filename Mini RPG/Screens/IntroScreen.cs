namespace Mini_RPG.Screens;

public partial class IntroScreen : UserControl
{
    public IntroScreen()
    {
        InitializeComponent();
    }

    public event Action? GoToGameButtonClicled;

    private void Button_GoToGame_Click(object sender, EventArgs e)
    {
        GoToGameButtonClicled?.Invoke();
    }
}
