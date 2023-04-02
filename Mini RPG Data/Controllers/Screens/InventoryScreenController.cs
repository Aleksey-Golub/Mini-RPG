using Mini_RPG_Data.Controllers.Character_;
using Mini_RPG_Data.Controllers.Inventory_.Items;
using Mini_RPG_Data.Services;
using Mini_RPG_Data.Services.Localization;
using Mini_RPG_Data.Viewes;

namespace Mini_RPG_Data.Controllers.Screens;

public class InventoryScreenController
{
    private readonly ILocalizationService _localizationService;
    private readonly IInventoryView _invetoryView;
    private readonly ILogView _logView;
    private readonly GameProcessScreenController _gameProcessScreenController;
    private readonly Character _character;

    public InventoryScreenController(ICharacter character, GameProcessScreenController gameProcessScreenController, IInventoryView invetoryView, ILogView logView)
    {
        _localizationService = AllServices.Container.Single<ILocalizationService>();

        _character = character as Character;
        _gameProcessScreenController = gameProcessScreenController;
        _invetoryView = invetoryView;
        _logView = logView;
    }

    public bool TryUse(ItemBase item)
    {
        bool res = _character.TryUse(item);
        if (res)
        {
            _invetoryView.ShowInventory();
            _invetoryView.ShowEquipment();
            _logView.AddLog($"{_localizationService.GetLocalization("YouUse")}: {item.LocalizedName}");

            _gameProcessScreenController.Tick(PlayerAction.UseItemSuccessfully);
        }
        return res;
    }

    public void UnequipHead() => UnequipSlot(EquipmentSlot.Head);
    public void UnequipBody() => UnequipSlot(EquipmentSlot.Body);
    public void UnequipHands() => UnequipSlot(EquipmentSlot.Hands);
    public void UnequipLegs() => UnequipSlot(EquipmentSlot.Legs);
    public void UnequipMainHand() => UnequipSlot(EquipmentSlot.MainHand);
    public void UnequipOffHand() => UnequipSlot(EquipmentSlot.OffHand);

    private void UnequipSlot(EquipmentSlot slot)
    {
        if (_character.Inventory.EquipmentSlots[slot] == null)
            return;

        _character.Unequip(slot);
        _invetoryView.ShowInventory();
        _invetoryView.ShowEquipment();
            
        _gameProcessScreenController.Tick(PlayerAction.UnEquipItem);
    }
}
