// See https://aka.ms/new-console-template for more information

using Microsoft.AspNetCore.SignalR.Client;

Console.WriteLine("Hello, World!");

// server:
// vytvor hub
// loguj, ze se nekdo pripojil
// pridej metodu na Test, vyloguj, ze nekdo poslal test
// Pridej record User a dej mu Name a Age
// pridej v serveru metodu Login
// ktera si zaregistruje usera a posle zpet vsechy usery
// posle je v metode "ReceiveUsers"


var connection = new HubConnectionBuilder()
    .WithUrl("http://localhost:5046/hub")
    .Build();

await connection.StartAsync();

await connection.SendAsync("Test");

// Posilej user v SendAsync("Login", new User())
connection.SendAsync("Login", new User());

// connection.On<List<User>>("ReceiveUsers", (data) =>
// {
//     // vyloguj usery
// });
connection.Closed += async (error) =>
{
    
};

public record User
{
    public string name ="pepa";
}