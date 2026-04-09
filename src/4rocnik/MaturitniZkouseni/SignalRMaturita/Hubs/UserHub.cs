using Microsoft.AspNetCore.SignalR;

namespace SignalRMaturita.Hubs;

public class UserHub(ILogger<UserHub> logger) : Hub

{
    public override Task OnConnectedAsync()
    {
        logger.LogInformation("Connected");
        return base.OnConnectedAsync();
    }

    public override Task OnDisconnectedAsync(Exception? exception)
    {
        logger.LogInformation("disConnected");
        return base.OnDisconnectedAsync(exception);
    }

    public void Login(User user)
    {
        logger.LogInformation(user.ToString());
    }
}