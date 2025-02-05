using Duolingo.Components;

namespace Duolingo;

static class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        // To customize application configuration such as set high DPI settings or default font,
        // see https://aka.ms/applicationconfiguration.
        ApplicationConfiguration.Initialize();
        var form1 = new MainForm();
        form1.Controls.Add(new BaseView() { Dock = DockStyle.Fill });
        form1.Show();
        Application.Run();
    }
}