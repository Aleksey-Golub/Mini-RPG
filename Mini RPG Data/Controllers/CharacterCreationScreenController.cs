using Mini_RPG_Data.Viewes;
using Mini_RPG_Data.Services.PersistentProgress;
using Mini_RPG_Data.Datas;
using Mini_RPG_Data.Map;
using Mini_RPG_Data.Services.Random_;

namespace Mini_RPG_Data.Controllers;

public class CharacterCreationScreenController
{
    private readonly ICharacterCreationScreenView _characterCreationScreen;
    private readonly IIntroScreenView _introScreen;
    private readonly IPersistentProgressService _progressService;
    private readonly IRandomService _randomService;

    public CharacterCreationScreenController(
        ICharacterCreationScreenView characterCreationScreen, 
        IIntroScreenView introScreen, 
        IPersistentProgressService progressService, 
        IRandomService randomService)
    {
        _characterCreationScreen = characterCreationScreen;
        _introScreen = introScreen;
        _progressService = progressService;
        _randomService = randomService;
        _progressService.Progress = NewProgress();
    }

    private PlayerProgress NewProgress()
    {
        var progress = new PlayerProgress(MapData.Generate(_randomService));

        return progress;
    }
}
