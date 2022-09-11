using Mini_RPG_Data.Controllers.Screens;
using Mini_RPG_Data.Map_;
using Mini_RPG_Data.Viewes;
using Mini_RPG_Data.Services.Localization;

namespace Mini_RPG.Screens;

public partial class GameProcessScreen : UserControl, IGameProcessView, ILogView
{
    private readonly ILocalizationService _localizationService;
    private readonly Log _log;
    private GameProcessController _controller = null!;

    public GameProcessScreen(ILocalizationService localizationService)
    {
        InitializeComponent();

        _localizationService = localizationService;
        _localizationService.LanguageChanged += SetTexts;
        SetTexts();

        _log = new Log(_flowLayoutPanel_GameLog, _button_SwitchLogSize);
        _log.FillLog();
    }

    public event Action? SaveAndExitClicked;

    public void SetGameProcessController(GameProcessController gameProcessController) => _controller = gameProcessController;
    public void SetActiveState(bool newState) => Visible = newState;

    public void ShowMap(IMap mapData)
    {
        throw new NotImplementedException();
    }

    private void SetTexts()
    {
        _label_Strength.Text = _localizationService.Label_Strength();
        _label_Dexterity.Text = _localizationService.Label_Dexterity();
        _label_Constitution.Text = _localizationService.Label_Constitution();
        _label_Perception.Text = _localizationService.Label_Perception();
        _label_Charisma.Text = _localizationService.Label_Charisma();

        _button_Rest.Text = _localizationService.Button_Rest();
        _button_Attack.Text = _localizationService.Button_Attack();
        _button_Trader.Text = _localizationService.Button_Trader();
        _button_RestInTown.Text = _localizationService.Button_RestInTown();
        _button_LeaveTown.Text = _localizationService.Button_LeaveTown();

        _menuItem_Menu.Text = _localizationService.Menu();
        _menuItem_SaveAndExit.Text = _localizationService.SaveAndExit();

        _button_SwitchLogSize.Text = _localizationService.Button_Log();

        SetAllToolTips();
    }

    private void SetAllToolTips()
    {
        _label_Strength.ToolTipText = _localizationService.ToolTip_Strength();
        _label_Dexterity.ToolTipText = _localizationService.ToolTip_Dexterity();
        _label_Constitution.ToolTipText = _localizationService.ToolTip_Constitution();
        _label_Perception.ToolTipText = _localizationService.ToolTip_Perception();
        _label_Charisma.ToolTipText = _localizationService.ToolTip_Charisma();
    }

    public void AddLog(string message) => _log.AddLog(message);

    #region Controls Handlers
    private void Button_CharacterProgress_Click(object sender, EventArgs e)
    {
        using var characterProgressForm = new CharacterProgress();
        if (characterProgressForm.ShowDialog() == DialogResult.OK)
        {

        }
    }

    private void Button_Inventory_Click(object sender, EventArgs e)
    {
        using var inventoryForm = new Inventory();
        if (inventoryForm.ShowDialog() == DialogResult.OK)
        {

        }
    }

    private void Button_Trader_Click(object sender, EventArgs e)
    {
        using var traderForm = new Trader();
        if (traderForm.ShowDialog() == DialogResult.OK)
        {

        }
    }

    private void MenuItem_SaveAndExit_Click(object sender, EventArgs e) => SaveAndExitClicked?.Invoke();

    #endregion
}
