using SimpleChatApp.Domain.Models;

namespace SimpleChatApp.Contracts.Abstract;

public interface IClientChatContracts
{
    void SendMessage(SendMessageModel model);
    
    void SendJoin(SendJoinModel model);
}