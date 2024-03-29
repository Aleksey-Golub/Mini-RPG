﻿using Mini_RPG_Data.Viewes;
using Mini_RPG_Data.Services.PersistentProgress;
using Mini_RPG_Data.Datas;
using Mini_RPG_Data.Controllers.Map_;
using Mini_RPG_Data.Services.Random_;
using Mini_RPG_Data.Services.SaveLoad;
using Mini_RPG_Data.Character_;
using Mini_RPG_Data.Controllers.Character_.Abilities_;
using Mini_RPG_Data.Datas.Inventory_;
using Mini_RPG_Data.Datas.Quest_.QuestDB;
using Mini_RPG_Data.Datas.Quest_;
using Mini_RPG_Data.Services.Quest_;

namespace Mini_RPG_Data.Controllers.Screens;

public class CharacterCreationScreenController
{
    private const string MAIN_QUEST_ID = "Main_Quest";
    private readonly ICharacterCreationScreenView _characterCreationScreen;
    private readonly IIntroScreenView _introScreen;
    private readonly IPersistentProgressService _progressService;
    private readonly IRandomService _randomService;
    private readonly ISaveLoadService _saveLoadService;
    private readonly IQuestService _questService;
    private Player _player = null!;

    public CharacterCreationScreenController(
        ICharacterCreationScreenView characterCreationScreen,
        IIntroScreenView introScreen,
        IPersistentProgressService progressService,
        IRandomService randomService,
        ISaveLoadService saveLoadService,
        IQuestService questService)
    {
        _randomService = randomService;
        _saveLoadService = saveLoadService;
        _questService = questService;
        _progressService = progressService;
        _introScreen = introScreen;
        _characterCreationScreen = characterCreationScreen;
    }

    public void Init()
    {
        _progressService.Progress = NewProgress();
        _player = new Player(_progressService.Progress.PlayerData);
        _player.Init();

        _characterCreationScreen.Init(_player.Character);
    }

    public event Action? GameStarted;

    public void SetRace(Race newRace) => _player.Character.Race = newRace;

    public void DecreaseAbility(AbilityType abilityType) => _player.Character.AllAbilities.Decrease(abilityType);

    public void IncreaseAbility(AbilityType abilityType) => _player.Character.AllAbilities.Increase(abilityType);

    public void StartGame(string avatarPath, string name)
    {
        _player.Character.Health.Init();
        _progressService.Progress.PlayerData.CharacterData.AvatarPath = avatarPath;
        _progressService.Progress.PlayerData.CharacterData.Name = name;

        _characterCreationScreen.SetActiveState(false);
        _introScreen.SetActiveState(true);
    }

    public void GoToGame()
    {
        _saveLoadService.SaveProgress();

        _introScreen.SetActiveState(false);
        GameStarted?.Invoke();
    }

    private PlayerProgress NewProgress()
    {
        var progress = new PlayerProgress(Map.Generate(_randomService));
        SetStartCharacterStaff(progress);
        SetMainQuest(progress);

        progress.TownTraderData = GameRules.GetRandomTownTraderData();

        return progress;
    }

    private void SetMainQuest(PlayerProgress progress)
    {
        QuestData mainQuestData = _questService.GetByIdOrNull(MAIN_QUEST_ID);
        QuestPhaseData firstPhase = mainQuestData.Phases[0];
        List<int> goalsProgresses = new int[firstPhase.Goals.Count].ToList();
        progress.PlayerData.QuestsData.CurrentQuests.Add(
            new QuestSavedData(
                mainQuestData.Id,
                mainQuestData.Name,
                mainQuestData.Description,
                new QuestPhaseSavedData(firstPhase.Id, firstPhase.Description, goalsProgresses)));
    }

    private static void SetStartCharacterStaff(PlayerProgress progress)
    {
        progress.PlayerData.WalletData.Money = GameRules.START_MONEY;
        progress.PlayerData.CharacterData.SatiationData.FoodSatiation = GameRules.START_SATIATION;
        progress.PlayerData.CharacterData.SatiationData.WaterSatiation = GameRules.START_SATIATION;

        progress.PlayerData.CharacterData.InventoryData.Items.Add(new ItemSaveData(ItemType.Potion, "SmallHealthPotion"));
        progress.PlayerData.CharacterData.InventoryData.Items.Add(new ItemSaveData(ItemType.Food,   "Bread"));
        progress.PlayerData.CharacterData.InventoryData.Items.Add(new ItemSaveData(ItemType.Food,   "WaterFlask"));

        progress.PlayerData.CharacterData.InventoryData.EquippedItems[2] = new ItemSaveData(ItemType.Armor, "ThinLeatherArmor");
        progress.PlayerData.CharacterData.InventoryData.EquippedItems[4] = new ItemSaveData(ItemType.Weapon, "BronzeSword");
    }
}
