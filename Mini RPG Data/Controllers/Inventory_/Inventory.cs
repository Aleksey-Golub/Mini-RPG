using Mini_RPG_Data.Controllers.Inventory_.Items;
using Mini_RPG_Data.Datas.Inventory_;
using Mini_RPG_Data.Services.Items;

namespace Mini_RPG_Data.Controllers.Inventory_;

public class Inventory
{
    private readonly IItemFactory _itemsFactory;

    private readonly InventoryData _data;

    private readonly List<ItemBase> _items;
    private readonly Dictionary<EquipmentSlot, ItemBase?> _equipmentSlots;
    internal readonly int DodgePenalty;

    public Inventory(IItemFactory itemFactory, InventoryData inventoryData)
    {
        _itemsFactory = itemFactory;
        _data = inventoryData;
        _data.SaveStarting += UpdateData;

        _items = new List<ItemBase>();
        _equipmentSlots = new Dictionary<EquipmentSlot, ItemBase?>()
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

    public IReadOnlyList<ItemBase> Items => _items;
    public IReadOnlyDictionary<EquipmentSlot, ItemBase> EquipmentSlots => _equipmentSlots;

    internal bool TryUnequipHead() => TryUnequip(EquipmentSlot.Head);
    internal bool TryUnequipBody() => TryUnequip(EquipmentSlot.Body);
    internal bool TryUnequipHands() => TryUnequip(EquipmentSlot.Hands);
    internal bool TryUnequipLegs() => TryUnequip(EquipmentSlot.Legs);
    internal bool TryUnequipMainHand()
    {
        var unequippedItem = _equipmentSlots[EquipmentSlot.MainHand];
        if (unequippedItem != null)
        {
            AddItem(unequippedItem);
            _equipmentSlots[EquipmentSlot.MainHand] = null;

            WeaponItem? weaponItem = unequippedItem as WeaponItem;
            if (weaponItem.Grip == Grip.TwoHanded)
                _equipmentSlots[EquipmentSlot.OffHand] = null;
            return true;
        }

        return false;
    }
    internal bool TryUnequipOffHand()
    {
        var unequippedItem = _equipmentSlots[EquipmentSlot.OffHand];
        if (unequippedItem != null)
        {
            AddItem(unequippedItem);
            _equipmentSlots[EquipmentSlot.OffHand] = null;

            WeaponItem? weaponItem = unequippedItem as WeaponItem;
            if (weaponItem != null)
                if (weaponItem.Grip == Grip.TwoHanded)
                    _equipmentSlots[EquipmentSlot.MainHand] = null;
            return true;
        }

        return false;
    }

    internal void Equip(ArmorItem armorItem)
    {
        EquipmentSlot slot = armorItem.EquipmentSlot;

        TryUnequip(slot);
        _equipmentSlots[slot] = armorItem;
        RemoveItem(armorItem);
    }

    internal void Equip(ShieldItem shieldItem)
    {
        TryUnequipOffHand();
        _equipmentSlots[EquipmentSlot.OffHand] = shieldItem;
        RemoveItem(shieldItem);
    }

    internal void Equip(WeaponItem weaponItem)
    {
        TryUnequipMainHand();
        if (weaponItem.Grip == Grip.TwoHanded)
            TryUnequipOffHand();

        _equipmentSlots[EquipmentSlot.MainHand] = weaponItem;
        if (weaponItem.Grip == Grip.TwoHanded)
            _equipmentSlots[EquipmentSlot.OffHand] = weaponItem;

        RemoveItem(weaponItem);
    }

    internal void RemoveItem(ItemBase item)
    {
        _items.Remove(item);
        UpdateData();
    }

    internal void AddItem(ItemBase item)
    {
        _items.Add(item);
        UpdateData();
    }

    internal void AddItems(List<ItemBase> items)
    {
        _items.AddRange(items);
        UpdateData();
    }

    private void UpdateData()
    {
        PrepareItems();
        PrepareEquipment();
    }

    private void PrepareEquipment()
    {
        int i = 0;
        foreach (var equipedItem in _equipmentSlots.Values)
        {
            _data.EquippedItems[i] =
                equipedItem == null
                ? null
                : new ItemSaveData(equipedItem.Type, equipedItem.Id);
            i++;
        }
    }

    private void PrepareItems()
    {
        _data.Items.Clear();
        foreach (var item in _items)
            _data.Items.Add(new ItemSaveData(item.Type, item.Id));
    }
    private bool TryUnequip(EquipmentSlot slot)
    {
        var unequippedItem = _equipmentSlots[slot];
        if (unequippedItem != null)
        {
            AddItem(unequippedItem);
            _equipmentSlots[slot] = null;
            return true;
        }

        return false;
    }

    private void Init()
    {
        InitItems();
        InitEquipment();
    }

    private void InitEquipment()
    {
        _equipmentSlots[EquipmentSlot.Head] = _itemsFactory.CreateOrNull(_data.EquippedItems[0]);
        _equipmentSlots[EquipmentSlot.Hands] = _itemsFactory.CreateOrNull(_data.EquippedItems[1]);
        _equipmentSlots[EquipmentSlot.Body] = _itemsFactory.CreateOrNull(_data.EquippedItems[2]);
        _equipmentSlots[EquipmentSlot.Legs] = _itemsFactory.CreateOrNull(_data.EquippedItems[3]);

        ItemSaveData MainHandItemSaveData = _data.EquippedItems[4];
        ItemSaveData OffHandItemSaveData = _data.EquippedItems[5];
        ItemBase? MainHandItem = _itemsFactory.CreateOrNull(MainHandItemSaveData);
        _equipmentSlots[EquipmentSlot.MainHand] = MainHandItem;

        _equipmentSlots[EquipmentSlot.OffHand] =
            MainHandItemSaveData == null || OffHandItemSaveData == null
            ? _itemsFactory.CreateOrNull(OffHandItemSaveData)
            : MainHandItemSaveData.Type == OffHandItemSaveData.Type && MainHandItemSaveData.Id == OffHandItemSaveData.Id
                ? MainHandItem
                : _itemsFactory.CreateOrNull(OffHandItemSaveData);
    }

    private void InitItems()
    {
        foreach (var itemSaveData in _data.Items)
            _items.Add(_itemsFactory.CreateOrNull(itemSaveData));
    }
}
