// See https://aka.ms/new-console-template for more information

using Microsoft.AspNetCore.SignalR.Client;
using signalrExample.Common;



var connection = new HubConnectionBuilder()
    .WithUrl("http://localhost:5104/socket/user")
    .Build();
    
await connection.StartAsync();

var user = new UserLoginModel("Test User", $"test_{Random.Shared.Next(100, 999)}");

Console.WriteLine($"Signalr Client test! {user}");
await connection.SendAsync("Login", user);

connection.On<IEnumerable<UserLoginModel>>("ReceiveLogin", users =>
{
    Console.WriteLine("---------------");
    foreach (var user in users)
    {
        Console.WriteLine(user);
    }
});

Console.WriteLine("Press Key to Disconnect");

Console.ReadKey();

await connection.StopAsync();