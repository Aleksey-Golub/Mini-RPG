using Mini_RPG_Data.Character_;
using Mini_RPG_Data.Controllers;
using Mini_RPG_Data.Controllers.Character_;
using Mini_RPG_Data.Controllers.Inventory_.Items;
using Mini_RPG_Data.Controllers.Map_;
using Mini_RPG_Data.Controllers.Quest_;

namespace Mini_RPG_Data.Services.Localization;

public interface ILocalizationService : IService
{
    event Action? LanguageChanged;

    string GetLocalization(string localizationKey);

    string RaceName(Race race);
    string HungerLevelName(HungerLevel hungerLevel);
    string ThirstLevelName(ThirstLevel thirstLevel);
    string PlayerMoveSuccessfully(Direction direction);
    string DamageTypeName(DamageType damageType);
    string GripName(Grip grip);
    string PlayerMoveUnsuccessfully(Direction direction);
    string Message_FindTrapSuccess(TrapType trapType);
    string Message_FindTrapFail(TrapType trapType);
    string ArmorTypeName(ArmorType armorType);
    string TrapTypeName(TrapType trapType);
    string Message_StartRestInTown(int restCost);
    string CharacterGainNewLevel(string name);
    string Message_FirstMissedSecond(string attackerName, string defenderName);
    string Message_FirstHitsSecondWithDamage(string attackerName, string defenderName, int damage);
    string Message_FirstHitsSecondWithCriticalDamage(string attackerName, string defenderName, int damage);
    string Message_QuestComplited(Quest quest);
}
