using Mini_RPG_Data.Controllers.Inventory_.Items;
using Mini_RPG_Data.Datas.Inventory_;
using Mini_RPG_Data.Datas.Inventory_.Items;
using System.Text.Json;

namespace Mini_RPG_Data.Services.Items;

public class JsonItemsService : IItemsService
{
    private const string DB_PATH = "ItemsDB.json";
    private readonly ItemsDB? _itemsDB;
    private readonly JsonSerializerOptions _options;

    public JsonItemsService()
    {
        _options = new JsonSerializerOptions { IncludeFields = true };

        try
        {
            string text = File.ReadAllText(DB_PATH);
            _itemsDB = JsonSerializer.Deserialize<ItemsDB>(text, _options);


            //foreach (var item in _itemsDB.CommonItems)
            //    item.Id = item.Name;
            //foreach (var item in _itemsDB.WeaponItems)
            //    item.Id = item.Name;
            //foreach (var item in _itemsDB.ArmorItems)
            //    item.Id = item.Name;
            //foreach (var item in _itemsDB.PotionItems)
            //    item.Id = item.Name;
            //foreach (var item in _itemsDB.FoodItems)
            //    item.Id = item.Name;
            //foreach (var item in _itemsDB.ShieldItems)
            //    item.Id = item.Name;
            //string jsonString = JsonSerializer.Serialize(_itemsDB, _options);
            //File.WriteAllText(DB_PATH, jsonString);
        }
        catch { }

        WriteCommentsToFile("Comments_ItemsDB.json");

        WriteExamplesToFile("ExampleItemsDB.json");
    }

    public ItemDataBase? GetItemDataOrNull(ItemSaveData itemSaveData)
    {
        return itemSaveData.Type switch
        {
            ItemType.Common => _itemsDB.CommonItems.FirstOrDefault(x => x.Id == itemSaveData.Id),
            ItemType.Weapon => _itemsDB.WeaponItems.FirstOrDefault(x => x.Id == itemSaveData.Id),
            ItemType.Armor => _itemsDB.ArmorItems.FirstOrDefault(x => x.Id == itemSaveData.Id),
            ItemType.Potion => _itemsDB.PotionItems.FirstOrDefault(x => x.Id == itemSaveData.Id),
            ItemType.Shield => _itemsDB.ShieldItems.FirstOrDefault(x => x.Id == itemSaveData.Id),
            ItemType.Food => _itemsDB.FoodItems.FirstOrDefault(x => x.Id == itemSaveData.Id),
            ItemType.None => throw new NotImplementedException(),
            _ => throw new NotImplementedException(),
        };
    }

    public ItemDataBase GetRandomItemDataOrNull(ItemType type, int itemRating)
    {
        if (itemRating == -1)
            return type switch
            {
                ItemType.Common => _itemsDB.CommonItems.GetRandomItem(),
                ItemType.Weapon => _itemsDB.WeaponItems.GetRandomItem(),
                ItemType.Armor => _itemsDB.ArmorItems.GetRandomItem(),
                ItemType.Potion => _itemsDB.PotionItems.GetRandomItem(),
                ItemType.Shield => _itemsDB.ShieldItems.GetRandomItem(),
                ItemType.Food => _itemsDB.FoodItems.GetRandomItem(),
                ItemType.None => throw new NotImplementedException(),
                _ => throw new NotImplementedException(),
            };
        else
            return type switch
            {
                ItemType.Common => _itemsDB.CommonItems.Where(x => x.Rating == itemRating).ToList().GetRandomItem(),
                ItemType.Weapon => _itemsDB.WeaponItems.Where(x => x.Rating == itemRating).ToList().GetRandomItem(),
                ItemType.Armor => _itemsDB.ArmorItems.Where(x => x.Rating == itemRating).ToList().GetRandomItem(),
                ItemType.Potion => _itemsDB.PotionItems.Where(x => x.Rating == itemRating).ToList().GetRandomItem(),
                ItemType.Shield => _itemsDB.ShieldItems.Where(x => x.Rating == itemRating).ToList().GetRandomItem(),
                ItemType.Food => _itemsDB.FoodItems.Where(x => x.Rating == itemRating).ToList().GetRandomItem(),
                ItemType.None => throw new NotImplementedException(),
                _ => throw new NotImplementedException(),
            };
    }

    private void WriteCommentsToFile(string localFilePath)
    {
        var comments = new List<string>();
        string divider = "---------------------------------------------";

        comments.AddRange(Utils.EnumToStringList<WeaponType>());
        comments.Add(divider);
        comments.AddRange(Utils.EnumToStringList<DamageType>());
        comments.Add(divider);
        comments.AddRange(Utils.EnumToStringList<Grip>());
        comments.Add(divider);
        comments.AddRange(Utils.EnumToStringList<ArmorType>());
        comments.Add(divider);
        comments.AddRange(Utils.EnumToStringList<EquipmentSlot>());
        comments.Add(divider);
        comments.AddRange(Utils.EnumToStringList<EffectType>());
        comments.Add(divider);
        comments.AddRange(Utils.EnumToStringList<ItemType>());

        try
        {
            string jsonString = JsonSerializer.Serialize(comments, _options);

            File.WriteAllText(localFilePath, jsonString);
        }
        catch
        { }
    }

    private void WriteExamplesToFile(string localFilePath)
    {
        var itemsDB = new ItemsDB();
        itemsDB.CommonItems.Add(new CommonItemData() { Id = "Example", Cost = 10 });
        itemsDB.WeaponItems.Add(new WeaponItemData() { Id = "ExampleWeapon1", Cost = 10, MinDamage = 1, MaxDamage = 2, DamageType = DamageType.Piercing, Grip = Grip.SingleHanded });
        itemsDB.WeaponItems.Add(new WeaponItemData() { Id = "ExampleWeapon2", Cost = 20, MinDamage = 2, MaxDamage = 3, DamageType = DamageType.Bludgeoning, Grip = Grip.TwoHanded & Grip.SingleHanded });
        itemsDB.ArmorItems.Add(new ArmorItemData()   { Id = "ExampleArmor1", Cost = 10, EquipmentSlot = EquipmentSlot.Hands, ArmorValue = 1, ArmorType = ArmorType.Light });
        itemsDB.ArmorItems.Add(new ArmorItemData()   { Id = "ExampleArmor2", Cost = 15, EquipmentSlot = EquipmentSlot.Head, ArmorValue = 1, ArmorType = ArmorType.Light });
        itemsDB.PotionItems.Add(new PotionItemData() { Id = "ExamplePotion1", Cost = 10, Effects = new List<Effect>() { new Effect() { EffectType = EffectType.ChangeHealth, Value = 10 } } });
        itemsDB.ShieldItems.Add(new ShieldItemData() { Id = "ExampleShield1", Cost = 12, MinBlockBonus = 1, MaxBlockBonus = 3 });
        itemsDB.ShieldItems.Add(new ShieldItemData() { Id = "ExampleShield2", Cost = 20, MinBlockBonus = 2, MaxBlockBonus = 4 });
        itemsDB.FoodItems.Add(new FoodItemData()     { Id = "ExampleFood1", Cost = 10, Effects = new List<Effect>() { new Effect() { EffectType = EffectType.ChangeFoodSatiation, Value = 100 } } });
        try
        {
            string jsonString = JsonSerializer.Serialize(itemsDB, _options);

            File.WriteAllText(localFilePath, jsonString);
        }
        catch
        { }
    }

    [Serializable]
    public class ItemsDB
    {
        public List<CommonItemData> CommonItems = new List<CommonItemData>();
        public List<WeaponItemData> WeaponItems = new List<WeaponItemData>();
        public List<ArmorItemData> ArmorItems = new List<ArmorItemData>();
        public List<PotionItemData> PotionItems = new List<PotionItemData>();
        public List<ShieldItemData> ShieldItems = new List<ShieldItemData>();
        public List<FoodItemData> FoodItems = new List<FoodItemData>();
    }
}
