using Mini_RPG_Data.Datas.Inventory_;
using Mini_RPG_Data.Datas.Inventory_.Items;
using Mini_RPG_Data.Services.Localization;

namespace Mini_RPG_Data.Controllers.Inventory_.Items;

public class PotionItem : ItemBase
{
    private readonly PotionItemData? _data;

    public PotionItem(ILocalizationService localizationService, ItemDataBase data) : base(localizationService, data)
    {
        _data = data as PotionItemData;
    }

    public override ItemType Type => ItemType.Potion;
}
