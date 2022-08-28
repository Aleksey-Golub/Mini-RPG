using Mini_RPG_Data.Controllers;
using Mini_RPG_Data.Viewes;

namespace Mini_RPG.Screens;

public partial class IntroScreen : UserControl, IIntroScreenView
{
    private CharacterCreationScreenController _characterCreationScreenController = null!;

    public IntroScreen()
    {
        InitializeComponent();
    }

    public void SetActiveState(bool newState) => Visible = newState;

    public void SetController(CharacterCreationScreenController controller) => _characterCreationScreenController = controller;

    private void Button_GoToGame_Click(object sender, EventArgs e)
    {
        //GoToGameButtonClicled?.Invoke();
    }
}
