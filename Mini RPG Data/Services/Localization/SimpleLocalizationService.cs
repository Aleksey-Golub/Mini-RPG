namespace Mini_RPG_Data.Services.Localization;

public class SimpleLocalizationService : ILocalizationService
{
    public event Action? LanguageChanged;

    public string Dwarf() => "Дварф";
    public string Elf() => "Эльф";
    public string Human() => "Человек";
    public string Button_Exit() => "ВЫХОД";
    public string Button_LoadGame() => "ЗАГРУЗИТЬ";
    public string Button_NewGame() => "НОВАЯ ИГРА";
    public string Button_StartGame() => "НАЧАТЬ";
    public string Label_AbilityPoints() => "Очки характеристик";
    public string Label_Charisma() => "Харизма";
    public string Label_Constitution() => "Выносливость";
    public string Label_Dexterity() => "Ловкость";
    public string Label_Perception() => "Восприятие";
    public string Label_Race() => "Раса";
    public string Label_Strength() => "Сила";
    public string TextBox_Name() => "% Введите имя %";
    public string ToolTip_AbilityPoints() => "Доступные для распределения очки характеристик";
    public string ToolTip_Charisma() => "Описание ХАР и за что она отвечает";
    public string ToolTip_Constitution() => "Описание ВЫН и за что она отвечает";
    public string ToolTip_Dexterity() => "Описание ЛОВ и за что она отвечает";
    public string ToolTip_Perception() => "Описание ВОС и за что она отвечает";
    public string ToolTip_Race() => "Описание всех рас и их бонусов";
    public string ToolTip_Strength() => "Описание СИЛ и за что она отвечает";
}
