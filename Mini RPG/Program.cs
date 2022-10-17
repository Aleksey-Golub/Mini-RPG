namespace Mini_RPG;

internal static class Program
{
    [STAThread]
    static void Main()
    {
        ApplicationConfiguration.Initialize();

        Main mainForm = new Main();

        Application.Run(mainForm);
    }
}