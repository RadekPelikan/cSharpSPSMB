using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using SimpleChatApp.Contracts;

namespace SimpleChatApp.BE.Hubs;

public class ChatHub : Hub
{
    private IClientChatContracts _contracts;

    public ChatHub(IClientChatContracts contracts)
    {
        _contracts = contracts;
    }
    
    public void Connect(Guid connectionId)
    {
        Console.WriteLine($"User connected to chat hub {connectionId}");
    }
    
    public void SendMessage(SendMessageModel message)
    {
        Console.WriteLine($"Messge: {message}");
        _contracts.SendMessage(message);
    }
    
    public void SendJoin(SendJoinModel joinModel)
    {
        Console.WriteLine($"Joined: {joinModel}");
        _contracts.SendJoin(joinModel);
    }
    
}
