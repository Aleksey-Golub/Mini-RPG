using Mini_RPG_Data.Controllers.Screens;
using Mini_RPG_Data.Map_;
using Mini_RPG_Data.Viewes;
using Mini_RPG_Data.Services.Localization;
using Mini_RPG_Data.Controllers.Character_;
using Mini_RPG_Data.Controllers;

namespace Mini_RPG.Screens;

public partial class GameProcessScreen : UserControl, IGameProcessView, ILogView
{
    private readonly ILocalizationService _localizationService;
    private readonly Log _log;
    private GameProcessController _controller = null!;

    private ICharacter _character;
    private IWallet _wallet;
    //private IMap _map;

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

    public void Init(ICharacter character, IWallet wallet, IMap map)
    {
        _character = character;
        _wallet = wallet;
        //_map = map;

        _character.AllAbilities.Changed += OnCharacterAbilitiesChanged;
        _character.Health.Changed += OnCharacterHealthChanged;
        _wallet.MoneyChanged += OnMoneyChanged;

        OnCharacterAbilitiesChanged();
        OnCharacterHealthChanged();
        OnMoneyChanged(_wallet.Money);
    }

    public void SetGameProcessController(GameProcessController gameProcessController) => _controller = gameProcessController;
    public void SetActiveState(bool newState) => Visible = newState;
    public void AddLog(string message) => _log.AddLog(message);

    public void ShowMap(IMap mapData)
    {
        throw new NotImplementedException();
    }

    private void OnCharacterAbilitiesChanged()
    {
        var allAbilities = _character.AllAbilities;

        _label_StrengthPoints.Text = allAbilities.Strength.Value.ToString();
        _label_DexterityPoints.Text = allAbilities.Dexterity.Value.ToString();
        _label_ConstitutionPoints.Text = allAbilities.Constitution.Value.ToString();
        _label_PerceptionPoints.Text = allAbilities.Perception.Value.ToString();
        _label_CharismaPoints.Text = allAbilities.Charisma.Value.ToString();

        _label_StrengthPoints.ToolTipText = allAbilities.Strength.Bonus.ToString();
        _label_DexterityPoints.ToolTipText = allAbilities.Dexterity.Bonus.ToString();
        _label_ConstitutionPoints.ToolTipText = allAbilities.Constitution.Bonus.ToString();
        _label_PerceptionPoints.ToolTipText = allAbilities.Perception.Bonus.ToString();
        _label_CharismaPoints.ToolTipText = allAbilities.Charisma.Bonus.ToString();
    }

    private void OnCharacterHealthChanged() => _label_Health.Text = $"{_character.Health.CurrentHealth}/{_character.Health.MaxHealth}";
    private void OnMoneyChanged(int money) => _label_Money.Text = money.ToString();

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
