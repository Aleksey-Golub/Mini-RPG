﻿using Mini_RPG_Data.Viewes;
using Mini_RPG_Data.Services.PersistentProgress;
using Mini_RPG_Data.Datas;
using Mini_RPG_Data.Map;
using Mini_RPG_Data.Services.Random_;
using Mini_RPG_Data.Services.SaveLoad;
using Mini_RPG_Data.Character_;
using Mini_RPG_Data.Datas.Character_.Abilities_;
using Mini_RPG_Data.Player_;

namespace Mini_RPG_Data.Controllers;

public class CharacterCreationScreenController
{
    private readonly ICharacterCreationScreenView _characterCreationScreen;
    private readonly IIntroScreenView _introScreen;
    private readonly IPersistentProgressService _progressService;
    private readonly IRandomService _randomService;
    private readonly ISaveLoadService _saveLoadService;
    
    private readonly Player _player;

    public CharacterCreationScreenController(
        ICharacterCreationScreenView characterCreationScreen,
        IIntroScreenView introScreen,
        IPersistentProgressService progressService,
        IRandomService randomService,
        ISaveLoadService saveLoadService)
    {
        _randomService = randomService;
        _saveLoadService = saveLoadService;
        _progressService = progressService;
        _progressService.Progress = NewProgress();
        _player = new Player(_progressService.Progress.PlayerData);
        _player.Init();

        _characterCreationScreen = characterCreationScreen;
        _characterCreationScreen.SetCharacter(_player.Character);
        _introScreen = introScreen;
    }

    private PlayerProgress NewProgress()
    {
        var progress = new PlayerProgress(MapData.Generate(_randomService));

        progress.PlayerData.WalletData.Money = 10;
        return progress;
    }

    public void SetRace(CharacterRace newRace) => _player.Character.Race = newRace;

    public void DecreaseAbility(AbilityType abilityType) => _player.Character.AllAbilities.Decrease(abilityType);

    public void IncreaseAbility(AbilityType abilityType) => _player.Character.AllAbilities.Increase(abilityType);

    public void StartGame(string avatarPath, string name)
    {
        _progressService.Progress.PlayerData.CharacterData.AvatarPath = avatarPath;
        _progressService.Progress.PlayerData.CharacterData.Name = name;

        _saveLoadService.SaveProgress();

        //_progressService.Progress = _saveLoadService.LoadProgressOrNull();
        var data = _saveLoadService.LoadPlayerDataOrNull();
    }
}
