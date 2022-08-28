using Mini_RPG_Data.Map;
using Mini_RPG_Data.Services.Random_;
using Mini_RPG_Data.Viewes;

namespace Mini_RPG_Data.Controllers;

public class GameProcessController
{
    private readonly IRandomService _randomService;
    private readonly IGameProcessView _gameProcessView;
    private MapData _mapData = null!;

    public GameProcessController(IRandomService randomService, IGameProcessView gameProcessView)
    {
        _randomService = randomService;
        _gameProcessView = gameProcessView;
        _gameProcessView.SetGameProcessController(this);

        GenerateNewMap();
        _gameProcessView.ShowMap(_mapData);
    }

    private void GenerateNewMap() => _mapData = MapData.Generate(_randomService);
}