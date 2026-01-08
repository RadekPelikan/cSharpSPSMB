// See https://aka.ms/new-console-template for more information


using Microsoft.AspNetCore.SignalR.Client;
using signalrUser.Common;

var user = new UserLoginModel($"user_{Random.Shared.Next(100, 999)}", "test");

Console.WriteLine(user);

var connection = new HubConnectionBuilder().WithUrl("http://localhost:5257/socket/user").Build();


await connection.StartAsync();

connection.On<Dictionary<string, UserLoginModel>>("ReceiveLogin", users =>
{
    Console.WriteLine("------------");
    foreach (var userLoginModel in users)
    {
        Console.WriteLine(userLoginModel);
    }
});

await connection.SendAsync("Login", user);

Console.WriteLine("Press key to Disconnect!");

Console.ReadKey();

await connection.StopAsync();