using Mini_RPG_Data.Services;
using Mini_RPG_Data.Services.Random_;
using System.Text;

namespace Mini_RPG_Data;

public static class Utils
{
    public static string EnumToString<T>() where T : Enum
    {
        var sbItems = new StringBuilder();
        string enumToString = typeof(T).ToString();
        string shortName = enumToString.Substring(enumToString.LastIndexOf('.') + 1);
        sbItems.Append($"{shortName}: ");

        string[] items = Enum.GetNames(typeof(T));
        for (int i = 0; i < items.Length; i++)
            sbItems.Append($"{items[i]} = {i}, ");

        return sbItems.ToString();
    }

    public static T GetRandomEnumValueExcludeFirst<T>() where T : Enum
    {
        IRandomService randomService = AllServices.Container.Single<IRandomService>();

        Array values = Enum.GetValues(typeof(T));
        return (T)values.GetValue(randomService.GetIntInclusive(1, values.Length - 1));
    }
}
