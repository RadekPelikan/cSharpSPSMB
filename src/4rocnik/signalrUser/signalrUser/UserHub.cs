using Microsoft.AspNetCore.SignalR;
using signalrUser.Common;

public class UserHub(ILogger<UserHub> _logger) : Hub
{
    private Dictionary<string, UserLoginModel> _users = new Dictionary<string, UserLoginModel>();
    
    public override Task OnConnectedAsync()
    {
        _logger.LogInformation("[{connectionId}] User Connected", Context.ConnectionId);
        
        return base.OnConnectedAsync();
    }

    public override Task OnDisconnectedAsync(Exception? exception)
    {
        _logger.LogInformation("[{connectionId}] User Disconnected", Context.ConnectionId);
        _users.Remove(Context.ConnectionId);
        
        return base.OnDisconnectedAsync(exception);
    }

    public Task Login(UserLoginModel loginModel)
    {
        _logger.LogInformation("[{connectionId}] User Login {loginModel}", Context.ConnectionId, loginModel);
        _users.Add(Context.ConnectionId, loginModel);

        Clients.Others.SendAsync("ReceiveLogin", _users);

        return Task.CompletedTask;
    }
}