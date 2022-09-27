using Mini_RPG_Data.Controllers.Inventory_.Items;
using Mini_RPG_Data.Datas.Inventory_;
using Mini_RPG_Data.Services.Items;

namespace Mini_RPG_Data.Controllers.Inventory_;

public class Inventory
{
    private readonly IItemFactory _itemsFactory;

    private readonly InventoryData _data;

    public List<ItemBase> Items { get; private set; }
    public Dictionary<EquipmentSlot, ItemBase> EquipmentSlots { get; private set; }

    public Inventory(IItemFactory itemFactory, InventoryData inventoryData)
    {
        _itemsFactory = itemFactory;
        _data = inventoryData;

        Items = new List<ItemBase>();
        EquipmentSlots = new Dictionary<EquipmentSlot, ItemBase>()
        {
            [EquipmentSlot.Head] = null,
            [EquipmentSlot.Hands] = null,
            [EquipmentSlot.Body] = null,
            [EquipmentSlot.Legs] = null,
            [EquipmentSlot.MainHand] = null,
            [EquipmentSlot.OffHand] = null,
        };

        Init();
    }

    internal bool TryUnequipHead() => TryUnequip(EquipmentSlot.Head);
    internal bool TryUnequipBody() => TryUnequip(EquipmentSlot.Body);
    internal bool TryUnequipHands() => TryUnequip(EquipmentSlot.Hands);
    internal bool TryUnequipLegs() => TryUnequip(EquipmentSlot.Legs);
    internal bool TryUnequipMainHand()
    {
        var unequippedItem = EquipmentSlots[EquipmentSlot.MainHand];
        if (unequippedItem != null)
        {
            AddItem(unequippedItem);
            EquipmentSlots[EquipmentSlot.MainHand] = null;

            WeaponItem? weaponItem = unequippedItem as WeaponItem;
            if (weaponItem.Grip == Grip.TwoHanded)
                EquipmentSlots[EquipmentSlot.OffHand] = null;
            return true;
        }

        return false;
    }
    internal bool TryUnequipOffHand()
    {
        var unequippedItem = EquipmentSlots[EquipmentSlot.OffHand];
        if (unequippedItem != null)
        {
            AddItem(unequippedItem);
            EquipmentSlots[EquipmentSlot.OffHand] = null;

            WeaponItem? weaponItem = unequippedItem as WeaponItem;
            if (weaponItem.Grip == Grip.TwoHanded)
                EquipmentSlots[EquipmentSlot.MainHand] = null;
            return true;
        }

        return false;
    }

    internal void Drink(PotionItem potionItem)
    {
        RemoveItem(potionItem);
    }

    internal void Eat(FoodItem foodItem)
    {
        RemoveItem(foodItem);
    }

    internal void Equip(ArmorItem armorItem)
    {
        EquipmentSlot slot = armorItem.EquipmentSlot;

        TryUnequip(slot);
        EquipmentSlots[slot] = armorItem;
        RemoveItem(armorItem);
    }

    internal void Equip(ShieldItem shieldItem)
    {
        TryUnequipOffHand();
        EquipmentSlots[EquipmentSlot.OffHand] = shieldItem;
        RemoveItem(shieldItem);
    }

    internal void Equip(WeaponItem weaponItem)
    {
        TryUnequipMainHand();
        EquipmentSlots[EquipmentSlot.MainHand] = weaponItem;
        RemoveItem(weaponItem);
    }

    private void RemoveItem(ItemBase item) => Items.Remove(item);
    private void AddItem(ItemBase item) => Items.Add(item);

    private bool TryUnequip(EquipmentSlot slot)
    {
        var unequippedItem = EquipmentSlots[slot];
        if (unequippedItem != null)
        {
            AddItem(unequippedItem);
            EquipmentSlots[slot] = null;
            return true;
        }

        return false;
    }

    private void Init()
    {
        foreach (var itemSaveData in _data.Items)
            AddItem(_itemsFactory.CreateOrNull(itemSaveData));

        EquipmentSlots[EquipmentSlot.Head] = _itemsFactory.CreateOrNull(_data.EquippedItems[0]);
        EquipmentSlots[EquipmentSlot.Hands] = _itemsFactory.CreateOrNull(_data.EquippedItems[1]);
        EquipmentSlots[EquipmentSlot.Body] = _itemsFactory.CreateOrNull(_data.EquippedItems[2]);
        EquipmentSlots[EquipmentSlot.Legs] = _itemsFactory.CreateOrNull(_data.EquippedItems[3]);

        ItemSaveData MainHandItemSaveData = _data.EquippedItems[4];
        ItemSaveData OffHandItemSaveData = _data.EquippedItems[5];
        ItemBase MainHandItem = _itemsFactory.CreateOrNull(MainHandItemSaveData);
        EquipmentSlots[EquipmentSlot.MainHand] = MainHandItem;

        EquipmentSlots[EquipmentSlot.OffHand] =
            MainHandItemSaveData == null || OffHandItemSaveData == null
            ? _itemsFactory.CreateOrNull(OffHandItemSaveData)
            : MainHandItemSaveData.Type == OffHandItemSaveData.Type && MainHandItemSaveData.Id == OffHandItemSaveData.Id
                ? MainHandItem
                : _itemsFactory.CreateOrNull(OffHandItemSaveData);
    }
}
