namespace Mini_RPG_Data.Services.AppSettings;

public interface IAppSettingsService : IService
{
    string GetCurrentLauguage();
    string GetDefaultLanguage();
    void SaveAppSettings();
    void SetCurrentLanguage(string newLanguage);
}