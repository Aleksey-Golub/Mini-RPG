using Mini_RPG_Data.Viewes;
using Mini_RPG_Data.Services.PersistentProgress;
using Mini_RPG_Data.Datas;
using Mini_RPG_Data.Map;
using Mini_RPG_Data.Services.Random_;
using Mini_RPG_Data.Services.SaveLoad;
using Mini_RPG_Data.Character_;

namespace Mini_RPG_Data.Controllers;

public class CharacterCreationScreenController
{
    private readonly ICharacterCreationScreenView _characterCreationScreen;
    private readonly IIntroScreenView _introScreen;
    private readonly IPersistentProgressService _progressService;
    private readonly IRandomService _randomService;
    private readonly ISaveLoadService _saveLoadService;

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

        _characterCreationScreen = characterCreationScreen;
        _characterCreationScreen.SetModel(_progressService.Progress.PlayerData.Character);
        _introScreen = introScreen;
    }

    private PlayerProgress NewProgress()
    {
        var progress = new PlayerProgress(MapData.Generate(_randomService));

        return progress;
    }

    public void SetRace(CharacterRace newRace) => _progressService.Progress.PlayerData.Character.Race = newRace;

    public void DecreaseAbility(AbilityType abilityType) => _progressService.Progress.PlayerData.Character.Abilities.Decrease(abilityType);

    public void IncreaseAbility(AbilityType abilityType) => _progressService.Progress.PlayerData.Character.Abilities.Increase(abilityType);

    public void StartGame(byte[] avatar, string name)
    {
        _progressService.Progress.PlayerData.Character.Avatar = avatar;
        _progressService.Progress.PlayerData.Character.Name = name;

        _saveLoadService.SaveProgress();
    }
}
