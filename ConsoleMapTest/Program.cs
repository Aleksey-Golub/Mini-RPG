using Mini_RPG_Data.Services.Random_;

public class Program
{
    public static void Main()
    {
        IRandomService randomService = new RandomService();
        IGameProcessView gameProcessView = new WriteTextFileGameProcessView();
        var gameProcessController = new GameProcessController(randomService, gameProcessView);
    }
}
