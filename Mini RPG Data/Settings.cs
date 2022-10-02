using Mini_RPG_Data.Character_;
using Mini_RPG_Data.Controllers;
using Mini_RPG_Data.Controllers.Character_;
using Mini_RPG_Data.Controllers.Inventory_.Items;
using Mini_RPG_Data.Controllers.Map_;
using Mini_RPG_Data.Datas;
using Mini_RPG_Data.Datas.Inventory_;
using Mini_RPG_Data.Services.Items;
using Mini_RPG_Data.Services.Random_;

namespace Mini_RPG_Data;

public static class Settings
{
    public static IRandomService RandomService;
    public static IItemFactory ItemFactory;

    public const int DEFAULT_FIELD_OF_VIEW = 2;
    public const int EXPERIENCE_DEFAULT_VALUE = 50;
    public const int MAX_LEVEL = 10;
    public const int DEFAULT_ABILITY_VALUE = 7;
    public const int MIN_ABILITY_VALUE = 6;
    public const int MAX_ABILITY_VALUE = 12;
    public const int DEFAULT_ABILITYPOINTS_COUNT = 2; // 2

    public const int HEALTH_RESTORE_VALUE = 1;

    public const int CELL_SPAWN_CHANCE = 10;
    public const int MIN_MAP_CELL_COUNT = 50;
    public const int MAX_MAP_CELL_COUNT = 500;

    public const int START_MONEY = 10;
    public const int START_SATIATION = 500;

    public const int FOREST_IMAGE_COUNT = 14;

    public const int REST_IN_TOWN_COST = 20;

    public static string AvatarsDirectory => $"Avatars";
    public static string DefaultAvatarPath => $"{AvatarsDirectory}\\Avatar_Human_1.png";

    public static string SavesDirectory => $"{AppDomain.CurrentDomain.BaseDirectory}Saves";

    internal static int CalculateStarve(Character character, SatiationData data) => 2;
    internal static HungerLevel CalculateHungerLevel(Character character, SatiationData data)
    {
        return data.FoodSatiation switch
        {
            >= 300 => HungerLevel.Satiated,
            >= 100 => HungerLevel.Neutral,
            _ => HungerLevel.Hungry,
        };
    }

    internal static int CalculateThirst(Character character, SatiationData data) => 2;
    internal static ThirstLevel CalculateThirstLevel(Character character, SatiationData data)
    {
        return data.WaterSatiation switch
        {
            >= 300 => ThirstLevel.Satiated,
            >= 100 => ThirstLevel.Neutral,
            _ => ThirstLevel.Thirsty,
        };
    }

    internal static int CalculateRequiredForNextLevelExperience(int currentLevel)
    {
        if (currentLevel == 1)
            return EXPERIENCE_DEFAULT_VALUE;

        return (int)(CalculateRequiredForNextLevelExperience(currentLevel - 1) * 1.5f);
    }

    internal static int CalculateFieldOfView(Character character) =>
        DEFAULT_FIELD_OF_VIEW + character.AllAbilities.Perception.Bonus.DividedByAndCeiling(divider: 2);

    internal static int CalculateMaxHealth(Character character) =>
        character.AllAbilities.Constitution.Value + character.AllAbilities.Constitution.Bonus * Settings.CalculateLevelModifier(character.Level.Value);

    internal static int CalculateLevelModifier(int level)
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

    internal static TownTraderData GetRandomTownTraderData()
    {
        var townTraderData = new TownTraderData();
        townTraderData.WalletData.Money = 1000;
        TryAddRandomItemSaveData(townTraderData, ItemType.Food, 2);
        TryAddRandomItemSaveData(townTraderData, ItemType.Food, 2);
        TryAddRandomItemSaveData(townTraderData, ItemType.Food);
        TryAddRandomItemSaveData(townTraderData, ItemType.Food);
        TryAddRandomItemSaveData(townTraderData, ItemType.Food);
        TryAddRandomItemSaveData(townTraderData, ItemType.Food);
        TryAddRandomItemSaveData(townTraderData, ItemType.Potion);
        TryAddRandomItemSaveData(townTraderData, ItemType.Potion);
        TryAddRandomItemSaveData(townTraderData, ItemType.Armor);
        TryAddRandomItemSaveData(townTraderData, ItemType.Armor);
        TryAddRandomItemSaveData(townTraderData, ItemType.Shield);
        TryAddRandomItemSaveData(townTraderData, ItemType.Shield);
        TryAddRandomItemSaveData(townTraderData, ItemType.Weapon);
        TryAddRandomItemSaveData(townTraderData, ItemType.Weapon);

        return townTraderData;
    }

    private static void TryAddRandomItemSaveData(TownTraderData townTraderData, ItemType itemType = ItemType.None, int itemRating = -1)
    {
        var item = ItemFactory.CreateRandomOrNull(itemType, itemRating);
        if (item != null)
            townTraderData.InventoryData.Items.Add(new ItemSaveData(item.Type, item.Id));
    }

    internal static bool CheckHealthRecoveryAfterRest(Character character)
    {
        // Если голода и жажды нет, а второй показатель - насыщен, то возможна регенерация:
        // 2D6 + бонус ВЫН >= 12(или 10, если оба "насыщен")

        HungerLevel hungerLevel = character.Satiation.HungerLevel;
        ThirstLevel thirstLevel = character.Satiation.ThirstLevel;

        if (hungerLevel == HungerLevel.Hungry || thirstLevel == ThirstLevel.Thirsty)
            return false;

        if (hungerLevel == HungerLevel.Neutral && thirstLevel == ThirstLevel.Neutral)
            return false;

        int value =
            hungerLevel == HungerLevel.Satiated && thirstLevel == ThirstLevel.Satiated
            ? 10
            : 12;

        return RandomService.Get1D6(2) + character.AllAbilities.Constitution.Bonus >= value;
    }

    internal static int CalculateFoundedInLootMoney(Player player)
    {
        int playerLevel = player.Character.Level.Value;
        int min = 0;
        int max = 10 * playerLevel;

        return RandomService.GetIntInclusive(min, max);
    }

    internal static int CalculateFoundedInChestMoney(Player player) => CalculateFoundedInLootMoney(player) * 2;
    internal static int CalculateFoundedInHiddenLootMoney(Player player) => CalculateFoundedInLootMoney(player) * 2;

    internal static bool TryPickLock(Player player)
    {
        // 2D6 + 5(bonus) >= 7 + (12 - 7) * (10 lvl - 1/10-1) // lerp 0 - 1 // if lvl == 10 and maxLvl == 10
        // lvl 1 - 0
        // lvl 2 - 1
        // lvl 3,4 - 2
        // lvl 5,6 - 3
        // lvl 7,8 - 4
        // lvl 9,10 - 5 if maxLvl == 10

        int _2D6 = RandomService.Get1D6(2);

        if (IsCriticalFail(_2D6))
            return false;
        if (IsCriticalSuccess(_2D6))
            return true;

        return _2D6 + player.Character.AllAbilities.Dexterity.Bonus >= 7 + (MAX_ABILITY_VALUE - DEFAULT_ABILITY_VALUE) * ((player.Character.Level.Value - 1) / (MAX_LEVEL - 1));
    }

    internal static List<ItemBase> CalculateFoundedLoot(Player player)
    {
        List<ItemBase> loot = new List<ItemBase>();

        TryAddRandomItem(50, loot, ItemType.Food, 1);

        return loot;
    }

    internal static List<ItemBase> CalculateFoundedHiddenLoot(Player player)
    {
        List<ItemBase> loot = new List<ItemBase>();

        TryAddRandomItem(50, loot, ItemType.Food, 2);
        TryAddRandomItem(10, loot, ItemType.Potion, 1);

        return loot;
    }

    internal static List<ItemBase> CalculateFoundedInChestLoot(Player player)
    {
        List<ItemBase> loot = new List<ItemBase>();

        TryAddRandomItem(50, loot, ItemType.Food);
        TryAddRandomItem(10, loot, ItemType.Potion, 2);
        TryAddRandomItem(10, loot, ItemType.Weapon, 2);
        TryAddRandomItem(10, loot, ItemType.Shield, 2);
        TryAddRandomItem(10, loot, ItemType.Armor, 2);

        return loot;
    }

    private static bool TryAddRandomItem(int chance, List<ItemBase> loot, ItemType itemType, int itemRating = -1)
    {
        if (RandomService.Get1D100() <= chance)
        {
            ItemBase? item = ItemFactory.CreateRandomOrNull(itemType, itemRating);
            if (item != null)
            {
                loot.Add(item);
                return true;
            }
        }

        return false;
    }

    internal static bool TryBreakChest(Player player)
    {
        int _2D6 = RandomService.Get1D6(2);

        if (IsCriticalFail(_2D6))
            return false;
        if (IsCriticalSuccess(_2D6))
            return true;

        return _2D6 + player.Character.AllAbilities.Strength.Bonus >= 7 + (MAX_ABILITY_VALUE - DEFAULT_ABILITY_VALUE) * ((player.Character.Level.Value - 1) / (MAX_LEVEL - 1));
    }

    internal static bool TryFindHiddenLoot(Player player)
    {
        int _2D6 = RandomService.Get1D6(2);

        if (IsCriticalFail(_2D6))
            return false;
        if (IsCriticalSuccess(_2D6))
            return true;

        return _2D6 + player.Character.AllAbilities.Perception.Bonus >= 7 + (MAX_ABILITY_VALUE - DEFAULT_ABILITY_VALUE) * ((player.Character.Level.Value - 1) / (MAX_LEVEL - 1));
    }

    internal static bool TryFindTrap(Player player)
    {
        int _2D6 = RandomService.Get1D6(2);

        if (IsCriticalFail(_2D6))
            return false;
        if (IsCriticalSuccess(_2D6))
            return true;

        return _2D6 + player.Character.AllAbilities.Perception.Bonus * 2 >= 7 + (MAX_ABILITY_VALUE - DEFAULT_ABILITY_VALUE) * ((player.Character.Level.Value - 1) / (MAX_LEVEL - 1));

    }

    internal static TrapType GetTrapType() => Utils.GetRandomEnumValueExcludeFirst<TrapType>();

    internal static int CalculateTrapDamage(TrapType trapType, Player player)
    {
        float v = (float)player.Character.Level.Value / 3;
        v = MathF.Ceiling(v);
        int multiplier = (int)v;

        return trapType switch
        {
            TrapType.SpikeTrap => RandomService.Get1D3(multiplier),
            TrapType.BearTrap => RandomService.Get1D6(multiplier),
            TrapType.None => throw new NotImplementedException(),
            _ => throw new NotImplementedException(),
        };
    }
    public static int CalculateItemCostModifier(int itemCost, Player player) => (int)(itemCost * (0.5f + 0.1f * player.Character.AllAbilities.Charisma.Bonus));
    private static bool IsCriticalFail(int _2D6) => _2D6 == 2;
    private static bool IsCriticalSuccess(int _2D6) => _2D6 == 12;
}