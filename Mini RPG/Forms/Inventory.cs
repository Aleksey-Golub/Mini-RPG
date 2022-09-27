using Mini_RPG_Data.Controllers.Character_;
using Mini_RPG_Data.Controllers.Inventory_.Items;
using Mini_RPG_Data.Controllers.Screens;
using Mini_RPG_Data.Services.Localization;
using Mini_RPG_Data.Viewes;

namespace Mini_RPG;

public partial class Inventory : Form, IInventoryView
{
    private readonly ILocalizationService _localizationService;
    private readonly ICharacter _character;

    private readonly InventoryScreenController _controller;

    public Inventory(ILocalizationService localizationService, ICharacter character, ILogView logView)
    {
        InitializeComponent();

        _localizationService = localizationService;
        _character = character;

        _controller = new InventoryScreenController(_character, this, logView);

        SetTexts();

        ShowInventory();
        ShowEquipment();
    }

    public void ShowEquipment()
    {
        _button_HeadEquippedItem.BackgroundImage = ImageManager.GetItemImage(_character.Inventory.EquipmentSlots[EquipmentSlot.Head]);
        _button_HandsEquippedItem.BackgroundImage = ImageManager.GetItemImage(_character.Inventory.EquipmentSlots[EquipmentSlot.Hands]);
        _button_BodyEquippedItem.BackgroundImage = ImageManager.GetItemImage(_character.Inventory.EquipmentSlots[EquipmentSlot.Body]);
        _button_LegsEquippedItem.BackgroundImage = ImageManager.GetItemImage(_character.Inventory.EquipmentSlots[EquipmentSlot.Legs]);
        _button_MainHandEquippedItem.BackgroundImage = ImageManager.GetItemImage(_character.Inventory.EquipmentSlots[EquipmentSlot.MainHand]);
        _button_OffHandEquippedItem.BackgroundImage = ImageManager.GetItemImage(_character.Inventory.EquipmentSlots[EquipmentSlot.OffHand]);
    }

    public void ShowInventory()
    {
        _flowLayoutPanel_Inventory.Controls.Clear();
        _toolTip.RemoveAll();

        foreach (var item in _character.Inventory.Items)
            ShowItem(item);
    }

    private void ShowItem(ItemBase item)
    {
        var btn = new ItemButton(item);
        btn.Size = new Size(200, 200);
        btn.Font = new Font(btn.Font.FontFamily, 8f);
        btn.TextAlign = ContentAlignment.BottomCenter;
        btn.BackgroundImage = ImageManager.GetItemImage(item);
        btn.BackgroundImageLayout = ImageLayout.Zoom;
        btn.Text = item.LocalizedName;
        btn.Click += OnInventoryButtonClicked;

        _flowLayoutPanel_Inventory.Controls.Add(btn);

        _toolTip.SetToolTip(btn, item.Description);
    }

    private void OnInventoryButtonClicked(object? sender, EventArgs e)
    {
        var inventoryButton = (sender as ItemButton);
        inventoryButton.Click -= OnInventoryButtonClicked;

        _controller.TryUse(inventoryButton.Item);

        //_flowLayoutPanel_Inventory.Controls.Remove(inventoryButton);
    }

    private void SetTexts() => _button_Close.Text = _localizationService.Button_Close();

    #region Controls Events Handlers
    private void Button_HeadEquippedItem_Click(object sender, EventArgs e) => _controller.UnequipHead();
    private void Button_MainHandEquippedItem_Click(object sender, EventArgs e) => _controller.UnequipMainHand();
    private void Button_BodyEquippedItem_Click(object sender, EventArgs e) => _controller.UnequipBody();
    private void Button_OffHandEquippedItem_Click(object sender, EventArgs e) => _controller.UnequipOffHand();
    private void Button_HandsEquippedItem_Click(object sender, EventArgs e) => _controller.UnequipHands();
    private void Button_LegsEquippedItem_Click(object sender, EventArgs e) => _controller.UnequipLegs();
    #endregion
}
