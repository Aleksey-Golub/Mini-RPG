using Mini_RPG_Data.Services.AppSettings;

namespace Mini_RPG_Data.Services.Localization;

public class TxtLocalizationService : ILocalizationService
{
    private const string DIRECTORY = "Localization\\";
    private const string LANGUAGE_KEY = "language";

    private readonly IAppSettingsService _appSettingsService;
    private readonly Dictionary<string, Dictionary<string, string>> _allLocalizations = new Dictionary<string, Dictionary<string, string>>();
    private readonly List<string> _availableLanguages = new();
    
    private Dictionary<string, string> _currentLanguageSource = new();

    public IReadOnlyList<string> AvailableLanguages => _availableLanguages;

    public event Action? LanguageChanged;

    public TxtLocalizationService(IAppSettingsService appSettings)
    {
        _appSettingsService = appSettings;

        try
        {
            string[] languagesDirectories = Directory.GetDirectories(DIRECTORY);

            foreach (var dir in languagesDirectories)
            {
                string[] localizationFiles = Directory.GetFiles(dir);
                var localizationSource = new Dictionary<string, string>();
                FillSourceFromFiles(localizationSource, localizationFiles);

                string languageKey = localizationSource.ContainsKey(LANGUAGE_KEY) ? localizationSource[LANGUAGE_KEY] : dir;

                if (_allLocalizations.TryAdd(languageKey, localizationSource))
                    _availableLanguages.Add(languageKey);
            }
            _currentLanguageSource = GetCurrentLanguageSource();
        }
        catch { }
    }

    public string GetLocalization(string localizationKey) => _currentLanguageSource.TryGetValue(localizationKey, out var text) ? text : localizationKey;

    public void SetCurrentLanguage(string selectedLanguage)
    {
        _appSettingsService.SetCurrentLanguage(selectedLanguage);
        _currentLanguageSource = GetCurrentLanguageSource();
        LanguageChanged?.Invoke();

        _appSettingsService.SaveAppSettings();
    }

    private Dictionary<string, string> GetCurrentLanguageSource()
    {
        string currentLanguage = _appSettingsService.GetCurrentLauguage();
        string defaultLanguage = _appSettingsService.GetDefaultLanguage();
        
        if (_allLocalizations.ContainsKey(currentLanguage))
            return _allLocalizations[currentLanguage];
        else if (_allLocalizations.ContainsKey(defaultLanguage))
            return _allLocalizations[defaultLanguage];
        else
            return _allLocalizations.First().Value;
    }

    private void FillSourceFromFiles(Dictionary<string, string> dictionary, params string[] filePaths)
    {
        foreach (var filePath in filePaths)
        {
            try
            {
                string[] strs = File.Exists(filePath) ? File.ReadAllLines(filePath) : new string[] {"000"};

                foreach (var str in strs)
                {
                    // string like "key = value"
                    int index = str.IndexOf("=");
                    if (index != -1)
                    {
                        string key = str.Substring(0, index - 1);
                        string value = str.Substring(index + 2);
                        value = FormatText(value);
                        dictionary[key] = value;
                    }
                }
            }
            catch { }
        }
    }

    private static string FormatText(string value)
    {
        return value.Replace("\\n", Environment.NewLine);
    }
}