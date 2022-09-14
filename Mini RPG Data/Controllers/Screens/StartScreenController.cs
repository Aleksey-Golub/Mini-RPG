using Mini_RPG_Data.Services.SaveLoad;
using Mini_RPG_Data.Services.PersistentProgress;
using Mini_RPG_Data.Viewes;

namespace Mini_RPG_Data.Controllers.Screens;

public class StartScreenController
{
    private readonly IStartScreenView _startScreenView;
    private readonly ICharacterCreationScreenView _characterCreationScreenView;

    private readonly ISaveLoadService _saveLoadService;
    private readonly IPersistentProgressService _progressService;

    public event Action? GameLoaded;

    public StartScreenController(
        IStartScreenView startScreenView,
        ICharacterCreationScreenView characterCreationScreenView,
        ISaveLoadService saveLoadService,
        IPersistentProgressService progressService)
    {
        _startScreenView = startScreenView;
        _characterCreationScreenView = characterCreationScreenView;
        _saveLoadService = saveLoadService;
        _progressService = progressService;
    }

    public void Init()
    {
        _startScreenView.SetActiveState(true);
        _startScreenView.SetLoadButtonState(_saveLoadService.GetAllSaves().Length > 0);
    }

    public void StartNewGame()
    {
        _startScreenView.SetActiveState(false);
        _characterCreationScreenView.SetActiveState(true);
    }

    public void ShowSavedGames()
    {
        string[]? saves = _saveLoadService.GetAllSaves();

        if (saves == null)
            return;

        List<SaveDTO> savesDTO = new List<SaveDTO>();
        for (int i = 0; i < saves.Length; i++)
        {
            string save = saves[i];
            var playerProgress = _saveLoadService.LoadProgressOrNull(save);
            if (playerProgress == null)
                continue;
            SaveDTO saveDTO = new SaveDTO(playerProgress.PlayerData.CharacterData.Name, playerProgress.PlayerData.CharacterData.LevelData.Value, save);
            savesDTO.Add(saveDTO);
        }
        _startScreenView.ShowSaves(savesDTO);
    }

    public void LoadGame(string selectedSave)
    {
        var playerProgress = _saveLoadService.LoadProgressOrNull(selectedSave);

        if (playerProgress != null)
        {
            _progressService.Progress = playerProgress;
            _startScreenView.SetActiveState(false);
            GameLoaded?.Invoke();
        }
    }

    public struct SaveDTO
    {
        public string FullFilePath;
        public string Name;
        public int Level;

        public SaveDTO(string name, int level, string fullFilePath)
        {
            Name = name;
            Level = level;
            FullFilePath = fullFilePath;
        }
    }
}
