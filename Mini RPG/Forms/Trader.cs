using Mini_RPG_Data;
using Mini_RPG_Data.Controllers;
using Mini_RPG_Data.Controllers.Inventory_.Items;
using Mini_RPG_Data.Controllers.Screens;
using Mini_RPG_Data.Services.Localization;
using Mini_RPG_Data.Viewes;

namespace Mini_RPG;

public partial class Trader : Form, ITradeView
{
    private readonly ILocalizationService _localizationService;
    private readonly IPlayer _player;

    private readonly TraderScreenController _controller;

    public Trader(ILocalizationService localizationService, IPlayer player)
    {
        InitializeComponent();

        _localizationService = localizationService;
        _player = player;
        _controller = new TraderScreenController(_player, this);

        SetTexts();

        ShowInventory();
        ShowTraderInventory();
    }

    public void ShowInventory()
    {
        _statusLabel_CharacterMoney.Text = _player.Wallet.Money.ToString();

        _flowLayoutPanel_Inventory.Controls.Clear();
        _toolTip_Inventory.RemoveAll();

        foreach (var item in _player.Character.Inventory.Items)
        {
            ItemButton btn = CreateItemButton(item);
            btn.Click += OnInventoryButtonClicked;
            _flowLayoutPanel_Inventory.Controls.Add(btn);
            _toolTip_Inventory.SetToolTip(btn, $"{item.Description}, {_localizationService.SellCost()}: {Settings.CalculateItemCostModifier(item.Cost, _player as Player)}");
        }
    }

    public void ShowTraderInventory()
    {
        _statusLabel_TraderMoney.Text = _controller.TraderWallet.Money.ToString();

        _flowLayoutPanel_Trader.Controls.Clear();
        _toolTip_Trader.RemoveAll();

        foreach (var item in _controller.TraderInventory.Items)
        {
            ItemButton btn = CreateItemButton(item);
            btn.Click += OnTraderInventoryButtonClicked;
            _flowLayoutPanel_Trader.Controls.Add(btn);
            _toolTip_Trader.SetToolTip(btn, item.Description);
        }
    }

    private ItemButton CreateItemButton(ItemBase item)
    {
        var btn = new ItemButton(item);
        btn.Size = new Size(100, 100);
        btn.Font = new Font(btn.Font.FontFamily, 8f);
        btn.TextAlign = ContentAlignment.BottomCenter;
        btn.BackgroundImage = ImageManager.GetItemImage(item);
        btn.BackgroundImageLayout = ImageLayout.Zoom;
        btn.Text = item.LocalizedName;

        return btn;
    }

    private void OnInventoryButtonClicked(object? sender, EventArgs e)
    {
        var inventoryButton = (sender as ItemButton);
        inventoryButton.Click -= OnInventoryButtonClicked;

        _controller.TrySell(inventoryButton.Item);
    }
    
    private void OnTraderInventoryButtonClicked(object? sender, EventArgs e)
    {
        var inventoryButton = (sender as ItemButton);
        inventoryButton.Click -= OnTraderInventoryButtonClicked;

        _controller.TryBuy(inventoryButton.Item);
    }

    private void SetTexts()
    {
        _button_Close.Text = _localizationService.Button_Close();
        _label_Inventory.Text = _player.Character.Name;
        _label_Trader.Text = _localizationService.Shop();
    }
}
