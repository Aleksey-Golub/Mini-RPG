using Mini_RPG_Data.Datas.Inventory_;
using Mini_RPG_Data.Datas.Inventory_.Items;

namespace Mini_RPG_Data.Services.Items;

public interface IItemsService : IService
{
    ItemDataBase? GetRandomItemDataOrNull(ItemType type, int itemRating);
    ItemDataBase? GetItemDataOrNull(ItemSaveData itemSaveData);
}
