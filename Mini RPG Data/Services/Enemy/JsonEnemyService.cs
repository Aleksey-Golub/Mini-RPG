using Mini_RPG_Data.Character_;
using Mini_RPG_Data.Controllers.Inventory_.Items;
using Mini_RPG_Data.Datas.Enemy_.EnemiesDB;
using Mini_RPG_Data.Datas.Inventory_;
using System.Text.Json;

namespace Mini_RPG_Data.Services.Enemy;

public class JsonEnemyService : IEnemyService
{
    private const string DB_PATH = "EnemyDB.json";
    private readonly EnemyDB? _enemyDB;
    private readonly JsonSerializerOptions _options;

    public JsonEnemyService()
    {
        _options = new JsonSerializerOptions { IncludeFields = true };

        try
        {
            string text = File.ReadAllText(DB_PATH);
            _enemyDB = JsonSerializer.Deserialize<EnemyDB>(text, _options);


            foreach (var enemy in _enemyDB.Characters)
                enemy.Id = enemy.Name;
            foreach (var enemy in _enemyDB.Beasts)
                enemy.CharacterData.Id = enemy.CharacterData.Name;
            string jsonString = JsonSerializer.Serialize(_enemyDB, _options);
            File.WriteAllText(DB_PATH, jsonString);
        }
        catch { }

        WriteCommentsToFile("Comments_EnemyDB.json");

        WriteExamplesToFile("ExampleEnemyDB.json");
    }

    public BeastEnemyDataBase? GetRandomBeastEnemyDataOrNull(int enemyLevel) => _enemyDB.Beasts.Where(x => x.CharacterData.LevelData.Value == enemyLevel).ToList().GetRandomItem()?.Copy();
    public CharacterData? GetRandomCharacterEnemyDataOrNull(int enemyLevel) => _enemyDB.Characters.Where(x => x.LevelData.Value == enemyLevel).ToList().GetRandomItem()?.Copy();

    private void WriteCommentsToFile(string localFilePath)
    {
        var comments = new List<string>();

        comments.Add(Utils.EnumToString<Race>());
        comments.Add(Utils.EnumToString<DamageType>());
        comments.Add(Utils.EnumToString<ArmorType>());
        comments.Add(Utils.EnumToString<ItemType>());

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
        var enemyDB = new EnemyDB();
        enemyDB.Characters.Add(new CharacterData() { InventoryData = new InventoryData() { Items = new List<ItemSaveData>() { new ItemSaveData(ItemType.Common, "0"), new ItemSaveData(ItemType.Common, "1")} } });
        enemyDB.Characters.Add(new CharacterData() { InventoryData = new InventoryData() { Items = new List<ItemSaveData>() { new ItemSaveData(ItemType.Common, "0")} } });
        enemyDB.Beasts.Add(new BeastEnemyDataBase());
        enemyDB.Beasts.Add(new BeastEnemyDataBase());
        try
        {
            string jsonString = JsonSerializer.Serialize(enemyDB, _options);

            File.WriteAllText(localFilePath, jsonString);
        }
        catch
        { }
    }

    [Serializable]
    public class EnemyDB
    {
        public List<CharacterData> Characters = new List<CharacterData>();
        public List<BeastEnemyDataBase> Beasts = new List<BeastEnemyDataBase>();
    }
}
