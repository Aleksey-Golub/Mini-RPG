using Mini_RPG_Data.Character_;
using Mini_RPG_Data.Controllers;
using Mini_RPG_Data.Controllers.Character_;
using Mini_RPG_Data.Controllers.Inventory_.Items;
using Mini_RPG_Data.Controllers.Map_;
using Mini_RPG_Data.Services.Localization;

namespace Mini_RPG_Data;

public static class LocalizationExtension
{
    public static string Message_FindTrapSuccess(this ILocalizationService localizationService, TrapType trapType)
    {
        return trapType switch
        {
            TrapType.SpikeTrap => localizationService.GetLocalization("GUI_Message_FindSpikeTrapSuccess"),
            TrapType.BearTrap => localizationService.GetLocalization("GUI_Message_FindBearTrapSuccess"),
            TrapType.None => throw new NotImplementedException(),
            _ => throw new NotImplementedException(),
        };
    }
    public static string Message_FindTrapFail(this ILocalizationService localizationService, TrapType trapType)
    {
        return trapType switch
        {
            TrapType.SpikeTrap => localizationService.GetLocalization("GUI_Message_FindSpikeTrapFail"),
            TrapType.BearTrap => localizationService.GetLocalization("GUI_Message_FindBearTrapFail"),
            TrapType.None => throw new NotImplementedException(),
            _ => throw new NotImplementedException(),
        };
    }

    public static string Message_StartRestInTown(this ILocalizationService localizationService, int restCost) 
        => String.Format(localizationService.GetLocalization("GUI_Message_StartRestInTown"), restCost);
    public static string Message_FirstHitsSecondWithDamage(this ILocalizationService localizationService, string attackerName, string defenderName, int damage) 
        => String.Format(localizationService.GetLocalization("GUI_Message_FirstHitsSecondWithDamage"), attackerName, defenderName, damage);
    public static string Message_FirstHitsSecondWithCriticalDamage(this ILocalizationService localizationService, string attackerName, string defenderName, int damage) 
        => String.Format(localizationService.GetLocalization("GUI_Message_FirstHitsSecondWithCriticalDamage"), attackerName, defenderName, damage);
    public static string Message_FirstMissedSecond(this ILocalizationService localizationService, string attackerName, string defenderName) 
        => String.Format(localizationService.GetLocalization("GUI_Message_FirstMissedSecond"), attackerName, defenderName);
    public static string Message_QuestComplited(this ILocalizationService localizationService, string questLocalizedName) 
        => String.Format(localizationService.GetLocalization("GUI_Message_QuestComplited"), questLocalizedName);

    public static string CharacterGainNewLevel(this ILocalizationService localizationService, string name) 
        => String.Format(localizationService.GetLocalization("CharacterGainNewLevel"), name);

    public static string RaceName(this ILocalizationService localizationService, Race race)
    {
        return race switch
        {
            Race.Dwarf => localizationService.GetLocalization("RaceName_Dwarf"),
            Race.Elf => localizationService.GetLocalization("RaceName_Elf"),
            Race.Human => localizationService.GetLocalization("RaceName_Human"),
            Race.Goblin => localizationService.GetLocalization("RaceName_Goblin"),
            Race.Orc => localizationService.GetLocalization("RaceName_Orc"),
            Race.Beast => localizationService.GetLocalization("RaceName_Beast"),
            Race.None => throw new NotImplementedException(),
            _ => throw new NotImplementedException(),
        };
    }

    public static string HungerLevelName(this ILocalizationService localizationService, HungerLevel hungerLevel)
    {
        return hungerLevel switch
        {
            HungerLevel.Hungry => localizationService.GetLocalization("HungerLevelName_Hungry"),
            HungerLevel.Neutral => localizationService.GetLocalization("HungerLevelName_Neutral"),
            HungerLevel.Satiated => localizationService.GetLocalization("HungerLevelName_Satiated"),
            HungerLevel.None => throw new NotImplementedException(),
            _ => throw new NotImplementedException(),
        };
    }

    public static string ThirstLevelName(this ILocalizationService localizationService, ThirstLevel thirstLevel)
    {
        return thirstLevel switch
        {
            ThirstLevel.Thirsty => localizationService.GetLocalization("ThirstLevelName_Thirsty"),
            ThirstLevel.Neutral => localizationService.GetLocalization("ThirstLevelName_Neutral"),
            ThirstLevel.Satiated => localizationService.GetLocalization("ThirstLevelName_Satiated"),
            ThirstLevel.None => throw new NotImplementedException(),
            _ => throw new NotImplementedException(),
        };
    }

    public static string PlayerMoveSuccessfully(this ILocalizationService localizationService, Direction direction)
    {
        return direction switch
        {
            Direction.N => localizationService.GetLocalization("PlayerMoveSuccessfully_N"),
            Direction.S => localizationService.GetLocalization("PlayerMoveSuccessfully_S"),
            Direction.W => localizationService.GetLocalization("PlayerMoveSuccessfully_W"),
            Direction.E => localizationService.GetLocalization("PlayerMoveSuccessfully_E"),
            Direction.None => throw new NotImplementedException(),
            _ => throw new NotImplementedException(),
        };
    }

    public static string PlayerMoveUnsuccessfully(this ILocalizationService localizationService, Direction direction)
    {
        return direction switch
        {
            Direction.N => localizationService.GetLocalization("PlayerMoveUnsuccessfully_N"),
            Direction.S => localizationService.GetLocalization("PlayerMoveUnsuccessfully_S"),
            Direction.W => localizationService.GetLocalization("PlayerMoveUnsuccessfully_W"),
            Direction.E => localizationService.GetLocalization("PlayerMoveUnsuccessfully_E"),
            Direction.None => throw new NotImplementedException(),
            _ => throw new NotImplementedException(),
        };
    }

    public static string DamageTypeName(this ILocalizationService localizationService, DamageType damageType) => damageType switch
    {
        DamageType.Slashing => localizationService.GetLocalization("DamageTypeName_Slashing"),
        DamageType.Piercing => localizationService.GetLocalization("DamageTypeName_Piercing"),
        DamageType.Bludgeoning => localizationService.GetLocalization("DamageTypeName_Bludgeoning"),
        DamageType.None => throw new NotImplementedException(),
        _ => throw new NotImplementedException(),
    };

    public static string GripName(this ILocalizationService localizationService, Grip grip)
    {
        return grip switch
        {
            Grip.SingleHanded => localizationService.GetLocalization("GripName_SingleHanded"),
            Grip.TwoHanded => localizationService.GetLocalization("GripName_TwoHanded"),
            Grip.None => throw new NotImplementedException(),
            _ => throw new NotImplementedException(),
        };
    }

    public static string ArmorTypeName(this ILocalizationService localizationService, ArmorType armorType)
    {
        return armorType switch
        {
            ArmorType.Light => localizationService.GetLocalization("ArmorTypeName_Light"),
            ArmorType.Medium => localizationService.GetLocalization("ArmorTypeName_Medium"),
            ArmorType.Heavy => localizationService.GetLocalization("ArmorTypeName_Heavy"),
            ArmorType.None => throw new NotImplementedException(),
            _ => throw new NotImplementedException(),
        };
    }

    public static string TrapTypeName(this ILocalizationService localizationService, TrapType trapType)
    {
        return trapType switch
        {
            TrapType.SpikeTrap => localizationService.GetLocalization("TrapTypeName_SpikeTrap"),
            TrapType.BearTrap => localizationService.GetLocalization("TrapTypeName_BearTrap"),
            TrapType.None => throw new NotImplementedException(),
            _ => throw new NotImplementedException(),
        };
    }
}
