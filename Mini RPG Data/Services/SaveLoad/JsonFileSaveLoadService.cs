using Mini_RPG_Data.Datas;
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
            _progressService.PrepareForSerialize();
            string jsonString = JsonSerializer.Serialize(_progressService.Progress, _options);

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
            var progress = JsonSerializer.Deserialize<PlayerProgress>(text, _options);
            progress.PrepareForDeserialize();
            return progress;
        }
        catch (Exception e)
        {
            return null;
        }
    }
}
