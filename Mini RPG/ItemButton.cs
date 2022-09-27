using Mini_RPG_Data.Controllers.Inventory_.Items;

namespace Mini_RPG;

internal class ItemButton : Button
{
    public ItemBase Item { get; private set; }

    public ItemButton(ItemBase item)
    {
        Item = item;
    }
}
