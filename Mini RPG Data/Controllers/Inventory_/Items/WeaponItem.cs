using Mini_RPG_Data.Controllers.Character_;
using Mini_RPG_Data.Datas.Inventory_;
using Mini_RPG_Data.Datas.Inventory_.Items;
using Mini_RPG_Data.Services.Localization;

namespace Mini_RPG_Data.Controllers.Inventory_.Items;

public class WeaponItem : ItemBase
{
    private readonly WeaponItemData? _data;

    public WeaponItem(ILocalizationService localizationService, ItemDataBase data) : base(localizationService, data)
    {
        _data = data as WeaponItemData;
    }

    public DamageType DamageType => _data.DamageType;
    public Grip Grip => _data.Grip;
    public int MinDamage => _data.MinDamage;
    public int MaxDamage => _data.MaxDamage;

    public override ItemType Type => ItemType.Weapon;
    public override string Description =>
        base.Description +
        $", {LocalizationService.DamageType()}: {LocalizationService.DamageTypeName(_data.DamageType)}" +
        $", {LocalizationService.Grip()}: {LocalizationService.GripName(_data.Grip)}" +
        $", {LocalizationService.Damage()}: {_data.MinDamage}-{_data.MaxDamage}";

    internal override bool TryUse(Character character)
    {
        character.Equip(this);
        //character.Inventory.RemoveItem(this);
        return true;
    }
}
