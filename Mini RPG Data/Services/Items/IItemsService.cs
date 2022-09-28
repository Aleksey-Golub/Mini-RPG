using Mini_RPG_Data.Datas.Inventory_;
using Mini_RPG_Data.Datas.Inventory_.Items;

namespace Mini_RPG_Data.Services.Items;

public interface IItemsService : IService
{
    ArmorItemData? GetArmorItemDataByIdOrNull(int id);
    CommonItemData? GetCommonItemDataByIdOrNull(int id);
    FoodItemData? GetFoodItemDataByIdOrNull(int id);
    PotionItemData? GetPotionItemDataByIdOrNull(int id);
    ShieldItemData? GetShieldItemDataByIdOrNull(int id);
    WeaponItemData? GetWeaponItemDataByIdOrNull(int id);
    ItemDataBase GetRandomItem(ItemType type);
}
