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

    public ItemBase CreateOrNull(ItemSaveData itemSaveData)
    {
        if (itemSaveData == null)
            return null;

        ItemDataBase? itemData = itemSaveData.Type switch
        {
            ItemType.Common => _itemsService.GetCommonItemDataByIdOrNull(itemSaveData.Id),
            ItemType.Weapon => _itemsService.GetWeaponItemDataByIdOrNull(itemSaveData.Id),
            ItemType.Armor => _itemsService.GetArmorItemDataByIdOrNull(itemSaveData.Id),
            ItemType.Potion => _itemsService.GetPotionItemDataByIdOrNull(itemSaveData.Id),
            ItemType.Shield => _itemsService.GetShieldItemDataByIdOrNull(itemSaveData.Id),
            ItemType.Food => _itemsService.GetFoodItemDataByIdOrNull(itemSaveData.Id),
            ItemType.None => throw new NotImplementedException(),
            _ => throw new NotImplementedException(),
        };

        return itemSaveData.Type switch
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
