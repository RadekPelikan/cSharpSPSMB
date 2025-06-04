using Microsoft.AspNetCore.SignalR.Client;

namespace SimpleChatApp.FE;

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
        var connection = new HubConnectionBuilder()
            .WithUrl("http://192.168.5.5:5190/chat")
            .Build();
        
        Application.Run(new Form1(connection));
        connection.StopAsync().Wait();
    }
}