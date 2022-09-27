using Mini_RPG_Data.Controllers.Character_;
using Mini_RPG_Data.Datas.Inventory_;
using Mini_RPG_Data.Datas.Inventory_.Items;
using Mini_RPG_Data.Services.Localization;

namespace Mini_RPG_Data.Controllers.Inventory_.Items;

public class CommonItem : ItemBase
{
    private readonly CommonItemData? _data;

    public CommonItem(ILocalizationService localizationService, ItemDataBase data) : base(localizationService, data)
    {
        _data = data as CommonItemData;
    }

    public override ItemType Type => ItemType.Common;

    internal override bool TryUse(Character character) => false;
}
