using Mini_RPG_Data;
using Mini_RPG_Data.Map;
using Mini_RPG_Data.Services.Random_;

public class GameProcessController
{
    private readonly IRandomService _randomService;
    private readonly IGameProcessView _gameProcessView;
    private MapData _mapData = null!;

    private MapDTO _mapDTO = null!;

    public GameProcessController(IRandomService randomService, IGameProcessView gameProcessView)
    {
        _randomService = randomService;
        _gameProcessView = gameProcessView;
        _gameProcessView.SetGameProcessController(this);

        GenerateNewMap();
        _gameProcessView.ShowMap(_mapDTO);
    }

    private void GenerateNewMap()
    {
        _mapData = MapData.Generate(_randomService);

        int minX = int.MaxValue;
        int minY = int.MaxValue;
        int maxX = int.MinValue;
        int maxY = int.MinValue;

        foreach (Vector2Int key in _mapData.Cells.Keys)
        {
            if (key.X < minX)
                minX = key.X;
            if (key.Y < minY)
                minY = key.Y;
            if (key.X > maxX)
                maxX = key.X;
            if (key.Y > maxY)
                maxY = key.Y;
        }

        _mapDTO = new MapDTO(_mapData, minX, maxX, minY, maxY);
    }
}
