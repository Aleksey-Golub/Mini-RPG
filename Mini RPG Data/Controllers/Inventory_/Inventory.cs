using Mini_RPG_Data.Controllers.Inventory_.Items;
using Mini_RPG_Data.Datas.Inventory_;
using Mini_RPG_Data.Services.Items;

namespace Mini_RPG_Data.Controllers.Inventory_;

public class Inventory
{
    private readonly IItemFactory _itemsFactory;

    private readonly InventoryData _data;

    public List<ItemBase> Items { get; private set; }

    public Inventory(IItemFactory itemFactory, InventoryData inventoryData)
    {
        _itemsFactory = itemFactory;
        _data = inventoryData;
        Items = new List<ItemBase>();

        Init();
    }

    private void Init()
    {
        foreach (var itemSaveData in _data.Items)
            Items.Add(_itemsFactory.Create(itemSaveData));
    }
}
