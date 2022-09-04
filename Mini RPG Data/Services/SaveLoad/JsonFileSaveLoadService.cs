using Mini_RPG_Data.Datas;
using Mini_RPG_Data.Map;
using Mini_RPG_Data.Player_;
using Mini_RPG_Data.Services.PersistentProgress;
using System.Text.Json;

namespace Mini_RPG_Data.Services.SaveLoad;

public class JsonFileSaveLoadService : ISaveLoadService
{
    private const string FILEPATH_KEY = @"C:\Users\Алексей\Desktop\save.json";
    //private const string FILEPATH_KEY = @"save.json";

    private readonly IPersistentProgressService _progressService;
    private readonly JsonSerializerOptions _options;

    public JsonFileSaveLoadService(IPersistentProgressService progressService)
    {
        _progressService = progressService;

        _options = new JsonSerializerOptions { IncludeFields = true };
    }

    public void SaveProgress()
    {
        try
        {
            //string jsonString = JsonSerializer.Serialize(_progressService.Progress);
            //string jsonString = JsonSerializer.Serialize(new Vector2Int(10,5));
            string jsonString = JsonSerializer.Serialize(_progressService.Progress.PlayerData, _options);
            File.WriteAllText(FILEPATH_KEY, jsonString);
        }
        catch (Exception e)
        {
        }
    }

    public PlayerProgress? LoadProgressOrNull()
    {
        try
        {
            string text = File.ReadAllText(FILEPATH_KEY);
            return JsonSerializer.Deserialize<PlayerProgress>(text, _options);
        }
        catch (Exception e)
        {
            return null;
        }
    }
   
    public PlayerData? LoadPlayerDataOrNull()
    {
        try
        {
            string text = File.ReadAllText(FILEPATH_KEY);
            return JsonSerializer.Deserialize<PlayerData>(text, _options);
        }
        catch (Exception e)
        {
            return null;
        }
    }

    public MapData? LoadMapDataOrNull()
    {
        try
        {
            string text = File.ReadAllText(FILEPATH_KEY);
            return JsonSerializer.Deserialize<MapData>(text, _options);
        }
        catch (Exception e)
        {
            return null;
        }
    }
}
