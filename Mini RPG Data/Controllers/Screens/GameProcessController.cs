using Mini_RPG_Data.Map_;
using Mini_RPG_Data.Services.Random_;
using Mini_RPG_Data.Viewes;

namespace Mini_RPG_Data.Controllers.Screens;

public class GameProcessController
{
    private readonly IRandomService _randomService;
    private readonly IGameProcessView _gameProcessView;
    private Map _map = null!;

    public GameProcessController(IRandomService randomService, IGameProcessView gameProcessView)
    {
        _randomService = randomService;
        _gameProcessView = gameProcessView;
        _gameProcessView.SetGameProcessController(this);

        //GenerateNewMap();
        _gameProcessView.ShowMap(_map);
    }

    //private void GenerateNewMap() => _map = Map.Generate(_randomService);
}