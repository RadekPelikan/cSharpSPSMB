using Microsoft.AspNetCore.SignalR;
using signalrExample.Common;

namespace signalrExample.Hubs;

public class UserHub(ILogger<UserHub> logger) : Hub
{
    private static List<UserLoginModel> _users = new List<UserLoginModel>();
    
    public override Task OnConnectedAsync()
    {
        logger.LogInformation("[{connectionId}] User connected", Context.ConnectionId);
        
        return base.OnConnectedAsync();
    }

    public override Task OnDisconnectedAsync(Exception? exception)
    {
        logger.LogInformation("[{connectionId}] User disconnected ", Context.ConnectionId);
        
        return base.OnDisconnectedAsync(exception);
    }
    
    public Task Login(UserLoginModel loginModel)
    {
        logger.LogInformation("[{connectionId}] User Login {loginModel}", Context.ConnectionId, loginModel);
        _users.Add(loginModel);
        
        Clients.Others.SendAsync("ReceiveLogin", _users);
        
        return base.OnConnectedAsync();
    }
}