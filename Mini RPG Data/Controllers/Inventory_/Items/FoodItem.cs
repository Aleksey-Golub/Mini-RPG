using Mini_RPG_Data.Datas.Inventory_;
using Mini_RPG_Data.Datas.Inventory_.Items;
using Mini_RPG_Data.Services.Localization;

namespace Mini_RPG_Data.Controllers.Inventory_.Items;

public class FoodItem : ItemBase
{
    private readonly FoodItemData? _data;

    public FoodItem(ILocalizationService localizationService, ItemDataBase data) : base(localizationService, data)
    {
        _data = data as FoodItemData;
    }

    public override ItemType Type => ItemType.Food;
}
