using Mini_RPG_Data.Character_;
using Mini_RPG_Data.Controllers;
using Mini_RPG_Data.Controllers.Character_;
using Mini_RPG_Data.Controllers.Inventory_.Items;
using Mini_RPG_Data.Controllers.Map_;
using Mini_RPG_Data.Controllers.Quest_;

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
    public string ToolTip_Strength() => 
        "Сили (СИЛ) - бонус СИЛ применяется к броскам на попадание в цель в ближнем бою,\n" +
        "броскам на урон в ближнем бою, бонус блока, проверки на разбивание предмета.";
    public string ToolTip_Dexterity() =>
        "Ловкость (ЛОВ) - Бонус ЛОВ применяется к броскам на попадание в цель из дальнобойного оружия,\n" +
        "броскам на урон из дальнобойного оружия, броскам на урон и попадание в ближнем бою одноручным\n" +
        "оружием при свободной второй руке, бонусу уклонения, бонусу парирования,\n" +
        "проверкам на обезвреживание ловушек и взлом замков.";
    public string ToolTip_Constitution() => 
        "Выносливость (ВЫН) - бонус ВЫН применяется к броскам на проверку регенерации здоровья,\n" +
        "рассчета очков здоровья.";
    public string ToolTip_Perception() => 
        "Восприятие (ВОС) - бонус ВОС применяется к броскам на проверки поиска скрытых предметов (тайники, ловушки и т.д.),\n" +
        "определение инициативы в начале боя, дальности обзора, шанс сбежать из битвы";
    public string ToolTip_Charisma() => 
        "Харизма (ХАР) - бонус ХАР применяется к броскам на проверки убеждения и цены у торговцев.";
    public string ToolTip_Race() => "Описание всех рас и их бонусов";
    public string Button_GoToGame() => "НАЧАТЬ";
    public string Label_Intro() => "\"Затерянный в лесах провинциальный городок \"Чистоводье\", находится на старой торговой дороге возле реки, тихий и мирный. " +
        "После строительства новой дороги потерял свою былую привлекательность и постепенно пустеет. Редкие путешественники и торговцы теперь большое собые здесь. " +
        "Местные жители - охотники, рыбаки и крестьяне. Из построек - торговая лавка со всем необходимым, постоялый двор, ратуша, а так же частные хозяйства\"\n\n" +
        "В очередной раз вы закончили перечитывать выписку, полученную от гарнизонного писаря.\n" +
        "И в это Богами забытое место вас отравил командир гарнизона: \"Расследовать причину беспокайства местных жителей\".\n" +
        "А ведь всего ничего, пару охотников пропали в лесу, да грибника задрали волки. Ситуация вполне обычная для такого захолустья. Крестьяне всегда были склонны к излишнему драматизму, что с них взять?";

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
    public string RaceName(Race race)
    {
        return race switch
        {
            Race.Dwarf => "Дварф",
            Race.Elf => "Эльф",
            Race.Human => "Человек",
            Race.Goblin => "Гоблин",
            Race.Orc => "Орк",
            Race.Beast => "Животное",
            Race.None => throw new NotImplementedException(),
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
    public string Message_YouFindLoot() => "На пути вам попадается сверток с вещами. Осмотрев их вы забираете все ценное.\n\n";
    public string Message_Coins() => "Монеты";
    public string Message_YouFindLockedChest() => "Вы нашли запертый сундук";
    public string Message_PickLockedChestSuccess() => "Попытка вскыть замок оказалась успешной.\n\n";
    public string Message_PickLockedChestFail() => "Попытка вскыть замок окончилась неудачей.\nМеханизм замка окончательно заклинило, теперь его не открыть даже ключем.";
    public string Message_BreakChestSuccess() => "Рассчитывая все-таки получить ценное содержимое, вы наносите несколько точных ударов и проламываете крышку.\n\n";
    public string Message_BreakChestFail() =>
        "Рассчитывая все-таки получить ценное содержимое, вы решаетет взломать сундук силой. Однако вы явно переоценили свои возможности!\n\n" +
        "Спустя продолжительное времени, вы без сил садитесь на землю, чтобы немного отдохнуть и попробовать снова.\n\n" +
        "Вы закрыли глаза буквально на минуту, а когда открыли, сундука уже не было. Вы заметили только размытый силуэт в тенях.\n\n" +
        "Понимая, что вора уже не догнать, вы собираете свои вещи и продолжаете путешествие.";

    public string Message_YouFindHiddenLoot() =>
        "Вы останавливаетесь, чтобы перевести дух и поправить снаряжение. Вдруг ваше внимание привлекают еле заметные следы на земле.\n" +
        "Пройдя по ним несколько десятков шагов, вы натыкаетесь на тайник.\n" +
        "Внимательно осмотрев его содержимое, вы забираете с собой все ценное.\n\n";

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

    public string Message_StartRestInTown(int restCost)
    {
        return String.Format("Вы находите хозяина постоялого двора.\n Он готов сдать вам комнату за {0} монет", restCost);
    }

    public string Message_StartRestInTownFree()
    {
        return "Вы находите хозяина постоялого двора.\n" +
            "Учитывая вашу помощь местным жителям, в этот раз он готов пустить вас бесплатно";
    }

    public string Message_YouRestInTown()
    {
        return "Вы снимаете комнату на несколько дней.\n" +
            "За это время выши раны успеют затянуться, а торговец успеет обновить свои товары.";
    }

    public string Message_YouHaveNoMoneyToRestInTown() => "Вы уходите, понимая что у вас недостаточно денег";
    public string Message_BattleStart() => "Впереди противник. К бою!";

    public string Bonus() => "Бонус";
    public string Label_Equipment() => "Экипировка";
    public string Cost() => "Стоимость";
    public string Experience() => "Опыт";
    public string SellCost() => "Стоимость продажи";
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

    public string TrapTypeName(TrapType trapType)
    {
        return trapType switch
        {
            TrapType.SpikeTrap => "Ловушка с шипами",
            TrapType.BearTrap => "Медвежий капкан",
            TrapType.None => throw new NotImplementedException(),
            _ => throw new NotImplementedException(),
        };
    }

    public string ItemName(string name)
    {
        return name switch
        {
            "ThinWolfPelt" => "Тонкая Волчья шкура",
            "WolfPelt" => "Волчья шкура",
            "ThickWolfPelt" => "Толстая Волчья шкура",
            "ThinBoarPelt" => "Тонкая Шкура кабана",
            "BoarPelt" => "Шкура кабана",
            "ThickBoarPelt" => "Толстая Шкура кабана",
            "IronOre" => "Железная руда",
            "LeatherScrap" => "Обрезки кожи",

            "BronzeSword" => "Бронзовый меч",
            "IronSword" => "Железный меч",
            "SteelSword" => "Стальной меч",
            "BronzeTwoHandedAxe" => "Бронзовый двуручный топор",
            "IronTwoHandedAxe" => "Железный двуручный топор",
            "SteelTwoHandedAxe" => "Стальной двуручный топор",
            "BronzeHummer" => "Бронзовый молот",
            "IronHummer" => "Железный молот",
            "SteelHummer" => "Стальной молот",
            "ShortBow" => "Короткий лук",
            "LongBow" => "Длинный лук",
            "CompositeBow" => "Композитный лук",
            "BronzeAxe" => "Бронзовый топор",
            "IronAxe" => "Железный топор",
            "SteelAxe" => "Стальной топор",
            "BronzeMace" => "Бронзовая булава",
            "IronMace" => "Железная булава",
            "SteelMace" => "Стальная булава",
            "BronzeSpear" => "Бронзовое копье",
            "IronSpear" => "Железное копье",
            "SteelSpear" => "Стальное копье",
            "BronzeDagger" => "Бронзовый кинжал",
            "IronDagger" => "Железный кинжал",
            "SteelDagger" => "Стальной кинжал",

            "ThinLeatherHelmet" => "Шлем из тонкой кожи",
            "ThinLeatherGloves" => "Перчатки из тонкой кожи",
            "ThinLeatherArmor" => "Куртка из тонкой кожи",
            "ThinLeatherLegs" => "Поножи из тонкой кожи",
            "LeatherHelmet" => "Кожаный Шлем",
            "LeatherGloves" => "Кожаные Перчатки",
            "LeatherArmor" => "Кожаная Куртка",
            "LeatherLegs" => "Кожаные Поножи",
            "ThickLeatherHelmet" => "Шлем из толстой кожи",
            "ThickLeatherGloves" => "Перчатки из толстой кожи",
            "ThickLeatherArmor" => "Куртка из толстой кожи",
            "ThickLeatherLegs" => "Поножи из толстой кожи",

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

            "BronzePlateHelmet" => "Бронзовый латный Шлем",
            "BronzePlateGloves" => "Бронзовые латные Перчатки",
            "BronzePlateArmor" => "Бронзовая латная Броня",
            "BronzePlateLegs" => "Бронзовые латные Поножи",
            "IronPlateHelmet" => "Железный латный Шлем",
            "IronPlateGloves" => "Железные латные Перчатки",
            "IronPlateArmor" => "Железная латная Броня",
            "IronPlateLegs" => "Железные латные Поножи",
            "SteelPlateHelmet" => "Стальной латный Шлем",
            "SteelPlateGloves" => "Стальные латные Перчатки",
            "SteelPlateArmor" => "Стальная латная Броня",
            "SteelPlateLegs" => "Стальные латные Поножи",

            "SmallHealthPotion" => "Малое Зелье здоровья",
            "HealthPotion" => "Зелье здоровья",
            "BigHealthPotion" => "Большое Зелье здоровья",

            "Bread" => "Хлеб",
            "WaterFlask" => "Фляга с водой",
            "DeathCap" => "Бледная поганка",
            "RedCapBolete" => "Обабок",
            "Boletus" => "Белый гриб",
            "Blueberry" => "Голубика",
            "Blackberry" => "Ежевика",
            "RedCurrant" => "Красная смородина",
            "BlackCurrant" => "Черная смородина",
            "Cheese" => "Сыр",
            "BigWaterFlask" => "Большая фляга с водой",

            "SmallShield" => "Малый Щит",
            "MediumShield" => "Средний Щит",
            "BigShield" => "Большой Щит",

            _ => name,
        };
    }

    public string CharacterName(string name)
    {
        return name switch
        {
            "YoungGoblinArcher" => "Молодой Гоблин-лучник",
            "GoblinArcher" => "Гоблин-лучник",
            "OldGoblinArcher" => "Матерый Гоблин-лучник",
            "YoungGoblinWarrior" => "Молодой Гоблин-воин",
            "GoblinWarrior" => "Гоблин-воин",
            "OldGoblinWarrior" => "Матерый Гоблин-воин",
            "YoungOrcArcher" => "Молодой Орк-лучник",
            "OrcArcher" => "Орк-лучник",
            "OldOrcArcher" => "Матерый Орк-лучник",
            "YoungOrcWarrior" => "Молодой Орк-воин",
            "OrcWarrior" => "Орк-воин",
            "OldOrcWarrior" => "Матерый Орк-воин",
            "YoungOrcWarlord" => "Молодой Орк-капитан",
            "OrcWarlord" => "Орк-капитан",
            "OldOrcWarlord" => "Матерый Орк-капитан",

            "YoungBoar" => "Молодой Кабан",
            "Boar" => "Кабан",
            "OldBoar" => "Матерый Кабан",
            "YoungRat" => "Молодая Крыса",
            "Rat" => "Крыса",
            "OldRat" => "Матерая Крыса",
            "YoungWolf" => "Молодой Волк",
            "Wolf" => "Волк",
            "OldWolf" => "Матерый Волк",
            "YoungBat" => "Молодая Летучая мышь",
            "Bat" => "Летучая мышь",
            "OldBat" => "Матерая Летучая мышь",

            _ => name,
        };
    }

    public string PlayerUse() => "Вы использовали";
    public string Shop() => "Магазин";
    public string Message_YouAreEscaped() => "Вам удалось сбежать";
    public string Message_YouAreNotEscaped() => "Вам не удалось сбежать";
    public string Message_FirstHitsSecondWithDamage(string attackerName, string defenderName, int damage) => String.Format("{0} нанес {1} {2} урона", attackerName, defenderName, damage);
    public string Message_FirstHitsSecondWithCriticalDamage(string attackerName, string defenderName, int damage) => String.Format("Крит! {0} нанес {1} {2} урона", attackerName, defenderName, damage);
    public string Message_FirstMissedSecond(string attackerName, string defenderName) => String.Format("{0} не попадает по {1}", attackerName, defenderName);
    public string Message_MapExplored() => "Вы закончили исследовать эту местность. Можно вернуться в город и отдохнуть";
    public string YouGained() => "Вы получили:";
    public string CharacterGainedNewLevel(string name) => $"{name} получил новый уровень!";

    public string Quest(string localizationKey)
    {
        return localizationKey switch
        {
            "Quest_0_Name" => "Главный квест",
            "Quest_0_Description" => "Найдите и устраните причину беспокойства местных жителей",
            "Quest_0_0_Description" => "Старт квеста",
            "Quest_0_0_0_GoalDescription" => "Получите квест",
            "Quest_0_0_PhaseComplitedMessage" => "Квест получен",
            "Quest_0_1_Description" => "Исследуйте окрестности",
            "Quest_0_1_0_GoalDescription" => "Найдите первые зацепки",
            "Quest_0_1_PhaseComplitedMessage" => "Гоблины! " +
                "Вот и причина беспокойства местных жителей. Однако гоблины довольно неорганизованы и трусливы, чтобы оказаться так долеко от привычных мест обитания." +
                "Необходимо продолжить обследование окрестностей, чтобы найти, кто за ними стоит",
            "Quest_0_10_Description" => "Продолжайте исследовать окрестности",
            "Quest_0_10_0_GoalDescription" => "Найдите, кто стоит за гоблинами",
            "Quest_0_10_PhaseComplitedMessage" => "Гоблины и орки действуют сообща?" +
                "Зеленокожие дикари всегда были заняты войнами друг с другом и редко появлялись за пределами своих территорий." +
                "Необходимо продолжить расследование",
            "Quest_0_20_Description" => "Продолжайте исследовать местность в происках новых зацепок",
            "Quest_0_20_0_GoalDescription" => "Получите 8 уровень",
            "Quest_0_20_PhaseComplitedMessage" => "В вещах последнего убитого зеленокожего вы нашли записку.\n" +
                "Хоть вы и не знакоми с орочьей грамотой, но записка явно написана кем-то важным, а внешний вид говорит о том, что написана она была совсем недавно.",
            "Quest_0_30_Description" => "Найдите и убейте командира зеленокожих",
            "Quest_0_30_0_GoalDescription" => "Убейте Матерого Орка-капитана",
            "Quest_0_30_PhaseComplitedMessage" => "Тяжело дыша вы убираете оружие и осматриваете поле боя." +
                "Без жесткого управления командиром зеленокожие утратят свою прыть и прибывшим сюда после вас отрядам из ближайшего форта без труда удастся с ними раборбаться." +
                "Из ближайших кустов вываливаются два стражника, которых вы видели на городской площади." +
                "\"Из столицы прибыл гонец с ужасными новостями! Зеленокожие объединились, их орда движется сметая все на своем пути!" +
                "Власти начали эвакуацию населения, а всех способных держать оружие призывают в Столицу.\"",
            "Quest_0_100_Description" => "Конец квеста",
            "Quest_0_100_0_GoalDescription" => "Завершите квест",
            "Quest_0_100_PhaseComplitedMessage" => "Квест завершен",

            _ => localizationKey,
        };
    }

    public string Message_QuestComplited(Quest quest) => String.Format("Квест \"{0}\" завершен", quest.LocalizedName);
}
