using System.Text;

namespace Mini_RPG;

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
}
