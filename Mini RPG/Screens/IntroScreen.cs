using Mini_RPG_Data.Viewes;

namespace Mini_RPG.Screens;

public partial class IntroScreen : UserControl, IIntroScreenView
{
    public IntroScreen()
    {
        InitializeComponent();
    }

    public event Action? GoToGameButtonClicled;

    public void SetActiveState(bool newState) => Visible = newState;

    private void Button_GoToGame_Click(object sender, EventArgs e) => GoToGameButtonClicled?.Invoke();
}
