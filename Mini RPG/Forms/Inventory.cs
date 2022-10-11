using Mini_RPG_Data.Controllers.Character_;
using Mini_RPG_Data.Controllers.Inventory_.Items;
using Mini_RPG_Data.Controllers.Screens;
using Mini_RPG_Data.Datas.Inventory_;
using Mini_RPG_Data.Services.Localization;
using Mini_RPG_Data.Viewes;

namespace Mini_RPG;

public partial class Inventory : Form, IInventoryView
{
    private readonly ILocalizationService _localizationService;
    private readonly ICharacter _character;

    private readonly InventoryScreenController _controller;

    private readonly bool _shawAsSrackable = true;

    public Inventory(ILocalizationService localizationService, ICharacter character, GameProcessScreenController gameController, ILogView logView)
    {
        InitializeComponent();

        _localizationService = localizationService;
        _character = character;
        _character.Died += OnCharacterDied;

        _controller = new InventoryScreenController(_character, gameController, this, logView);

        SetTexts();

        ShowInventory();
        ShowEquipment();
    }

    public void ShowEquipment()
    {
        _toolTip_Equipment.RemoveAll();
        ShowSlot(_button_HeadEquippedItem, EquipmentSlot.Head);
        ShowSlot(_button_HandsEquippedItem, EquipmentSlot.Hands);
        ShowSlot(_button_BodyEquippedItem, EquipmentSlot.Body);
        ShowSlot(_button_LegsEquippedItem, EquipmentSlot.Legs);
        ShowSlot(_button_MainHandEquippedItem, EquipmentSlot.MainHand);
        ShowSlot(_button_OffHandEquippedItem, EquipmentSlot.OffHand);
    }

    public void ShowInventory()
    {
        _flowLayoutPanel_Inventory.Controls.Clear();
        _toolTip_Inventory.RemoveAll();

        if (_shawAsSrackable)
            ShowItemsAsStackable();
        else
            ShowItemsAsNotStackable();
    }

    private void ShowItemsAsNotStackable()
    {
        foreach (var item in _character.Inventory.Items)
            ShowItem(item);
    }

    private void ShowItemsAsStackable()
    {
        Dictionary<InventoryItemKey, InventoryItemValue> inventoryItems = new Dictionary<InventoryItemKey, InventoryItemValue>();
        foreach (var item in _character.Inventory.Items)
        {
            InventoryItemKey key = new InventoryItemKey(item.Type, item.Id);

            if (inventoryItems.ContainsKey(key))
                inventoryItems[key].Count++;
            else
                inventoryItems[key] = new InventoryItemValue(item, 1);
        }

        foreach (var value in inventoryItems.Values)
            ShowStackableItem(value.Item, value.Count);
    }

    private void OnCharacterDied(ICharacter character)
    {
        character.Died -= OnCharacterDied;

        DialogResult = DialogResult.OK;
    }

    private void ShowSlot(Button slotButton, EquipmentSlot slot)
    {
        slotButton.BackgroundImage = ImageManager.GetItemImageOrEmpty(_character.Inventory.EquipmentSlots[slot]);
        _toolTip_Equipment.SetToolTip(slotButton, _character.Inventory.EquipmentSlots[slot]?.Description);
    }

    private void ShowStackableItem(ItemBase item, int count)
    {
        var btn = new ItemButton(item);
        btn.Size = new Size(200, 200);
        btn.Font = new Font(btn.Font.FontFamily, 8f);
        btn.TextAlign = ContentAlignment.BottomCenter;
        btn.BackgroundImage = ImageManager.GetItemImageOrEmpty(item);
        btn.BackgroundImageLayout = ImageLayout.Zoom;
        btn.Text = $"{item.LocalizedName}\n{count}";
        btn.ForeColor = Color.Red;
        btn.Click += OnInventoryButtonClicked;
        _flowLayoutPanel_Inventory.Controls.Add(btn);

        _toolTip_Inventory.SetToolTip(btn, item.Description);
    }

    private void ShowItem(ItemBase item)
    {
        var btn = new ItemButton(item);
        btn.Size = new Size(200, 200);
        btn.Font = new Font(btn.Font.FontFamily, 8f);
        btn.TextAlign = ContentAlignment.BottomCenter;
        btn.BackgroundImage = ImageManager.GetItemImageOrEmpty(item);
        btn.BackgroundImageLayout = ImageLayout.Zoom;
        btn.Text = item.LocalizedName;
        btn.Click += OnInventoryButtonClicked;

        _flowLayoutPanel_Inventory.Controls.Add(btn);

        _toolTip_Inventory.SetToolTip(btn, item.Description);
    }

    private void OnInventoryButtonClicked(object? sender, EventArgs e)
    {
        var inventoryButton = (sender as ItemButton);
        inventoryButton.Click -= OnInventoryButtonClicked;

        _controller.TryUse(inventoryButton.Item);
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

    private struct InventoryItemKey
    {
        public ItemType Type;
        public int Id;

        public InventoryItemKey(ItemType type, int Id)
        {
            Type = type;
            this.Id = Id;
        }
    }

    private class InventoryItemValue
    {
        public ItemBase Item;
        public int Count;

        public InventoryItemValue(ItemBase item, int count)
        {
            Item = item;
            Count = count;
        }
    }
}
