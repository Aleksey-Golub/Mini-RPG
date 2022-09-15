using Mini_RPG_Data.Map_;

namespace Mini_RPG_Data;

public static class Settings
{
    public const int EXPERIENCE_DEFAULT_VALUE = 50;
    public const int MAX_LEVEL = 10;
    public const int DEFAULT_ABILITY_VALUE = 7;
    public const int MIN_ABILITY_VALUE = 2;
    public const int MAX_ABILITY_VALUE = 12;

    public const int CELL_SPAWN_CHANCE = 10;
    public const int MIN_MAP_CELL_COUNT = 50;
    public const int MAX_MAP_CELL_COUNT = 500;
    public const int DEFAULT_ABILITYPOINTS_COUNT = 2; // 2

    public static string AvatarsDirectory => $"{AppDomain.CurrentDomain.BaseDirectory}Avatars";
    public static string DefaultAvatarPath => $"{AvatarsDirectory}\\Avatar_Human_1.png";

    public static string SavesDirectory => $"{AppDomain.CurrentDomain.BaseDirectory}Saves";

    public static int CalculateRequiredForNextLevelExperience(int currentLevel)
    {
        if (currentLevel == 1)
            return EXPERIENCE_DEFAULT_VALUE;

        return (int)(CalculateRequiredForNextLevelExperience(currentLevel - 1) * 1.5f);
    }

    public static int CalculateLevelModifier(int level)
    {
        float res = (float)level / 2;
        res = MathF.Ceiling(res);
        return (int)res;
    }

    /// <summary>
    /// Get CellType Based On Random Value within [1, 100] or throw Exception
    /// </summary>
    /// <param name="value">within [1, 100]</param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    internal static CellType GetCellTypeBasedOnRandomValue(int value)
    {
        if (value < 1 || value > 100)
            throw new ArgumentOutOfRangeException("The value have be within 1 to 100");

        switch (value)
        {
            case <= 89:
                return CellType.Empty;
            case <= 93:
                return CellType.Enemy;
            case <= 95:
                return CellType.HiddedLoot;
            case <= 96:
                return CellType.LockedChest;
            case <= 98:
                return CellType.Loot;
            case <= 100:
                return CellType.Trap;

            default:
                throw new NotImplementedException($"Not inplement CellType for {value}");
        }
    }
}