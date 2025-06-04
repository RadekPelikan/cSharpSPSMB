using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace SimpleChatApp.BE.Hubs;

public class ChatHub : Hub
{
    private ChatMessageRepository _chatMessageRepository;

    public ChatHub()
    {
        _chatMessageRepository = new ChatMessageRepository();
    }


    public void Connect(Guid connectionId)
    {
        Console.WriteLine($"User connected to chat hub {connectionId}");
        var messages = _chatMessageRepository.GetAll();
        Clients.Caller.SendAsync("LoadMessages", messages);
    }
    
    public void SendMessage(ChatMessage message)
    {
        Console.WriteLine($"Messge: {message}");
        // Call the broadcastMessage method to update clients.
        // Clients.All.broadcastMessage(name, message);
        _chatMessageRepository.Insert(message);
        Clients.All.SendAsync("ReceiveMessage", message);
    }
    
    
}