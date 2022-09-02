using Mini_RPG_Data.Datas;
using Mini_RPG_Data.Services.PersistentProgress;
using System.Text.Json;

namespace Mini_RPG_Data.Services.SaveLoad;

public class JsonFileSaveLoadService : ISaveLoadService
{
    private const string FILEPATH_KEY = @"C:\Users\Алексей\Desktop\save.json";
    //private const string FILEPATH_KEY = @"save.json";

    private readonly IPersistentProgressService _progressService;

    public JsonFileSaveLoadService(IPersistentProgressService progressService)
    {
        _progressService = progressService;
    }

    public void SaveProgress()
    {
        try
        {
            string jsonString = JsonSerializer.Serialize(_progressService.Progress);
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
            return JsonSerializer.Deserialize<PlayerProgress>(text);
        }
        catch (Exception e)
        {
            return null;
        }
    }
}
