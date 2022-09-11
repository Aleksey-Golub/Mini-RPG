using Mini_RPG_Data.Controllers.Screens;
using Mini_RPG_Data.Services.Random_;
using Mini_RPG_Data.Viewes;

namespace ConsoleMapTest;

internal class Program
{
    public static void Main()
    {
        IRandomService randomService = new RandomService();
        IGameProcessView gameProcessView = new WriteTextFileGameProcessView();
        var gameProcessController = new GameProcessController(gameProcessView, randomService);
    }
}
