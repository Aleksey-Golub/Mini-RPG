﻿using Mini_RPG_Data.Datas;
using Mini_RPG_Data.Services.PersistentProgress;
using System.Text.Json;

namespace Mini_RPG_Data.Services.SaveLoad;

public class JsonFileSaveLoadService : ISaveLoadService
{
    //private const string FILEPATH_KEY = @"C:\Users\Алексей\Desktop\save.json";
    //private const string FILEPATH_KEY = @"save.json";

    private readonly IPersistentProgressService _progressService;
    private readonly JsonSerializerOptions _options;
    private readonly string _savesDirectory;

    public JsonFileSaveLoadService(IPersistentProgressService progressService)
    {
        _progressService = progressService;

        _options = new JsonSerializerOptions { IncludeFields = true };

        _savesDirectory = Settings.SavesDirectory;
    }

    public void SaveProgress()
    {
        try
        {
            _progressService.PrepareForSerialize();
            string jsonString = JsonSerializer.Serialize(_progressService.Progress, _options);
            string name = _progressService.Progress.PlayerData.CharacterData.Name;
            string fileName = $"\\save_{name}.json";

            //File.WriteAllText(FILEPATH_KEY, jsonString);
            bool exists = Directory.Exists(_savesDirectory);
            if (!exists)
                Directory.CreateDirectory(_savesDirectory);

            File.WriteAllText($"{_savesDirectory}{fileName}", jsonString);
        }
        catch (Exception e)
        {
        }
    }

    public PlayerProgress? LoadProgressOrNull(string fullFilePath)
    {
        try
        {
            //string text = File.ReadAllText(FILEPATH_KEY);
            string text = File.ReadAllText(fullFilePath);
            var progress = JsonSerializer.Deserialize<PlayerProgress>(text, _options);
            progress?.PrepareForDeserialize();
            return progress;
        }
        catch (Exception e)
        {
            return null;
        }
    }

    public string[] GetAllSaves() => Directory.GetFiles(_savesDirectory);
}
