using Mini_RPG_Data.Controllers.Inventory_.Items;
using Mini_RPG_Data.Datas.Inventory_;

namespace Mini_RPG_Data.Services.Items;

public interface IItemFactory : IService
{
    ItemBase CreateOrNull(ItemSaveData itemSaveData);
}
