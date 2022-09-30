using Mini_RPG;
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
        }
        catch { }

        WriteCommentsToFile("Comments_ItemsDB.json");

        WriteExamplesToFile("ExampleItemsDB.json");
    }

    public CommonItemData? GetCommonItemDataByIdOrNull(int id) => _itemsDB.CommonItems.FirstOrDefault(x => x.Id == id);
    public WeaponItemData? GetWeaponItemDataByIdOrNull(int id) => _itemsDB.WeaponItems.FirstOrDefault(x => x.Id == id);
    public ArmorItemData? GetArmorItemDataByIdOrNull(int id) => _itemsDB.ArmorItems.FirstOrDefault(x => x.Id == id);
    public PotionItemData? GetPotionItemDataByIdOrNull(int id) => _itemsDB.PotionItems.FirstOrDefault(x => x.Id == id);
    public ShieldItemData? GetShieldItemDataByIdOrNull(int id) => _itemsDB.ShieldItems.FirstOrDefault(x => x.Id == id);
    public FoodItemData? GetFoodItemDataByIdOrNull(int id) => _itemsDB.FoodItems.FirstOrDefault(x => x.Id == id);

    public ItemDataBase GetRandomItem(ItemType type)
    {
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
    }

    private void WriteCommentsToFile(string localFilePath)
    {
        var comments = new List<string>();

        comments.Add(Utils.EnumToString<DamageType>());
        comments.Add(Utils.EnumToString<Grip>());
        comments.Add(Utils.EnumToString<ArmorType>());
        comments.Add(Utils.EnumToString<EquipmentSlot>());
        comments.Add(Utils.EnumToString<EffectType>());

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
        itemsDB.CommonItems.Add(new CommonItemData() { Id = 0, Name = "Example", Cost = 10 });
        itemsDB.WeaponItems.Add(new WeaponItemData() { Id = 0, Name = "ExampleWeapon1", Cost = 10, MinDamage = 1, MaxDamage = 2, DamageType = DamageType.Piercing, Grip = Grip.SingleHanded });
        itemsDB.WeaponItems.Add(new WeaponItemData() { Id = 1, Name = "ExampleWeapon2", Cost = 20, MinDamage = 2, MaxDamage = 3, DamageType = DamageType.Bludgeoning, Grip = Grip.TwoHanded & Grip.SingleHanded });
        itemsDB.ArmorItems.Add(new ArmorItemData() { Id = 0, Name = "ExampleArmor1", Cost = 10, EquipmentSlot = EquipmentSlot.Hands, ArmorValue = 1, ArmorType = ArmorType.Light });
        itemsDB.ArmorItems.Add(new ArmorItemData() { Id = 1, Name = "ExampleArmor2", Cost = 15, EquipmentSlot = EquipmentSlot.Head, ArmorValue = 1, ArmorType = ArmorType.Light });
        itemsDB.PotionItems.Add(new PotionItemData() { Id = 0, Name = "ExamplePotion1", Cost = 10, Effects = new List<Effect>() { new Effect() { EffectType = EffectType.ChangeHealth, Value = 10 } } });
        itemsDB.FoodItems.Add(new FoodItemData() { Id = 0, Name = "ExampleFood1", Cost = 10, Effects = new List<Effect>() { new Effect() { EffectType = EffectType.ChangeFoodSatiation, Value = 100 } } });
        itemsDB.ShieldItems.Add(new ShieldItemData() { Id = 0, Name = "ExampleShield1", Cost = 12, MinBlockBonus = 1, MaxBlockBonus = 3 });
        itemsDB.ShieldItems.Add(new ShieldItemData() { Id = 1, Name = "ExampleShield2", Cost = 20, MinBlockBonus = 2, MaxBlockBonus = 4 });
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
        public List<FoodItemData> FoodItems = new List<FoodItemData>();
        public List<ShieldItemData> ShieldItems = new List<ShieldItemData>();
    }
}
