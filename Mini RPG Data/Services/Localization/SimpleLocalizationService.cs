﻿using Mini_RPG_Data.Character_;
using Mini_RPG_Data.Controllers;
using Mini_RPG_Data.Controllers.Character_;

namespace Mini_RPG_Data.Services.Localization;

public class SimpleLocalizationService : ILocalizationService
{
    public event Action? LanguageChanged;
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
    public string Button_GoToGame() => "НАЧАТЬ";
    public string Label_Intro() => "\"Провинциальный затерянный в лесах городок \"Чистоводье\", окружен лесами. Городок находится на старой торговой дороге возле реки, тихий и мирный.\n" +
        "После строительства новой дороги потерял свою былую привлекательность и постепенно пустеет. Редкие путешественники и торговцы теперь большое собые.\n" +
        "Местные жители - охотники, рыбаки да крестьяне. Из построек - торговая лавка со всем необходимым, постоялый двор, ратуша да частные хозяйства\"\n\n" +
        "В который раз вы закончили перечитывать выписку, полученную от гарнизонного писаря.\n" +
        "И в это Богами забытое место вас отравил командир гарнизона: \"Расследовать причину беспокайства местных жителей\".\n" +
        "А ведь всего ничего, пару охотников не вернулись из леса, да грибника волки порвали.\n" +
        "Крестьяне всегда были склонны к суевериям и излишнему драматизму, что с них взять.";

    public string Level() => "Уровень";
    public string Button_Rest() => "Отдыхать";
    public string Button_Attack() => "Атаковать";
    public string Button_TryLeaveBattle() => "Попытаться сбежать";
    public string Button_Trader() => "Торговец";
    public string Button_RestInTown() => "Отдыхать в городе";
    public string Button_LeaveTown() => "Покинуть город";
    public string Menu() => "Меню";
    public string SaveAndExit() => "Сохранить и выйти";
    public string Button_Log() => "Лог";
    public string Button_EnterTown() => "Войти в город";
    public string UnexploredLocation() => "Неисследованная локация";
    public string EmptyExploredLocation() => "Пустая исследованная локация";
    public string Town() => "Город";
    public string Enemy() => "Противник";
    public string RaceName(CharacterRace race)
    {
        return race switch
        {
            CharacterRace.Dwarf => "Дварф",
            CharacterRace.Elf   => "Эльф",
            CharacterRace.Human => "Человек",
            CharacterRace.None => throw new NotImplementedException(),
            _ => throw new NotImplementedException(),
        };
    }
    public string Button_Close() => "Закрыть";
    public string LevelBoarder() => "Граница уровня";
    public string HungerLevelName(HungerLevel hungerLevel)
    {
        return hungerLevel switch
        {
            HungerLevel.Hungry => "Голод",
            HungerLevel.Neutral => "Норма",
            HungerLevel.Satiated => "Сыт",
            HungerLevel.None => throw new NotImplementedException(),
            _ => throw new NotImplementedException(),
        };
    }

    public string ThirstLevelName(ThirstLevel thirstLevel)
    {
        return thirstLevel switch
        {
            ThirstLevel.Thirsty => "Жажда",
            ThirstLevel.Neutral => "Норма",
            ThirstLevel.Satiated => "Сыт",
            ThirstLevel.None => throw new NotImplementedException(),
            _ => throw new NotImplementedException(),
        };
    }

    public string PlayerMoveSuccessfully(Direction direction)
    {
        return direction switch
        {
            Direction.N => "Вы пошли на Север",
            Direction.S => "Вы пошли на Юг",
            Direction.W => "Вы пошли на Запад",
            Direction.E => "Вы пошли на Восток",
            Direction.None => throw new NotImplementedException(),
            _ => throw new NotImplementedException(),
        };
    }

    public string PlayerMoveUnsuccessfully(Direction direction)
    {
        return direction switch
        {
            Direction.N => "Вы не можете пойти на Север",
            Direction.S => "Вы не можете пойти на Юг",
            Direction.W => "Вы не можете пойти на Запад",
            Direction.E => "Вы не можете пойти на Восток",
            Direction.None => throw new NotImplementedException(),
            _ => throw new NotImplementedException(),
        };
    }

    public string PlayerRest() => "Вы остановились на привал";
    public string Message_YouFindLoot() => "На пути вам попадается сверток с вещами. Осмотрев их вы забираетет все ценное.\n\nВы нашли";
    public string Message_Coins() => "Монеты";
}
