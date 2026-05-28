using System.Text.RegularExpressions;
using Microsoft.AspNetCore.SignalR;

public class UserHub : Hub
{
    private readonly ILogger<UserHub> _logger;
    private static readonly List<User> _users = new();

    public UserHub(ILogger<UserHub> logger)
    {
        _logger = logger;
    }

    public void Ping()
    {
        _logger.LogInformation("Metoda Ping!");
        Clients.Caller.SendAsync("Pong");
    }

    public void Register(User user)
    {
        _users.Add(user);
        Groups.AddToGroupAsync(Context.ConnectionId, "Registered");
        
        _logger.LogInformation("Metoda Register {user}, usercount: {userCount}", user, _users.Count);

        // Clients.Caller.SendAsync("ReceiveRegister", _users);
        Clients.Group("Registered").SendAsync("ReceiveRegister", _users);
    }
}

