﻿using Mini_RPG_Data.Controllers.Screens;
using Mini_RPG_Data.Controllers.Map_;
using Mini_RPG_Data.Viewes;
using Mini_RPG_Data.Services.Localization;
using Mini_RPG_Data.Controllers;
using Mini_RPG_Data.Controllers.Character_;
using Mini_RPG.Screens.CharacterCreationScreen_;
using Mini_RPG_Data.Controllers.Inventory_.Items;
using System.Text;
using Mini_RPG_Data;

namespace Mini_RPG.Screens;

public partial class GameProcessScreen : UserControl, IGameProcessView, ILogView
{
    private readonly ILocalizationService _localizationService;
    private readonly MapView _mapView;
    private readonly HealthView _healthView;
    private readonly SatiationView _satiationView;

    private GameProcessScreenController _controller;
    private Log _log;
    //private BattleView _battleView;
    private IPlayer? _player;

    public GameProcessScreen(ILocalizationService localizationService)
    {
        InitializeComponent();

        _localizationService = localizationService;
        _localizationService.LanguageChanged += SetTexts;
        SetTexts();

        _mapView = new MapView(_label_Map, _toolTip, _localizationService);
        _healthView = new HealthView(_label_Health, _panel_CharacterHealthBarFG);
        _satiationView = new SatiationView(_localizationService, _label_HungerLevel, _label_ThirstLevel);
        //_battleView = new BattleView(_panel_Battle, _panel_BattleActions, _button_Attack, _button_TryLeaveBattle, this);
    }

    public void Init(IPlayer player)
    {
        _player = player;

        _player.Character.AllAbilities.Changed += OnCharacterAbilitiesChanged;
        _player.Character.HealthChanged += OnCharacterHealthChanged;
        _player.Character.Satiation.Changed += OnCharacterSatiationChanging;
        _player.Wallet.MoneyChanged += OnMoneyChanged;

        OnCharacterAbilitiesChanged();
        OnCharacterHealthChanged(_player.Character);
        OnCharacterSatiationChanging();
        OnMoneyChanged(_player.Wallet.Money);

        _log = new Log(_flowLayoutPanel_GameLog, _button_SwitchLogSize);
        _log.FillLog();
        _mapView.Init(_player.Character.Name);
        _button_CharacterProgress.BackgroundImage = ImageManager.GetImageFromFile(_player.Character.AvatarPath);
    }

    public void DeInit()
    {
        _player.Character.AllAbilities.Changed -= OnCharacterAbilitiesChanged;
        _player.Character.Changed -= OnCharacterHealthChanged;
        _player.Character.Satiation.Changed -= OnCharacterSatiationChanging;
        _player.Wallet.MoneyChanged -= OnMoneyChanged;

        _controller = null;
        _player = null;

        _log.ClearLogs();
        _log = null;

        //_panel_Battle.Hide();
        //_panel_BattleActions.Hide();

        //_battleView.Hide();
        //_battleView = null;
    }

    public void SetGameProcessController(GameProcessScreenController gameProcessController) => _controller = gameProcessController;
    public void SetActiveState(bool newState) => Visible = newState;

    public void ShowTownEntrance()
    {
        _panel_Location.BackgroundImage = ImageManager.GetTownEntrance();

        _panel_Battle.Hide();
        _panel_BattleActions.Hide();

        _panel_Town.Hide();
        _panel_TownEntrance.Show();

        _menuStrip.Show();
        _panel_Navigation.Show();
    }

    public void ShowTown()
    {
        _panel_Location.BackgroundImage = ImageManager.GetTown();

        _panel_Battle.Hide();
        _panel_BattleActions.Hide();

        _panel_Town.Show();
        _panel_TownEntrance.Hide();

        _menuStrip.Show();
        _panel_Navigation.Hide();
    }

    public void ShowLocation(IMapCell cell)
    {
        //_panel_Location.BackgroundImage = ImageManager.GetLocation(cell.ImageIndex);

        _panel_Battle.Hide();
        _panel_BattleActions.Hide();

        _panel_Town.Hide();
        _panel_TownEntrance.Hide();

        _menuStrip.Show();
        _panel_Navigation.Show();
    }

    public void ShowBattle(ICharacter enemy)
    {
        //_pictureBox_Enemy.BackgroundImage = ImageManager.GetEnemyImage(enemy);

        _panel_Battle.Show();
        _panel_BattleActions.Show();

        _panel_Town.Hide();
        _panel_TownEntrance.Hide();

        _menuStrip.Hide();
        _panel_Navigation.Hide();

        //_battleView = new BattleView(_panel_Battle, _panel_BattleActions, _button_Attack, _button_TryLeaveBattle, _pictureBox_Enemy, _controller, this);
        //_battleView.View(_player, enemy);
    }

    public void HideBattle(IReadOnlyList<ItemBase> loot, int experience)
    {
        StringBuilder sb = new StringBuilder();
        sb.Append($"Gained {experience} EX\n");
        foreach (ItemBase item in loot)
            sb.Append($"{item.LocalizedName}\n");

        MessageBox.Show(sb.ToString());
        //_battleView.Hide();
        //_battleView = null;
    }

    public void ShowSuccessRestInTownMessage() => 
        MessageBox.Show(
            $"{_localizationService.Message_YouRestInTown()}");

    public void ShowFailRestInTownMessage() => 
        MessageBox.Show(
            $"{_localizationService.Message_YouDoNotRestInTown()}");

    public void ShowMiniMap(IMap map, int fieldOfView) => 
        _mapView.DrawMap(map, fieldOfView);

    public void ShowMap(IMap map)
    {
        using var mapForm = new OpenedMap(map, _localizationService, _player.Character.Name);
        if (mapForm.ShowDialog() == DialogResult.OK)
        { }
    }

    public void AddLog(string message) => _log?.AddLog(message);

    public void ShowBattleStartMessage() => 
        MessageBox.Show(
            $"{_localizationService.Message_BattleStart()}");

    public void ShowFindChestMessage() =>
        MessageBox.Show(
            $"{_localizationService.Message_YouFindLockedChest()}");

    public void ShowLootCellMessage(int money, List<ItemBase> loot) =>
        MessageBox.Show(
            $"{_localizationService.Message_YouFindLoot()}:\n" +
            LootAndMoneyMessage(money, loot));

    public void ShowSuccessPickLockedChestMessage(int money, List<ItemBase> loot) =>
        MessageBox.Show(
            $"{_localizationService.Message_PickLockedChestSuccess()}:\n" +
            LootAndMoneyMessage(money, loot));

    public void ShowFailPickLockedChestMessage() =>
        MessageBox.Show(
            $"{_localizationService.Message_PickLockedChestFail()}");

    public void ShowSuccessBreakChestMessage(int money, List<ItemBase> loot) =>
        MessageBox.Show(
            $"{_localizationService.Message_BreakChestSuccess()}:\n" +
            LootAndMoneyMessage(money, loot));

    public void ShowFailBreakChestMessage() =>
        MessageBox.Show(
            $"{_localizationService.Message_BreakChestFail()}");

    public void ShowSuccessFindHiddenLootMessage(int money, List<ItemBase> loot) =>
        MessageBox.Show(
            $"{_localizationService.Message_YouFindHiddenLoot()}:\n" +
            LootAndMoneyMessage(money, loot));

    public void ShowSuccessFindTrapMessage(TrapType trapType) =>
        MessageBox.Show(
            $"{_localizationService.Message_FindTrapSuccess(trapType)}");

    public void ShowFailFindTrapMessage(TrapType trapType) =>
        MessageBox.Show(
            $"{_localizationService.Message_FindTrapFail(trapType)}");

    private string LootAndMoneyMessage(int money, List<ItemBase> loot)
    {
        StringBuilder sb = new StringBuilder();
        sb.Append($"{_localizationService.Message_Coins()}: {money}\n");
        foreach (ItemBase item in loot)
            sb.Append($"{item.LocalizedName}\n");

        return sb.ToString();
    }

    private void OnCharacterAbilitiesChanged()
    {
        var allAbilities = _player.Character.AllAbilities;

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

    private void OnCharacterHealthChanged(ICharacter character) => _healthView.View(character.Health.CurrentHealth, character.Health.MaxHealth);
    private void OnCharacterSatiationChanging() => _satiationView.View(_player.Character.Satiation.HungerLevel, _player.Character.Satiation.ThirstLevel);
    private void OnMoneyChanged(int money) => _label_Money.Text = money.ToString();

    private void SetTexts()
    {
        _label_Strength.Text = _localizationService.Label_Strength();
        _label_Dexterity.Text = _localizationService.Label_Dexterity();
        _label_Constitution.Text = _localizationService.Label_Constitution();
        _label_Perception.Text = _localizationService.Label_Perception();
        _label_Charisma.Text = _localizationService.Label_Charisma();

        _button_Rest.Text = _localizationService.Button_Rest();

        _button_EnterTown.Text = _localizationService.Button_EnterTown();

        _button_Attack.Text = _localizationService.Button_Attack();
        _button_TryLeaveBattle.Text = _localizationService.Button_TryLeaveBattle();

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
        using var characterProgressForm = new CharacterProgress(_localizationService, _player.Character);
        if (characterProgressForm.ShowDialog() == DialogResult.OK)
        { }
    }

    private void Button_Inventory_Click(object sender, EventArgs e)
    {
        using var inventoryForm = new Inventory(_localizationService, _player.Character, _controller, this);
        if (inventoryForm.ShowDialog() == DialogResult.OK)
        { }
    }

    private void Button_Trader_Click(object sender, EventArgs e)
    {
        using var traderForm = new Trader(_localizationService, _player);
        if (traderForm.ShowDialog() == DialogResult.OK)
        { }
    }

    private void Button_RestInTown_Click(object sender, EventArgs e)
    {
        var dialogResult = MessageBox.Show($"{string.Format(_localizationService.Message_RestInTown(), Settings.REST_IN_TOWN_COST.ToString())}", string.Empty, MessageBoxButtons.YesNo);
        if (dialogResult == DialogResult.Yes)
            _controller.TryRestInTown();
    }

    private void Label_Map_Click(object sender, EventArgs e) => _controller.ShowMap();

    private void MenuItem_SaveAndExit_Click(object sender, EventArgs e) => _controller.SaveGameAndExitMainMenu();

    private void Button_EnterTown_Click(object sender, EventArgs e) => _controller.EnterTown();
    private void Button_LeaveTown_Click(object sender, EventArgs e) => _controller.ExitTown();

    private void Button_Rest_Click(object sender, EventArgs e) => _controller.Rest();
    private void Button_N_Click(object sender, EventArgs e) => _controller.TryMove(Direction.N);
    private void Button_S_Click(object sender, EventArgs e) => _controller.TryMove(Direction.S);
    private void Button_W_Click(object sender, EventArgs e) => _controller.TryMove(Direction.W);
    private void Button_E_Click(object sender, EventArgs e) => _controller.TryMove(Direction.E);

    private void Button_Attack_Click(object sender, EventArgs e)
    {
        _controller.Tick(PlayerAction.AttackEnemy);
    }

    private void Button_TryLeaveBattle_Click(object sender, EventArgs e)
    {
        _controller.Tick(PlayerAction.TryLeaveBattle);
    }
    #endregion

    protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
    {
        if (keyData == Keys.Enter)
        {
            if (_panel_Town.Visible)
                _controller.ExitTown();
            else if (_panel_TownEntrance.Visible)
                _controller.EnterTown();

            return true;
        }

        if (keyData == Keys.M)
        {
            _controller.ShowMap();
            return true;
        }

        if (_panel_Navigation.Visible == false)
            return false;

#pragma warning disable IDE0010 // Добавить отсутствующие варианты
        switch (keyData)
        {
            case Keys.NumPad8:
                _controller.TryMove(Direction.N);
                break;
            case Keys.NumPad2:
                _controller.TryMove(Direction.S);
                break;
            case Keys.NumPad4:
                _controller.TryMove(Direction.W);
                break;
            case Keys.NumPad6:
                _controller.TryMove(Direction.E);
                break;
            case Keys.NumPad5:
                _controller.Rest();
                break;
        }
#pragma warning restore IDE0010 // Добавить отсутствующие варианты
        return base.ProcessCmdKey(ref msg, keyData);
    }
}
