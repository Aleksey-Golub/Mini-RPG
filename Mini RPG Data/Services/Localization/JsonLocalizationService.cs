using Mini_RPG_Data.Character_;
using Mini_RPG_Data.Controllers;
using Mini_RPG_Data.Controllers.Character_;
using Mini_RPG_Data.Controllers.Inventory_.Items;
using Mini_RPG_Data.Controllers.Map_;
using Mini_RPG_Data.Controllers.Quest_;
using System.Text.Json;

namespace Mini_RPG_Data.Services.Localization;

public class JsonLocalizationService : ILocalizationService
{
    private const string DIRECTORY = "Localization\\";
    private const string LANGUAGE = "ru\\";
    private const string COMMON_PATH = "common.json";
    private const string Items_PATH = "items.txt";
    private const string CHARACTERS_PATH = "characters.txt";
    private const string QUESTS_PATH = "quests.txt";

    private readonly JsonSerializerOptions _options;
    private readonly LocalizationContainer? _commonContainer;
    private readonly Dictionary<string, string> _itemNames = new Dictionary<string, string>();
    private readonly Dictionary<string, string> _characterNames = new Dictionary<string, string>();
    private readonly Dictionary<string, string> _quests = new Dictionary<string, string>();

    public JsonLocalizationService()
    {
        _options = new JsonSerializerOptions { IncludeFields = true };
        
        _commonContainer = new LocalizationContainer();

        try
        {
            //string jsonString = JsonSerializer.Serialize(_commonContainer, _options);
            //File.WriteAllText(DIRECTORY + "ruExample.json", jsonString);

            string commonText = File.ReadAllText(DIRECTORY + LANGUAGE + COMMON_PATH);
            _commonContainer = JsonSerializer.Deserialize<LocalizationContainer>(commonText, _options) ?? new LocalizationContainer();
            string itemsPath = DIRECTORY + LANGUAGE + Items_PATH;
            FillDictionaryFromFile(itemsPath, _itemNames);
            string charactersPath = DIRECTORY + LANGUAGE + CHARACTERS_PATH;
            FillDictionaryFromFile(charactersPath, _characterNames);
            string questsPath = DIRECTORY + LANGUAGE + QUESTS_PATH;
            FillDictionaryFromFile(questsPath, _quests);
        }
        catch { }
    }

    private void FillDictionaryFromFile(string filePath, Dictionary<string, string> dictionary)
    {
        string[] strs = File.Exists(filePath) ? File.ReadAllLines(filePath) : new string[] {"000"};

        foreach (var str in strs)
        {
            // string like "key = value"
            int index = str.IndexOf("=");
            if (index != -1)
            {
                string key = str.Substring(0, index - 1);
                string value = str.Substring(index + 2);
                value = value.Replace("@", Environment.NewLine);
                dictionary[key] = value;
            }
        }
    }

    public event Action? LanguageChanged;

    public string Button_Exit() => _commonContainer.Button_Exit;//"ВЫХОД";
    public string Button_LoadGame() => _commonContainer.Button_LoadGame;//"ЗАГРУЗИТЬ";
    public string Button_NewGame() => _commonContainer.Button_NewGame;//"НОВАЯ ИГРА";
    public string Button_StartGame() => _commonContainer.Button_StartGame;//"НАЧАТЬ";
    public string Button_MainMenu() => _commonContainer.Button_MainMenu;//"В ГЛАВНОЕ МЕНЮ";
    public string Button_GoToGame() => _commonContainer.Button_GoToGame;//"НАЧАТЬ";
    public string Button_Rest() => _commonContainer.Button_Rest;//"Отдыхать";
    public string Button_Attack() => _commonContainer.Button_Attack;//"Атаковать";
    public string Button_TryLeaveBattle() => _commonContainer.Button_TryLeaveBattle;//"Попытаться сбежать";
    public string Button_Trader() => _commonContainer.Button_Trader;//"Торговец";
    public string Button_RestInTown() => _commonContainer.Button_RestInTown;//"Отдыхать в городе";
    public string Button_LeaveTown() => _commonContainer.Button_LeaveTown;//"Покинуть город";
    public string Button_Log() => _commonContainer.Button_Log;//"Лог";
    public string Button_EnterTown() => _commonContainer.Button_EnterTown;//"Войти в город";
    public string Button_Close() => _commonContainer.Button_Close;//"Закрыть";

    public string Label_AbilityPoints() => _commonContainer.Label_AbilityPoints;//"Очки характеристик";
    public string Label_Abilities() => _commonContainer.Label_Abilities;//"Характеристики";
    public string Label_Charisma() => _commonContainer.Label_Charisma;//"Харизма";
    public string Label_Constitution() => _commonContainer.Label_Constitution;//"Выносливость";
    public string Label_Dexterity() => _commonContainer.Label_Dexterity;//"Ловкость";
    public string Label_Perception() => _commonContainer.Label_Perception;//"Восприятие";
    public string Label_Race() => _commonContainer.Label_Race;//"Раса";
    public string Label_Strength() => _commonContainer.Label_Strength;//"Сила";
    public string Label_Intro() => _commonContainer.Label_Intro;
    //"\"Затерянный в лесах провинциальный городок \"Чистоводье\", находится на старой торговой дороге возле реки, тихий и мирный. " +
    //"После строительства новой дороги потерял свою былую привлекательность и постепенно пустеет. Редкие путешественники и торговцы теперь большое собые здесь. " +
    //"Местные жители - охотники, рыбаки и крестьяне. Из построек - торговая лавка со всем необходимым, постоялый двор, ратуша, а так же частные хозяйства\"\n\n" +
    //"В очередной раз вы закончили перечитывать выписку, полученную от гарнизонного писаря.\n" +
    //"И в это Богами забытое место вас отравил командир гарнизона: \"Расследовать причину беспокайства местных жителей\".\n" +
    //"А ведь всего ничего, пару охотников пропали в лесу, да грибника задрали волки. Ситуация вполне обычная для такого захолустья. Крестьяне всегда были склонны к излишнему драматизму, что с них взять?";

    public string ToolTip_AbilityPoints() => _commonContainer.ToolTip_AbilityPoints; //"Доступные для распределения очки характеристик";
    public string ToolTip_Strength() =>_commonContainer.ToolTip_Strength; //
        //"Сили (СИЛ) - бонус СИЛ применяется к броскам на попадание в цель в ближнем бою,\n" +
        //"броскам на урон в ближнем бою, бонус блока, проверки на разбивание предмета.";
    public string ToolTip_Dexterity() =>_commonContainer.ToolTip_Dexterity; //
        //"Ловкость (ЛОВ) - Бонус ЛОВ применяется к броскам на попадание в цель из дальнобойного оружия,\n" +
        //"броскам на урон из дальнобойного оружия, броскам на урон и попадание в ближнем бою одноручным\n" +
        //"оружием при свободной второй руке, бонусу уворота, проверкам на обезвреживание ловушек и взлом замков.";
    public string ToolTip_Constitution() =>_commonContainer.ToolTip_Constitution; //
        //"Выносливость (ВЫН) - бонус ВЫН применяется к броскам на проверку регенерации здоровья,\n" +
        //"рассчета очков здоровья.";
    public string ToolTip_Perception() =>_commonContainer.ToolTip_Perception; //
        //"Восприятие (ВОС) - бонус ВОС применяется к броскам на проверки поиска скрытых предметов (тайники, ловушки и т.д.),\n" +
        //"определение инициативы в начале боя, дальности обзора, шанс сбежать из битвы";
    public string ToolTip_Charisma() =>_commonContainer.ToolTip_Charisma; //
        //"Харизма (ХАР) - бонус ХАР применяется к броскам на проверки убеждения и цены у торговцев.";
    public string ToolTip_Race() => _commonContainer.ToolTip_Race;
    //"Описание всех рас и их бонусов";
    //"Люди - уверенные и харизматичные, составляют большинство населения королевства."
    //"Эльфы - утонченные и грациозные долгожители, не так многочисленны как другие народы."
    //"Дварфы - коренастые выносливые бородачи, любящие золото, выпивку и жар кузни."
    //"Злые языки поговаривают, что женщин-дварфов не существует или они насят бороды как и мужчины и топому не отличимы от них."

    public string Message_YouFindLoot() => _commonContainer.Message_YouFindLoot;//"На пути вам попадается сверток с вещами. Осмотрев их вы забираете все ценное.\n\n";
    public string Message_Coins() => _commonContainer.Message_Coins;//"Монеты";
    public string Message_YouFindLockedChest() => _commonContainer.Message_YouFindLockedChest;//"Вы нашли запертый сундук";
    public string Message_PickLockedChestSuccess() => _commonContainer.Message_PickLockedChestSuccess;//"Попытка вскыть замок оказалась успешной.\n\n";
    public string Message_PickLockedChestFail() => _commonContainer.Message_PickLockedChestFail;//"Попытка вскыть замок окончилась неудачей.\nМеханизм замка окончательно заклинило, теперь его не открыть даже ключем.";
    public string Message_BreakChestSuccess() => _commonContainer.Message_BreakChestSuccess;//"Рассчитывая все-таки получить ценное содержимое, вы наносите несколько точных ударов и проламываете крышку.\n\n";
    public string Message_BreakChestFail() => _commonContainer.Message_BreakChestFail;
    //"Рассчитывая все-таки получить ценное содержимое, вы решаетет взломать сундук силой. Однако вы явно переоценили свои возможности!\n\n" +
    //"Спустя продолжительное времени, вы без сил садитесь на землю, чтобы немного отдохнуть и попробовать снова.\n\n" +
    //"Вы закрыли глаза буквально на минуту, а когда открыли, сундука уже не было. Вы заметили только размытый силуэт в тенях.\n\n" +
    //"Понимая, что вора уже не догнать, вы собираете свои вещи и продолжаете путешествие.";

    public string Message_YouFindHiddenLoot() => _commonContainer.Message_YouFindHiddenLoot;
        //"Вы останавливаетесь, чтобы перевести дух и поправить снаряжение. Вдруг ваше внимание привлекают еле заметные следы на земле.\n" +
        //"Пройдя по ним несколько десятков шагов, вы натыкаетесь на тайник.\n" +
        //"Внимательно осмотрев его содержимое, вы забираете с собой все ценное.\n\n";

    public string Message_FindTrapSuccess(TrapType trapType)
    {
        return trapType switch
        {
            TrapType.SpikeTrap => _commonContainer.Message_FindSpikeTrapSuccess,//"Ваша внимательность вас не подвела. На земле вы замечаете замаскированную нажимную пластину.\nАккуратно обойдя ее, вы продолжаете свой путь.",
            TrapType.BearTrap => _commonContainer.Message_FindBearTrapSuccess,//"В нескольких метрах перед собой вы замечаете медвежий капкан.\nАккуратно обойдя его, вы продолжаете свой путь.",
            TrapType.None => throw new NotImplementedException(),
            _ => throw new NotImplementedException(),
        };
    }

    public string Message_FindTrapFail(TrapType trapType)
    {
        return trapType switch
        {
            TrapType.SpikeTrap => _commonContainer.Message_FindSpikeTrapFail,//"Тихий щелчек, и несколько металлических шипов впиются вам в ногу.",
            TrapType.BearTrap => _commonContainer.Message_FindBearTrapFail,//"Тугая нажимная пластина поддается под вашим весом. Запоздало вы понимаете, что угодили в медвежий капкан.",
            TrapType.None => throw new NotImplementedException(),
            _ => throw new NotImplementedException(),
        };
    }

    public string Message_StartRestInTownFree() => _commonContainer.Message_StartRestInTownFree;
    //"Вы находите хозяина постоялого двора.\n" +
    //"Учитывая вашу помощь местным жителям, в этот раз он готов пустить вас бесплатно";

    public string Message_YouRestInTown() => _commonContainer.Message_YouRestInTown;
    //"Вы снимаете комнату на несколько дней.\n" +
    //"За это время выши раны успеют затянуться, а торговец успеет обновить свои товары.";

    public string Message_YouHaveNoMoneyToRestInTown() => _commonContainer.Message_YouHaveNoMoneyToRestInTown;//"Вы уходите, понимая что у вас недостаточно денег";
    public string Message_BattleStart() => _commonContainer.Message_BattleStart;//"Впереди противник. К бою!";
    public string Message_YouAreEscaped() => _commonContainer.Message_YouAreEscaped;//"Вам удалось сбежать";
    public string Message_YouAreNotEscaped() => _commonContainer.Message_YouAreNotEscaped;//"Вам не удалось сбежать";
    public string Message_MapExplored() => _commonContainer.Message_MapExplored;//"Вы закончили исследовать эту местность. Можно вернуться в город и отдохнуть";
    public string Message_StartRestInTown(int restCost) => String.Format(_commonContainer.Message_StartRestInTown, restCost);
    //"Вы находите хозяина постоялого двора.\n Он готов сдать вам комнату за {0} монет"
    public string Message_FirstHitsSecondWithDamage(string attackerName, string defenderName, int damage) => String.Format(_commonContainer.Message_FirstHitsSecondWithDamage, attackerName, defenderName, damage);
    //"{0} наносит {1} {2} урона"
    public string Message_FirstHitsSecondWithCriticalDamage(string attackerName, string defenderName, int damage) => String.Format(_commonContainer.Message_FirstHitsSecondWithCriticalDamage, attackerName, defenderName, damage);
    //"Крит! {0} наносит {1} {2} урона"
    public string Message_FirstMissedSecond(string attackerName, string defenderName) => String.Format(_commonContainer.Message_FirstMissedSecond, attackerName, defenderName);
    //"{0} не попадает по {1}"
    public string Message_QuestComplited(Quest quest) => String.Format(_commonContainer.Message_QuestComplited, quest.LocalizedName);
    //"Квест \"{0}\" завершен"

    public string CharacterGainNewLevel(string name) => String.Format(_commonContainer.CharacterGainNewLevel, name);//"{0} получает новый уровень!"
    public string YouUse() => _commonContainer.YouUse;//"Вы использовали";
    public string Shop() => _commonContainer.Shop;//"Магазин";
    public string YouGained() => _commonContainer.YouGained;//"Вы получили:";
    public string DefaultCharacterName() => _commonContainer.DefaultCharacterName;//"% Введите имя %";
    public string Level() => _commonContainer.Level;//"Уровень";
    public string Menu() => _commonContainer.Menu;//"Меню";
    public string SaveAndExit() => _commonContainer.SaveAndExit;//"Сохранить и выйти";
    public string UnexploredLocation() => _commonContainer.UnexploredLocation;//"Неисследованная локация";
    public string EmptyExploredLocation() => _commonContainer.EmptyExploredLocation;//"Пустая исследованная локация";
    public string Town() => _commonContainer.Town;//"Город";
    public string Enemy() => _commonContainer.Enemy;//"Противник";
    public string LevelBoarder() => _commonContainer.LevelBoarder;//"Граница уровня";
    public string PlayerRest() => _commonContainer.PlayerRest;//"Вы остановились на привал";
    public string Bonus() => _commonContainer.Bonus;//"Бонус";
    public string Equipment() => _commonContainer.Equipment;//"Экипировка";
    public string Cost() => _commonContainer.Cost;//"Стоимость";
    public string Experience() => _commonContainer.Experience;//"Опыт";
    public string SellCost() => _commonContainer.SellCost;//"Стоимость продажи";
    public string DamageType() => _commonContainer.DamageType;//"Тип урона";
    public string Grip() => _commonContainer.Grip;//"Хват";
    public string Damage() => _commonContainer.Damage;//"Урон";
    public string ArmorType() => _commonContainer.ArmorType;//"Тип брони";
    public string Armor() => _commonContainer.Armor;//"Броня";
    public string DodgePenalty() => _commonContainer.DodgePenalty;//"Штраф уворота";
    public string MinBlockBonus() => _commonContainer.MinBlockBonus;//"МинБлокБонус";
    public string MaxBlockBonus() => _commonContainer.MaxBlockBonus;//"МаксБлокБонус";

    public string RaceName(Race race)
    {
        return race switch
        {
            Race.Dwarf => _commonContainer.RaceName_Dwarf,//"Дварф",
            Race.Elf => _commonContainer.RaceName_Elf,//"Эльф",
            Race.Human => _commonContainer.RaceName_Human,//"Человек",
            Race.Goblin => _commonContainer.RaceName_Goblin,//"Гоблин",
            Race.Orc => _commonContainer.RaceName_Orc,//"Орк",
            Race.Beast => _commonContainer.RaceName_Beast,//"Зверь",
            Race.None => throw new NotImplementedException(),
            _ => throw new NotImplementedException(),
        };
    }
    public string HungerLevelName(HungerLevel hungerLevel)
    {
        return hungerLevel switch
        {
            HungerLevel.Hungry => _commonContainer.HungerLevelName_Hungry,//"Голод",
            HungerLevel.Neutral => _commonContainer.HungerLevelName_Neutral,//"Норма",
            HungerLevel.Satiated => _commonContainer.HungerLevelName_Satiated,//"Сытость",
            HungerLevel.None => throw new NotImplementedException(),
            _ => throw new NotImplementedException(),
        };
    }

    public string ThirstLevelName(ThirstLevel thirstLevel)
    {
        return thirstLevel switch
        {
            ThirstLevel.Thirsty => _commonContainer.ThirstLevelName_Thirsty,//"Жажда",
            ThirstLevel.Neutral => _commonContainer.ThirstLevelName_Neutral,//"Норма",
            ThirstLevel.Satiated => _commonContainer.ThirstLevelName_Satiated,//"Сытость",
            ThirstLevel.None => throw new NotImplementedException(),
            _ => throw new NotImplementedException(),
        };
    }

    public string PlayerMoveSuccessfully(Direction direction)
    {
        return direction switch
        {
            Direction.N => _commonContainer.PlayerMoveSuccessfully_N,//"Вы пошли на Север",
            Direction.S => _commonContainer.PlayerMoveSuccessfully_S,//"Вы пошли на Юг",
            Direction.W => _commonContainer.PlayerMoveSuccessfully_W,//"Вы пошли на Запад",
            Direction.E => _commonContainer.PlayerMoveSuccessfully_E,//"Вы пошли на Восток",
            Direction.None => throw new NotImplementedException(),
            _ => throw new NotImplementedException(),
        };
    }

    public string PlayerMoveUnsuccessfully(Direction direction)
    {
        return direction switch
        {
            Direction.N => _commonContainer.PlayerMoveUnsuccessfully_N,//"Вы не можете пойти на Север",
            Direction.S => _commonContainer.PlayerMoveUnsuccessfully_S,//"Вы не можете пойти на Юг",
            Direction.W => _commonContainer.PlayerMoveUnsuccessfully_W,//"Вы не можете пойти на Запад",
            Direction.E => _commonContainer.PlayerMoveUnsuccessfully_E,//"Вы не можете пойти на Восток",
            Direction.None => throw new NotImplementedException(),
            _ => throw new NotImplementedException(),
        };
    }

    public string DamageTypeName(DamageType damageType) => damageType switch
    {
        Controllers.Inventory_.Items.DamageType.Slashing =>     _commonContainer.DamageTypeName_Slashing,//"Рубящий",
        Controllers.Inventory_.Items.DamageType.Piercing =>     _commonContainer.DamageTypeName_Piercing,//"Колющий",
        Controllers.Inventory_.Items.DamageType.Bludgeoning =>  _commonContainer.DamageTypeName_Bludgeoning,//"Дробящий",
        Controllers.Inventory_.Items.DamageType.None => throw new NotImplementedException(),
        _ => throw new NotImplementedException(),
    };

    public string GripName(Grip grip)
    {
        return grip switch
        {
            Controllers.Inventory_.Items.Grip.SingleHanded  => _commonContainer.GripName_SingleHanded,//"Одноручное",
            Controllers.Inventory_.Items.Grip.TwoHanded     => _commonContainer.GripName_TwoHanded,   //"Двуручное",
            Controllers.Inventory_.Items.Grip.None => throw new NotImplementedException(),
            _ => throw new NotImplementedException(),
        };
    }

    public string ArmorTypeName(ArmorType armorType)
    {
        return armorType switch
        {
            Controllers.Inventory_.Items.ArmorType.Light    => _commonContainer.ArmorTypeName_Light,//"Легкая",
            Controllers.Inventory_.Items.ArmorType.Medium   => _commonContainer.ArmorTypeName_Medium,//"Средняя",
            Controllers.Inventory_.Items.ArmorType.Heavy    => _commonContainer.ArmorTypeName_Heavy,//"Тяжелая",
            Controllers.Inventory_.Items.ArmorType.None => throw new NotImplementedException(),
            _ => throw new NotImplementedException(),
        };
    }

    public string TrapTypeName(TrapType trapType)
    {
        return trapType switch
        {
            TrapType.SpikeTrap  => _commonContainer.TrapTypeName_SpikeTrap,//"Ловушка с шипами",
            TrapType.BearTrap   => _commonContainer.TrapTypeName_BearTrap,//"Медвежий капкан",
            TrapType.None => throw new NotImplementedException(),
            _ => throw new NotImplementedException(),
        };
    }

    public string ItemName(string name)
    {
        return _itemNames.TryGetValue(name, out var itemName) ? itemName : name;

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
        return _characterNames.TryGetValue(name, out var characterName) ? characterName : name;

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

    public string QuestTranslation(string localizationKey)
    {
        return _quests.TryGetValue(localizationKey, out var text) ? text : localizationKey;

        return localizationKey switch
        {
            "Quest_0_Name" => "Главный квест",
            "Quest_0_Description" => "Найдите и устраните причину беспокойства местных жителей",
            "Quest_0_0_Description" => "Старт квеста",
            "Quest_0_0_0_GoalDescription" => "Получите квест",
            "Quest_0_0_PhaseComplitedMessage" => "Квест получен",
            "Quest_0_1_Description" => "Исследуйте окрестности",
            "Quest_0_1_0_GoalDescription" => "Найдите первые зацепки",
            "Quest_0_1_PhaseComplitedMessage" => "Гоблины!\n" +
                "Вот и причина беспокойства местных жителей. Однако гоблины довольно неорганизованы и трусливы, чтобы оказаться так долеко от привычных мест обитания.\n" +
                "Необходимо продолжить обследование окрестностей, чтобы найти, кто за ними стоит.",
            "Quest_0_10_Description" => "Продолжайте исследовать окрестности",
            "Quest_0_10_0_GoalDescription" => "Найдите, кто стоит за гоблинами",
            "Quest_0_10_PhaseComplitedMessage" => "Гоблины и орки действуют сообща?\n" +
                "Зеленокожие дикари всегда были заняты войнами друг с другом и редко появлялись за пределами своих территорий.\n" +
                "Чтобы командующий фортом не счел это глупой шуткой, необходимо продолжить расследование и сбор доказательств.",
            "Quest_0_20_Description" => "Продолжайте исследовать местность в происках новых зацепок",
            "Quest_0_20_0_GoalDescription" => "Получите 8 уровень",
            "Quest_0_20_PhaseComplitedMessage" => "В вещах последнего убитого зеленокожего вы нашли записку.\n" +
                "Хоть вы и не знакоми с орочьей грамотой, но записка явно написана кем-то важным, а внешний вид говорит о том, что написана она была совсем недавно.\n" +
                "Необходимо найти и уничтожить его, пока не поздно!",
            "Quest_0_30_Description" => "Найдите и убейте командира зеленокожих",
            "Quest_0_30_0_GoalDescription" => "Убейте Матерого Орка-капитана",
            "Quest_0_30_PhaseComplitedMessage" => "Тяжело дыша вы убираете оружие и осматриваете поле боя.\n" +
                "Без жесткого управления командиром зеленокожие утратят свою прыть и прибывшим сюда после вас отрядам из ближайшего форта без труда удастся с ними раборбаться.\n\n" +
                "Из ближайших кустов вываливаются два стражника, которых вы видели на городской площади.\n" +
                "\"Из столицы прибыл гонец с ужасными новостями! Зеленокожие объединились, их орда движется сметая все на своем пути! " +
                "Власти начали эвакуацию населения, а всех способных держать оружие призывают в Столицу!\"\n\n" +
                "(на этом сюжет заканчивается, но вы можете продолжать игру дальше)",
            "Quest_0_100_Description" => "Конец квеста",
            "Quest_0_100_0_GoalDescription" => "Завершите квест",
            "Quest_0_100_PhaseComplitedMessage" => "Квест завершен",

            _ => localizationKey,
        };
    }

    private class LocalizationContainer
    {
        public string Button_Exit { get; set; } = "qwer";
        public string Button_LoadGame { get; set; } = "qwer";
        public string Button_NewGame { get; set; } = "qwer";
        public string Button_StartGame { get; set; } = "qwer";
        public string Button_MainMenu { get; set; } = "qwer";
        public string Button_GoToGame { get; set; } = "qwer";
        public string Button_Rest { get; set; } = "qwer";
        public string Button_Attack { get; set; } = "qwer";
        public string Button_TryLeaveBattle { get; set; } = "qwer";
        public string Button_Trader { get; set; } = "qwer";
        public string Button_RestInTown { get; set; } = "qwer";
        public string Button_LeaveTown { get; set; } = "qwer";
        public string Button_Log { get; set; } = "qwer";
        public string Button_EnterTown { get; set; } = "qwer";
        public string Button_Close { get; set; } = "qwer";

        public string Label_AbilityPoints { get; set; } = "qwer";
        public string Label_Abilities { get; set; } = "qwer";
        public string Label_Charisma { get; set; } = "qwer";
        public string Label_Constitution { get; set; } = "qwer";
        public string Label_Dexterity { get; set; } = "qwer";
        public string Label_Perception { get; set; } = "qwer";
        public string Label_Race { get; set; } = "qwer";
        public string Label_Strength { get; set; } = "qwer";
        public string Label_Intro { get; set; } = "qwer";

        public string ToolTip_AbilityPoints { get; set; } = "qwer";
        public string ToolTip_Strength { get; set; } = "qwer";
        public string ToolTip_Dexterity { get; set; } = "qwer";
        public string ToolTip_Constitution { get; set; } = "qwer";
        public string ToolTip_Perception { get; set; } = "qwer";
        public string ToolTip_Charisma { get; set; } = "qwer";
        public string ToolTip_Race { get; set; } = "qwer";

        public string Message_YouFindLoot { get; set; } = "qwer";
        public string Message_Coins { get; set; } = "qwer";
        public string Message_YouFindLockedChest { get; set; } = "qwer";
        public string Message_PickLockedChestSuccess { get; set; } = "qwer";
        public string Message_PickLockedChestFail { get; set; } = "qwer";
        public string Message_BreakChestSuccess { get; set; } = "qwer";
        public string Message_BreakChestFail { get; set; } = "qwer";
        public string Message_YouFindHiddenLoot { get; set; } = "qwer";
        public string Message_FindSpikeTrapSuccess { get; set; } = "qwer";
        public string Message_FindBearTrapSuccess { get; set; } = "qwer";
        public string Message_FindSpikeTrapFail { get; set; } = "qwer";
        public string Message_FindBearTrapFail { get; set; } = "qwer";
        public string Message_StartRestInTownFree { get; set; } = "qwer";
        public string Message_YouRestInTown { get; set; } = "qwer";
        public string Message_YouHaveNoMoneyToRestInTown { get; set; } = "qwer";
        public string Message_BattleStart { get; set; } = "qwer";
        public string Message_YouAreEscaped { get; set; } = "qwer";
        public string Message_YouAreNotEscaped { get; set; } = "qwer";
        public string Message_MapExplored { get; set; } = "qwer";
        public string Message_StartRestInTown { get; set; } = "qwer";
        public string Message_FirstHitsSecondWithDamage { get; set; } = "qwer";
        public string Message_FirstHitsSecondWithCriticalDamage { get; set; } = "qwer";
        public string Message_FirstMissedSecond { get; set; } = "qwer";
        public string Message_QuestComplited { get; set; } = "qwer";

        public string CharacterGainNewLevel { get; set; } = "qwer";
        public string YouUse { get; set; } = "qwer";
        public string Shop { get; set; } = "qwer";
        public string YouGained { get; set; } = "qwer";
        public string DefaultCharacterName { get; set; } = "qwer";
        public string Level { get; set; } = "qwer";
        public string Menu { get; set; } = "qwer";
        public string SaveAndExit { get; set; } = "qwer";
        public string UnexploredLocation { get; set; } = "qwer";
        public string EmptyExploredLocation { get; set; } = "qwer";
        public string Town { get; set; } = "qwer";
        public string Enemy { get; set; } = "qwer";
        public string LevelBoarder { get; set; } = "qwer";
        public string PlayerRest { get; set; } = "qwer";
        public string Bonus { get; set; } = "qwer";
        public string Equipment { get; set; } = "qwer";
        public string Cost { get; set; } = "qwer";
        public string Experience { get; set; } = "qwer";
        public string SellCost { get; set; } = "qwer";
        public string DamageType { get; set; } = "qwer";
        public string Grip { get; set; } = "qwer";
        public string Damage { get; set; } = "qwer";
        public string ArmorType { get; set; } = "qwer";
        public string Armor { get; set; } = "qwer";
        public string DodgePenalty { get; set; } = "qwer";
        public string MinBlockBonus { get; set; } = "qwer";
        public string MaxBlockBonus { get; set; } = "qwer";
        public string RaceName_Dwarf { get; set; } = "qwer";
        public string RaceName_Elf { get; set; } = "qwer";
        public string RaceName_Human { get; set; } = "qwer";
        public string RaceName_Goblin { get; set; } = "qwer";
        public string RaceName_Orc { get; set; } = "qwer";
        public string RaceName_Beast { get; set; } = "qwer";
        public string HungerLevelName_Hungry { get; set; } = "qwer";
        public string HungerLevelName_Neutral { get; set; } = "qwer";
        public string HungerLevelName_Satiated { get; set; } = "qwer";
        public string ThirstLevelName_Thirsty { get; set; } = "qwer";
        public string ThirstLevelName_Neutral { get; set; } = "qwer";
        public string ThirstLevelName_Satiated { get; set; } = "qwer";
        public string PlayerMoveSuccessfully_N { get; set; } = "qwer";
        public string PlayerMoveSuccessfully_S { get; set; } = "qwer";
        public string PlayerMoveSuccessfully_W { get; set; } = "qwer";
        public string PlayerMoveSuccessfully_E { get; set; } = "qwer";
        public string PlayerMoveUnsuccessfully_N { get; set; } = "qwer";
        public string PlayerMoveUnsuccessfully_S { get; set; } = "qwer";
        public string PlayerMoveUnsuccessfully_W { get; set; } = "qwer";
        public string PlayerMoveUnsuccessfully_E { get; set; } = "qwer";
        public string DamageTypeName_Slashing { get; set; } = "qwer";
        public string DamageTypeName_Piercing { get; set; } = "qwer";
        public string DamageTypeName_Bludgeoning { get; set; } = "qwer";
        public string GripName_SingleHanded { get; set; } = "qwer";
        public string GripName_TwoHanded { get; set; } = "qwer";
        public string ArmorTypeName_Light { get; set; } = "qwer";
        public string ArmorTypeName_Medium { get; set; } = "qwer";
        public string ArmorTypeName_Heavy { get; set; } = "qwer";
        public string TrapTypeName_SpikeTrap { get; set; } = "qwer";
        public string TrapTypeName_BearTrap { get; set; } = "qwer";
    }
}