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
    public const int EXPERIENCE_DEFAULT_VALUE = 30;
    public const int MAX_LEVEL = 10;
    public const int DEFAULT_ABILITY_VALUE = 7;
    public const int MIN_ABILITY_VALUE = 6;
    public const int MAX_ABILITY_VALUE = 12;
    public const int DEFAULT_ABILITYPOINTS_COUNT = 0;

    public const int HEALTH_RESTORE_VALUE = 1;

    public const int CELL_SPAWN_CHANCE = 10;
    public const int MIN_MAP_CELL_COUNT = 50;
    public const int MAX_MAP_CELL_COUNT = 500;

    public const int START_MONEY = 10;
    public const int START_SATIATION = 500;

    public const int FOREST_IMAGE_COUNT = 14;

    public const int REST_IN_TOWN_COST = 50;

    public const int RANDOM_ENEMY_LEVEL_RANGE = 1;

    public const float CRIT_DAMAGE_MULTIPLIER = 1.5f;

    public static string AvatarsDirectory => $"Avatars";
    public static string DefaultAvatarPath => $"{AvatarsDirectory}\\Avatar_Human_1.png";

    internal static int CalculateInitiative(ICharacter character) => RandomService.Get1D6() + character.InitiativeModifier;
    internal static int CalculateStarve(ICharacter character, SatiationData data) => 2;
    internal static HungerLevel CalculateHungerLevel(ICharacter character, SatiationData data)
    {
        return data.FoodSatiation switch
        {
            >= 300 => HungerLevel.Satiated,
            >= 100 => HungerLevel.Neutral,
            _ => HungerLevel.Hungry,
        };
    }

    internal static int CalculateThirst(ICharacter character, SatiationData data) => 2;
    internal static ThirstLevel CalculateThirstLevel(ICharacter character, SatiationData data)
    {
        return data.WaterSatiation switch
        {
            >= 300 => ThirstLevel.Satiated,
            >= 100 => ThirstLevel.Neutral,
            _ => ThirstLevel.Thirsty,
        };
    }

    internal static int CalculateMaxHealth(Character character) =>
        character.AllAbilities.Constitution.Value + character.AllAbilities.Constitution.Bonus * Settings.CalculateLevelModifier(character.Level.Value);

    internal static int CalculateRequiredForNextLevelExperience(int currentLevel)
    {
        if (currentLevel == 1)
            return EXPERIENCE_DEFAULT_VALUE;

        return (int)(CalculateRequiredForNextLevelExperience(currentLevel - 1) * 2.2f);
    }

    internal static int CalculateFieldOfView(Character character) =>
        DEFAULT_FIELD_OF_VIEW + character.AllAbilities.Perception.Bonus.DividedByAndCeiling(divider: 2);

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
        TryAddRandomItemSaveData(townTraderData, ItemType.Potion);
        TryAddRandomItemSaveData(townTraderData, ItemType.Potion);
        TryAddRandomItemSaveData(townTraderData, ItemType.Armor);
        TryAddRandomItemSaveData(townTraderData, ItemType.Armor);
        TryAddRandomItemSaveData(townTraderData, ItemType.Armor);
        TryAddRandomItemSaveData(townTraderData, ItemType.Shield);
        TryAddRandomItemSaveData(townTraderData, ItemType.Shield);
        TryAddRandomItemSaveData(townTraderData, ItemType.Weapon);
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
        int min = 1;
        int max = 20;

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

    public static int CalculateItemCostModifier(int itemCost, Player player) => (int)(itemCost * (0.3f + 0.1f * player.Character.AllAbilities.Charisma.Bonus));

    internal static int CalculateAttackModifier(Character character)
    {
        // дальнобойное - только ЛОВ
        // мили 1руч - или СИЛ, или ЛОВ
        // мили 1руч+щит или 2руч - СИЛ
        int strBonus = character.AllAbilities.Strength.Bonus;
        int dexBonus = character.AllAbilities.Dexterity.Bonus;
        WeaponItem? mainWeapon = character.Inventory.EquipmentSlots[EquipmentSlot.MainHand] as WeaponItem;
        ItemBase? offHandItem = character.Inventory.EquipmentSlots[EquipmentSlot.OffHand];

        // hand-to-hand
        if (mainWeapon == null)
            return strBonus > dexBonus ? strBonus : dexBonus;
        // range
        else if (mainWeapon.WeaponType == WeaponType.Range)
            return dexBonus;
        // 1-handed + free offHand
        else if (mainWeapon.WeaponType == WeaponType.Melee && offHandItem == null)
            return strBonus > dexBonus ? strBonus : dexBonus;
        // 1-handed + shield
        else if (mainWeapon.WeaponType == WeaponType.Melee && offHandItem is ShieldItem)
            return strBonus;
        // 2-handed
        else if (mainWeapon.WeaponType == WeaponType.Melee && mainWeapon == offHandItem)
            return strBonus;
        else
            throw new NotImplementedException();
    }

    internal static int CalculateDefenseModifier(Character character)
    {
        // уклониться (бонус ЛОВ, ограничен показателем брони и шлема),
        // блокировать (бонус СИЛ, ограничен показателем щита)
        int dodgePenalty = character.Inventory.DodgePenalty;
        int dodge = character.AllAbilities.Dexterity.Bonus - dodgePenalty;

        var shield = character.Inventory.EquipmentSlots[EquipmentSlot.OffHand] as ShieldItem;

        if (shield == null)
            return dodge;

        int block = Math.Clamp(character.AllAbilities.Strength.Bonus, shield.MinBlockBonus, shield.MaxBlockBonus);

        return dodge > block ? dodge : block;
    }

    internal static int MinHandToHandDamage(Character character) => 1;
    internal static int MaxHandToHandDamage(Character character) => 1;
    internal static DamageType HandToHandDamageType(Character character) => DamageType.Bludgeoning;
    internal static Armor ArmorForNoArmorSlot(Character character) => new Armor(0, ArmorType.Light);

    internal static (string attackerName, string defenderName, int damage, bool isSuccess, bool isCrit) HandleAttack(ICharacter attacker, ICharacter defender)
    {
        int _2D6 = RandomService.Get1D6(2);

        bool attackSuccess = _2D6 + attacker.AttackModifier >= 7 + defender.DefenseModifier;
        if (IsCriticalFail(_2D6))
            attackSuccess = false;
        if (IsCriticalSuccess(_2D6))
            attackSuccess = true;

        if (attackSuccess == false)
            return (attacker.Name, defender.Name, 0, false, false);

        
        (int damage, bool isCrit) res = CalculateDamage(attacker, defender);
        defender.TakeDamage(res.damage);

        return (attacker.Name, defender.Name, res.damage, true, res.isCrit);
    }

    private static BodyPart GetHittedBodyPart() => Utils.GetRandomEnumValueExcludeFirst<BodyPart>();
    private static (int damage, bool isCrit) CalculateDamage(ICharacter attacker, ICharacter target)
    {
        DamageType damageType = attacker.DamageType;
        int rawDamage = RandomService.GetIntInclusive(attacker.MinDamage, attacker.MaxDamage) + attacker.AttackModifier;
        BodyPart bodyPart = GetHittedBodyPart();

        Armor armor = target.GetArmor(bodyPart);
        float vulnerabilityСoefficient = CalculateVulnerabilityСoefficientFor(armor.Type, damageType);
        bool isCrit = target.IsAttackCritical(bodyPart);
        float critModifier = isCrit ? CRIT_DAMAGE_MULTIPLIER : 1f;

        int damage = (int)((rawDamage - (armor.Value * vulnerabilityСoefficient)) * critModifier);
        damage = Math.Clamp(damage, 0, int.MaxValue);
        return (damage, isCrit);

        float CalculateVulnerabilityСoefficientFor(ArmorType armorType, DamageType damageType)
        {
            switch (armorType)
            {
                case ArmorType.Light:
                    return damageType switch
                    {
                        DamageType.Slashing => 0.5f,
                        DamageType.Piercing => 1,
                        DamageType.Bludgeoning => 1,
                        DamageType.None => throw new NotImplementedException(),
                        _ => throw new NotImplementedException(),
                    };
                case ArmorType.Medium:
                    return damageType switch
                    {
                        DamageType.Slashing => 1,
                        DamageType.Piercing => 0.5f,
                        DamageType.Bludgeoning => 1,
                        DamageType.None => throw new NotImplementedException(),
                        _ => throw new NotImplementedException(),
                    };
                case ArmorType.Heavy:
                    return damageType switch
                    {
                        DamageType.Slashing => 1,
                        DamageType.Piercing => 1,
                        DamageType.Bludgeoning => 0.5f,
                        DamageType.None => throw new NotImplementedException(),
                        _ => throw new NotImplementedException(),
                    };
                default:
                case ArmorType.None:
                    throw new NotImplementedException();
            }
        }
    }

    internal static int CalculateExperience(Character character)
    {
        return character.Level.Value * 12;
    }

    internal static bool HandlePlayerBattleEscape(Character character) => RandomService.Get1D100() <= 50 + character.AllAbilities.Perception.Bonus * 4;

    private static bool IsCriticalFail(int _2D6) => _2D6 == 2;
    private static bool IsCriticalSuccess(int _2D6) => _2D6 == 12;
}