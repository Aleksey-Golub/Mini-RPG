﻿namespace Mini_RPG_Data.Services.Localization;

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
    string ToolTip_Perception();
    string TextBox_Name();
    string Human();
    string Elf();
    string Dwarf();
}