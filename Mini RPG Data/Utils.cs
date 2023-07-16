using Mini_RPG_Data.Services;
using Mini_RPG_Data.Services.Random_;

namespace Mini_RPG_Data;

public static class Utils
{
    public static List<string> EnumToStringList<T>() where T : Enum
    {
        List<string> list = new();

        string enumToString = typeof(T).ToString();
        string shortName = enumToString.Substring(enumToString.LastIndexOf('.') + 1);
        list.Add(shortName);

        string[] items = Enum.GetNames(typeof(T));
        for (int i = 0; i < items.Length; i++)
            list.Add($"{items[i]} = {i}");

        return list;
    }

    public static T GetRandomEnumValueExcludeFirst<T>() where T : Enum
    {
        IRandomService randomService = AllServices.Container.Single<IRandomService>();

        Array values = Enum.GetValues(typeof(T));
        return (T)values.GetValue(randomService.GetIntInclusive(1, values.Length - 1));
    }
}
