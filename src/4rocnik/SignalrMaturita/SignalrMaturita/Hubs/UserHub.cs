using Microsoft.AspNetCore.SignalR;
using SignalrMaturita.Models;

namespace SignalrMaturita.Hubs;

public class UserHub : Hub
{
    private readonly ILogger<UserHub> _logger;
    public UserHub(ILogger<UserHub> logger)
    {
        _logger = logger;
    }
    
    // pridej override na onConnected a onDisconected

    public override Task OnConnectedAsync()
    {
        _logger.LogInformation("Client connected");
        return base.OnConnectedAsync();
    }

    public override Task OnDisconnectedAsync(Exception? exception)
    {
        _logger.LogInformation("Client disconnected");
        return base.OnDisconnectedAsync(exception);
    }

    // pridej metodu Test, ktera odesle zpet ReceiveTest
    public string Test()
    {
        Groups.AddToGroupAsync() 
    }
    // pridej metodu Login(UserLoginModel loginModel), ktera prihlasi uzivatele a
    // odesle metodu ReceiveLogin vsem klientum
}