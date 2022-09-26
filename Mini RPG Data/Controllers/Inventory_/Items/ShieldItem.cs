using Mini_RPG_Data.Datas.Inventory_;
using Mini_RPG_Data.Datas.Inventory_.Items;
using Mini_RPG_Data.Services.Localization;

namespace Mini_RPG_Data.Controllers.Inventory_.Items;

public class ShieldItem : ItemBase
{
    private readonly ShieldItemData? _data;

    public ShieldItem(ILocalizationService localizationService, ItemDataBase data) : base(localizationService, data)
    {
        _data = data as ShieldItemData;
    }

    public int MinBlockBonus => _data.MinBlockBonus;
    public int MaxBlockBonus => _data.MaxBlockBonus;

    public override ItemType Type => ItemType.Shield;
    public override string Description =>
        base.Description +
        $", {LocalizationService.MinBlockBonus()}: {_data.MinBlockBonus}" +
        $", {LocalizationService.MaxBlockBonus()}: {_data.MaxBlockBonus}";
}
