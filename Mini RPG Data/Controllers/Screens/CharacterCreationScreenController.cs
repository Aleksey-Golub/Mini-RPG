using Mini_RPG_Data.Viewes;
using Mini_RPG_Data.Services.PersistentProgress;
using Mini_RPG_Data.Datas;
using Mini_RPG_Data.Map_;
using Mini_RPG_Data.Services.Random_;
using Mini_RPG_Data.Services.SaveLoad;
using Mini_RPG_Data.Character_;
using Mini_RPG_Data.Controllers.Character_.Abilities_;

namespace Mini_RPG_Data.Controllers.Screens;

public class CharacterCreationScreenController
{
    private readonly ICharacterCreationScreenView _characterCreationScreen;
    private readonly IIntroScreenView _introScreen;
    private readonly IPersistentProgressService _progressService;
    private readonly IRandomService _randomService;
    private readonly ISaveLoadService _saveLoadService;

    private Player _player;

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
        _introScreen = introScreen;
        _characterCreationScreen = characterCreationScreen;
    }

    public void Init()
    {
        _progressService.Progress = NewProgress();
        _player = new Player(_progressService.Progress.PlayerData);
        _player.Init();
        _characterCreationScreen.SetCharacter(_player.Character);
    }

    public event Action? GameStarted;

    public void SetRace(CharacterRace newRace) => _player.Character.Race = newRace;

    public void DecreaseAbility(AbilityType abilityType) => _player.Character.AllAbilities.Decrease(abilityType);

    public void IncreaseAbility(AbilityType abilityType) => _player.Character.AllAbilities.Increase(abilityType);

    public void StartGame(string avatarPath, string name)
    {
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

        progress.PlayerData.WalletData.Money = 10;
        return progress;
    }
}
