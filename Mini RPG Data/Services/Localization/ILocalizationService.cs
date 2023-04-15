namespace Mini_RPG_Data.Services.Localization;

public interface ILocalizationService : IService
{
    IReadOnlyList<string> AvailableLanguages { get; }
    event Action? LanguageChanged;

    string GetLocalization(string localizationKey);
    void SetCurrentLanguage(string selectedLanguage);
}
