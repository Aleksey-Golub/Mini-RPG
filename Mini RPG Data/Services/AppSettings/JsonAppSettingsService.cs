using System.Text.Json;

namespace Mini_RPG_Data.Services.AppSettings;

public class JsonAppSettingsService : IAppSettingsService
{
    private const string APP_SETTINGS_PATH = "AppSettings.json";
    private const string ENGLISH = "English";
    
    private readonly JsonSerializerOptions _options;
    private readonly AppSettingsContainer _appSettingsContainer = new();

    public JsonAppSettingsService()
    {
        _options = new JsonSerializerOptions { IncludeFields = true };

        try
        {
            if (File.Exists(APP_SETTINGS_PATH))
            {
                string text = File.ReadAllText(APP_SETTINGS_PATH);
                _appSettingsContainer = JsonSerializer.Deserialize<AppSettingsContainer>(text, _options);
            }
            else
            {
                SaveAppSettings();
            }
        }
        catch { }
    }

    public string GetCurrentLauguage() => _appSettingsContainer.CurrentLanguage;
    public void SetCurrentLanguage(string newLanguage) => _appSettingsContainer.CurrentLanguage = newLanguage;
    public string GetDefaultLanguage() => ENGLISH;

    public void SaveAppSettings()
    {
        try
        {
            string jsonString = JsonSerializer.Serialize(_appSettingsContainer, _options);

            File.WriteAllText(APP_SETTINGS_PATH, jsonString);
        }
        catch
        {
        }
    }

    [Serializable]
    public class AppSettingsContainer
    {
        public string CurrentLanguage = ENGLISH;
    }
}
