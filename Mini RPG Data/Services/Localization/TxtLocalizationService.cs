using Mini_RPG_Data.Character_;
using Mini_RPG_Data.Controllers;
using Mini_RPG_Data.Controllers.Character_;
using Mini_RPG_Data.Controllers.Inventory_.Items;
using Mini_RPG_Data.Controllers.Map_;
using Mini_RPG_Data.Controllers.Quest_;

namespace Mini_RPG_Data.Services.Localization;

public class TxtLocalizationService : ILocalizationService
{
    private const string DIRECTORY = "Localization\\";
    private const string LANGUAGE_KEY = "language";

    private readonly Dictionary<string, Dictionary<string, string>> _allLocalizations = new Dictionary<string, Dictionary<string, string>>();
    private readonly Dictionary<string, string> _currentLangageSource = new();
    private readonly LocalizationContainer? _commonContainer;

    public TxtLocalizationService()
    {
        _commonContainer = new LocalizationContainer();

        try
        {
            string[] languagesDirectories = Directory.GetDirectories(DIRECTORY);

            foreach (var dir in languagesDirectories)
            {
                string[] localizationFiles = Directory.GetFiles(dir);
                var localizationSource = new Dictionary<string, string>();
                FillDictionaryFromFiles(localizationSource, localizationFiles);
                
                string languageKey = localizationSource.ContainsKey(LANGUAGE_KEY) ? localizationSource[LANGUAGE_KEY] : dir;

                _allLocalizations.TryAdd(languageKey, localizationSource);
            }
            _currentLangageSource = _allLocalizations["Русский"];
        }
        catch { }
    }

    public event Action? LanguageChanged;

    public string GetLocalization(string localizationKey) => _currentLangageSource.TryGetValue(localizationKey, out var text) ? text : localizationKey;

    private void FillDictionaryFromFiles(Dictionary<string, string> dictionary, params string[] filePaths)
    {
        foreach (var filePath in filePaths)
        {
            try
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
            catch { }
        }
    }



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
        public string Message_YouFindHiddenChest { get; set; } = "qwer";
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