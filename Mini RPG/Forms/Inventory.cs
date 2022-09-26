using Mini_RPG_Data.Controllers.Character_;
using Mini_RPG_Data.Controllers.Inventory_.Items;
using Mini_RPG_Data.Controllers.Screens;
using Mini_RPG_Data.Services.Localization;

namespace Mini_RPG;

public partial class Inventory : Form
{
    private readonly ILocalizationService _localizationService;
    private readonly ICharacter _character;

    private readonly InventoryController _controller;

    public Inventory(ILocalizationService localizationService, ICharacter character)
    {
        InitializeComponent();

        _localizationService = localizationService;
        _character = character;

        _controller = new InventoryController(_character);

        SetTexts();

        ShowInventory();
    }

    private void ShowInventory()
    {
        _flowLayoutPanel_Inventory.Controls.Clear();

        foreach (var item in _character.Inventory.Items)
            ShowItem(item);
    }

    private void ShowItem(ItemBase item)
    {
        var btn = new Button();
        btn.Size = new Size(100, 100);
        btn.Text = item.Description;

        _flowLayoutPanel_Inventory.Controls.Add(btn);
    }

    private void SetTexts() => _button_Close.Text = _localizationService.Button_Close();
    
    #region Controls Events Handlers

    #endregion
}
