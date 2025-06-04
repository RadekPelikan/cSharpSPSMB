using Microsoft.AspNetCore.SignalR;

namespace SimpleChatApp.BE.Hubs;

public class ChatHub : Hub
{
    public override Task OnConnectedAsync()
    {
        base.OnConnectedAsync();
        Console.WriteLine(Clients.Client(Context.ConnectionId));
        return Task.CompletedTask;
    }

    public void SendMessage(string message)
    {
        // Call the broadcastMessage method to update clients.
        // Clients.All.broadcastMessage(name, message);
        Console.WriteLine($"Sending message: {message}");
        Clients.All.SendAsync("ReceiveMessage", message);
    }
    
    
}