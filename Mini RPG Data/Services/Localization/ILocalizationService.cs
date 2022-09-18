using Mini_RPG_Data.Character_;
using Mini_RPG_Data.Controllers;
using Mini_RPG_Data.Controllers.Character_;
using Mini_RPG_Data.Map_;

namespace Mini_RPG_Data.Services.Localization;

public interface ILocalizationService
{
    event Action? LanguageChanged;

    string Button_NewGame();
    string Button_LoadGame();
    string Button_Exit();
    string Button_StartGame();
    string Label_AbilityPoints();
    string Label_Charisma();
    string Label_Constitution();
    string Label_Dexterity();
    string Label_Perception();
    string Label_Race();
    string Label_Strength();
    string ToolTip_Race();
    string ToolTip_AbilityPoints();
    string ToolTip_Charisma();
    string ToolTip_Strength();
    string ToolTip_Dexterity();
    string ToolTip_Constitution();
    string RaceName(CharacterRace race);
    string ToolTip_Perception();
    string TextBox_Name();
    string HungerLevelName(HungerLevel hungerLevel);
    string ThirstLevelName(ThirstLevel thirstLevel);
    string Label_Intro();
    string Button_GoToGame();
    string Level();
    string Button_Rest();
    string Button_Attack();
    string Button_TryLeaveBattle();
    string Button_Trader();
    string Button_RestInTown();
    string Button_LeaveTown();
    string Menu();
    string SaveAndExit();
    string Button_Log();
    string Button_EnterTown();
    string UnexploredLocation();
    string EmptyExploredLocation();
    string Town();
    string Enemy();
    string Button_Close();
    string LevelBoarder();
    string PlayerMoveSuccessfully(Direction direction);
    string PlayerMoveUnsuccessfully(Direction direction);
    string PlayerRest();
    string Message_YouFindLoot();
    string Message_Coins();
    string Message_YouFindLockedChest();
    string Message_PickLockedChestSuccess();
    string Message_PickLockedChestFail();
    string Message_BreakChestSuccess();
    string Message_BreakChestFail();
    string Message_YouFindHiddenLoot();
    string Message_FindTrapSuccess(TrapType trapType);
    string Message_FindTrapFail(TrapType trapType);
}
