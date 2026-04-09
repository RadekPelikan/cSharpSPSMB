// See https://aka.ms/new-console-template for more information

using Microsoft.AspNetCore.SignalR.Client;

Console.WriteLine("Hello, World!");

var connection = new HubConnectionBuilder().WithUrl("http://localhost:5291/hubs/chat").Build();

await connection.StartAsync();

// odesli metodu Test

// budes poslouchat na ReceiveTest

// odesli metodu login s nejakou instanci modelu UserLoginModel

// budes poslouchat na ReceiveLogin, ktera prijme list UserLoginModel

await connection.StopAsync();