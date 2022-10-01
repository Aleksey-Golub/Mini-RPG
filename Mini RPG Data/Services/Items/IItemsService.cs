using Mini_RPG_Data.Datas.Inventory_;
using Mini_RPG_Data.Datas.Inventory_.Items;

namespace Mini_RPG_Data.Services.Items;

public interface IItemsService : IService
{
    ItemDataBase? GetRandomItemOrNull(ItemType type, int itemRating);
    ItemDataBase? GetItemDataByIdOrNull(ItemSaveData itemSaveData);
}
