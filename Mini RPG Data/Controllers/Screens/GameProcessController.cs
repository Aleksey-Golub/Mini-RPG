using Mini_RPG_Data.Services.Random_;
using Mini_RPG_Data.Services.PersistentProgress;
using Mini_RPG_Data.Viewes;
using Mini_RPG_Data.Map_;

namespace Mini_RPG_Data.Controllers.Screens;

public class GameProcessController
{
    private readonly IRandomService _randomService;
    private readonly IPersistentProgressService _progressService;
    private readonly IGameProcessView _gameProcessView;
    private readonly ILogView _logView;

    private Player _player;
    private Map _map;

    public GameProcessController(IGameProcessView gameProcessView, ILogView logView, IRandomService randomService, IPersistentProgressService progressService)
    {
        _gameProcessView = gameProcessView;
        _logView = logView;
        _randomService = randomService;
        _progressService = progressService;

        _gameProcessView.SetGameProcessController(this);
    }

    public void Run()
    {
        _player = new Player(_progressService.Progress.PlayerData);
        _map = new Map(_progressService.Progress.MapData);

        _gameProcessView.Init(_player.Character, _player.Wallet, _map);
        _gameProcessView.SetActiveState(true);
    }
}