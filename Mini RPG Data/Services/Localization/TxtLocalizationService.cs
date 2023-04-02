namespace Mini_RPG_Data.Services.Localization;

public class TxtLocalizationService : ILocalizationService
{
    private const string DIRECTORY = "Localization\\";
    private const string LANGUAGE_KEY = "language";

    private readonly Dictionary<string, Dictionary<string, string>> _allLocalizations = new Dictionary<string, Dictionary<string, string>>();
    private readonly Dictionary<string, string> _currentLangageSource = new();

    public TxtLocalizationService()
    {
        try
        {
            string[] languagesDirectories = Directory.GetDirectories(DIRECTORY);

            foreach (var dir in languagesDirectories)
            {
                string[] localizationFiles = Directory.GetFiles(dir);
                var localizationSource = new Dictionary<string, string>();
                FillDictionaryFromFiles(localizationSource, localizationFiles);
                
                string languageKey = localizationSource.ContainsKey(LANGUAGE_KEY) ? localizationSource[LANGUAGE_KEY] : dir;

                _allLocalizations.TryAdd(languageKey, localizationSource);
            }
            _currentLangageSource = _allLocalizations["Русский"];
        }
        catch { }
    }

    public event Action? LanguageChanged;

    public string GetLocalization(string localizationKey) => _currentLangageSource.TryGetValue(localizationKey, out var text) ? text : localizationKey;

    private void FillDictionaryFromFiles(Dictionary<string, string> dictionary, params string[] filePaths)
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