using Mini_RPG_Data.Character_;
using Mini_RPG_Data.Controllers;
using Mini_RPG_Data.Controllers.Character_;
using Mini_RPG_Data.Controllers.Inventory_.Items;
using Mini_RPG_Data.Controllers.Map_;

namespace Mini_RPG_Data.Services.Localization;

public class SimpleLocalizationService : ILocalizationService
{
    public event Action? LanguageChanged;
    public string Button_Exit() => "ВЫХОД";
    public string Button_LoadGame() => "ЗАГРУЗИТЬ";
    public string Button_NewGame() => "НОВАЯ ИГРА";
    public string Button_StartGame() => "НАЧАТЬ";
    public string Bitton_MainMenu() => "В ГЛАВНОЕ МЕНЮ";
    public string Label_AbilityPoints() => "Очки характеристик";
    public string Label_Abilities() => "Характеристики";
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
    public string Message_YouFindLoot() => "На пути вам попадается сверток с вещами. Осмотрев их вы забираете все ценное.\n\nВы нашли";
    public string Message_Coins() => "Монеты";
    public string Message_YouFindLockedChest() => "Вы нашли запертый сундук";
    public string Message_PickLockedChestSuccess() => "Попытка вскыть замок оказалась успешной.\n\nВнутри вы нашли";
    public string Message_PickLockedChestFail() => "Попытка вскыть замок окончилась неудачей.\nМеханизм замка окончательно заклинило, теперь его не открыть даже ключем.";
    public string Message_BreakChestSuccess() => "Рассчитывая все-таки получить ценное содержимое, вы наносите несколько точных ударов и проламываете крышку.\n\nВнутри вы находите";
    public string Message_BreakChestFail() => 
        "Рассчитывая все-таки получить ценное содержимое, вы решаетет взломать сундук силой. Однако вы явно переоценили свои возможности!\n\n" +
        "Спустя продолжительное времени, вы без сил садитесь на землю, чтобы немного отдохнуть и попробовать снова.\n\n" +
        "Вы закрыли глаза буквально на минуту, а когда открыли, сундука уже не было. Вы заметили только размытый силуэт в тенях.\n\n" +
        "Понимая, что вора уже не догнать, вы собираете свои вещи и продолжаете путешествие.";

    public string Message_YouFindHiddenLoot() =>
        "Вы останавливаетесь, чтобы перевести дух и поправить снаряжение. Вдруг ваше внимание привлекают еле заметные следы на земле.\n" +
        "Пройдя по ним несколько десятков шагов, вы натыкаетесь на тайник.\n" +
        "Внимательно осмотрев его содержимое, вы забираете с собой все ценное.\n\nВы нашли";

    public string Message_FindTrapSuccess(TrapType trapType)
    {
        return trapType switch
        {
            TrapType.SpikeTrap => "Ваша внимательность вас не подвела. На земле вы замечаете замаскированную нажимную пластину.\nАккуратно обойдя ее, вы продолжаете свой путь.",
            TrapType.BearTrap => "В нескольких метрах перед собой вы замечаете медвежий капкан.\nАккуратно обойдя его, вы продолжаете свой путь.",
            TrapType.None => throw new NotImplementedException(),
            _ => throw new NotImplementedException(),
        };
    }

    public string Message_FindTrapFail(TrapType trapType)
    {
        return trapType switch
        {
            TrapType.SpikeTrap => "Тихий щелчек, и несколько металлических шипов впиются вам в ногу.",
            TrapType.BearTrap => "Тугая нажимная пластина поддается под вашим весом. Запоздало вы понимаете, что угодили в медвежий капкан.",
            TrapType.None => throw new NotImplementedException(),
            _ => throw new NotImplementedException(),
        };
    }

    public string Label_Equipment() => "Экипировка";
    public string Cost() => "Стоимость";
    public string DamageType() => "Тип урона";
    public string Grip() => "Хват";
    public string Damage() => "Урон";
    public string ArmorType() => "Тип брони";
    public string Armor() => "Броня";
    public string DodgePenalty() => "Штраф уворота";
    public string MinBlockBonus() => "МинБлокБонус";
    public string MaxBlockBonus() => "МаксБлокБонус";
    public string DamageTypeName(DamageType damageType) => damageType switch
    {
        Controllers.Inventory_.Items.DamageType.Slashing => "Рубящий",
        Controllers.Inventory_.Items.DamageType.Piercing => "Колющий",
        Controllers.Inventory_.Items.DamageType.Bludgeoning => "Дробящий",
        Controllers.Inventory_.Items.DamageType.None => throw new NotImplementedException(),
        _ => throw new NotImplementedException(),
    };

    public string GripName(Grip grip)
    {
        return grip switch
        {
            Controllers.Inventory_.Items.Grip.SingleHanded => "Одноручное",
            Controllers.Inventory_.Items.Grip.TwoHanded => "Двуручное",
            Controllers.Inventory_.Items.Grip.None => throw new NotImplementedException(),
            _ => throw new NotImplementedException(),
        };
    }

    public string ArmorTypeName(ArmorType armorType)
    {
        return armorType switch
        {
            Controllers.Inventory_.Items.ArmorType.Light => "Легкая",
            Controllers.Inventory_.Items.ArmorType.Medium => "Средняя",
            Controllers.Inventory_.Items.ArmorType.Heavy => "Тяжелая",
            Controllers.Inventory_.Items.ArmorType.None => throw new NotImplementedException(),
            _ => throw new NotImplementedException(),
        };
    }

    public string ItemName(string name)
    {
        return name switch
        {
            "WolfPelt" => "Волчья шкура",

            "BronzeSword" => "Бронзовый меч",
            "IronSword" => "Железный меч",
            "SteelSword" => "Стальной меч",
            "BronzeTwoHandedAxe" => "Бронзовый двуручный топор",
            "IronTwoHandedAxe" => "Железный двуручный топор",
            "SteelTwoHandedAxe" => "Стальной двуручный топор",

            "ThinLeatherHelmet" => "Шлем из тонкой кожи",
            "ThinLeatherGloves" => "Перчатки из тонкой кожи",
            "ThinLeatherJacket" => "Куртка из тонкой кожи",
            "ThinLeatherBoots" => "Сапоги из тонкой кожи",
            "LeatherHelmet" => "Кожаный Шлем",
            "LeatherGloves" => "Кожаные Перчатки",
            "LeatherJacket" => "Кожаная Куртка",
            "LeatherBoots" => "Кожаные Сапоги",
            "ThickLeatherHelmet" => "Шлем из толстой кожи",
            "ThickLeatherGloves" => "Перчатки из толстой кожи",
            "ThickLeatherJacket" => "Куртка из толстой кожи",
            "ThickLeatherBoots" => "Сапоги из толстой кожи",

            "BronzeChainHelmet" => "Бронзовый кольчужный Шлем",
            "BronzeChainGloves" => "Бронзовые кольчужные Перчатки",
            "BronzeChainArmor" => "Бронзовая Кольчуга",
            "BronzeChainLegs" => "Бронзовые кольчужные Поножи",
            "IronChainHelmet" => "Железный кольчужный Шлем",
            "IronChainGloves" => "Железные кольчужные Перчатки",
            "IronChainArmor" => "Железная Кольчуга",
            "IronChainLegs" => "Железные кольчужные Поножи",
            "SteelChainHelmet" => "Стальной кольчужный Шлем",
            "SteelChainGloves" => "Стальные кольчужные Перчатки",
            "SteelChainArmor" => "Стальная Кольчуга",
            "SteelChainLegs" => "Стальные кольчужные Поножи",

            "SmallHealthPotion" => "Малое Зелье здоровья",
            "HealthPotion" => "Зелье здоровья",
            "BigHealthPotion" => "Большое Зелье здоровья",

            "Bread" => "Хлеб",
            "WaterFlask" => "Фляга с водой",

            "SmallShield" => "Малый Щит",
            "MediumShield" => "Средний Щит",
            "BigShield" => "Большой Щит",

            _ => "Не переведено",
        };
    }
}
