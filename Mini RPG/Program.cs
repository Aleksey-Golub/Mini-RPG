using Mini_RPG_Data.Controllers;
using Mini_RPG_Data.Viewes;

namespace Mini_RPG;

internal static class Program
{
    [STAThread]
    static void Main()
    {
        //Console.WriteLine(Resources.Program.HelloWorld);

        ApplicationConfiguration.Initialize();

        Main mainForm = new Main();

        Application.Run(mainForm);
    }
}