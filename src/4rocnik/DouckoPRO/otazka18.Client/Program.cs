// See https://aka.ms/new-console-template for more information

using Microsoft.AspNetCore.SignalR.Client;

Console.WriteLine("\n\n\n\n\n");

var connection = new HubConnectionBuilder()
    .WithUrl("http://localhost:5210/hubs/user")
    .Build();



await connection.StartAsync();

/*
 * Naimplementujte odesílání zpráv z klienta:
 *
 * # Metoda Ping
 * - metoda se příjme na serveru a zpět stejnému klientovi odešle metodu Pong
 * - klient na metodu Pong musí poté poslouchat
 *
 * # Metoda Register
 * - metoda posílá v sobě nového uživatele new User("pepa");
 * - metoda se příjme na server a zpět pošle všem zaregistrovaným uživatelům metodu ReceiveRegister
 * - metoda ReceiveRegister obsahuje v sobě List<User>
 * - klient na metodu ReceiveRegister poslochá, poté vyprintuje všechny zaregistrované uživatele
 *
 * Každou metodu je potřeba zalogovat na serveru i na klintovi, takže například:
 * 1. klient odešle Ping
 * 2. Server příjme Ping -> vyprintuje "Metoda Ping"
 * 3. Server odešle Pong
 * 4. Klient příjme Pong -> vyprintuje "Metoda Pong"
 */

connection.On("Pong", () =>
{
    Console.WriteLine("Metoda Pong!");
});

connection.On("ReceiveRegister", (List<User> users) =>
{
    Console.WriteLine($"Metoda ReceiveUsers, userCount: {users.Count}");
});

await connection.SendAsync("Ping");

await connection.SendAsync("Register", new User("Pepa"));


Console.ReadKey();

await connection.StopAsync();

