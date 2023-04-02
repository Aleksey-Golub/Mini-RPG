namespace Mini_RPG_Data.Services.Localization;

public interface ILocalizationService : IService
{
    string GetLocalization(string localizationKey);
    
    event Action? LanguageChanged;
}
