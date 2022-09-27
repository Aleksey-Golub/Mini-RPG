using Mini_RPG_Data.Controllers.Character_;
using Mini_RPG_Data.Datas.Inventory_;
using Mini_RPG_Data.Datas.Inventory_.Items;
using Mini_RPG_Data.Services.Localization;

namespace Mini_RPG_Data.Controllers.Inventory_.Items;

public class ArmorItem : ItemBase
{
    private readonly ArmorItemData? _data;

    public ArmorItem(ILocalizationService localizationService, ItemDataBase data) : base(localizationService, data)
    {
        _data = data as ArmorItemData;
    }

    public ArmorType ArmorType => _data.ArmorType;
    public int ArmorValue => _data.ArmorValue;
    public int DodgePenalty => _data.DodgePenalty;
    public EquipmentSlot EquipmentSlot => _data.EquipmentSlot;

    public override ItemType Type => ItemType.Armor;
    public override string Description =>
        base.Description +
        $", {LocalizationService.ArmorType()}: {LocalizationService.ArmorTypeName(_data.ArmorType)}" +
        $", {LocalizationService.Armor()}: {_data.ArmorValue}" +
        $", {LocalizationService.DodgePenalty()}: {_data.DodgePenalty}";

    internal override bool TryUse(Character character)
    {
        character.Equip(this);
        //character.Inventory.RemoveItem(this);
        return true;
    }
}
