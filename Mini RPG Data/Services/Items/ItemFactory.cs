using Mini_RPG_Data.Controllers.Inventory_.Items;
using Mini_RPG_Data.Datas.Inventory_;
using Mini_RPG_Data.Datas.Inventory_.Items;
using Mini_RPG_Data.Services.Localization;

namespace Mini_RPG_Data.Services.Items;

public class ItemFactory : IItemFactory
{
    private readonly IItemsService _itemsService;
    private readonly ILocalizationService _localizationService;

    public ItemFactory(IItemsService itemsService, ILocalizationService localizationService)
    {
        _itemsService = itemsService;
        _localizationService = localizationService;
    }

    public ItemBase? CreateOrNull(ItemSaveData itemSaveData)
    {
        if (itemSaveData == null)
            return null;

        ItemDataBase? itemData = _itemsService.GetItemDataByIdOrNull(itemSaveData);

        return CreateItem(itemSaveData.Type, itemData);
    }

    public ItemBase? CreateRandomOrNull(ItemType type = ItemType.None, int itemRating = -1)
    {
        if (itemRating < -1)
            return null;

        type = type == ItemType.None ? Utils.GetRandomEnumValueExcludeFirst<ItemType>() : type;
        ItemDataBase? itemData = _itemsService.GetRandomItemDataOrNull(type, itemRating);

        return itemData == null ? null : CreateItem(type, itemData);
    }

    private ItemBase CreateItem(ItemType type, ItemDataBase? itemData)
    {
        return type switch
        {
            ItemType.Common => new CommonItem(_localizationService, itemData as CommonItemData),
            ItemType.Weapon => new WeaponItem(_localizationService, itemData as WeaponItemData),
            ItemType.Armor => new ArmorItem(_localizationService, itemData as ArmorItemData),
            ItemType.Potion => new PotionItem(_localizationService, itemData as PotionItemData),
            ItemType.Shield => new ShieldItem(_localizationService, itemData as ShieldItemData),
            ItemType.Food => new FoodItem(_localizationService, itemData as FoodItemData),
            ItemType.None => throw new NotImplementedException(),
            _ => throw new NotImplementedException(),
        };
    }
}
