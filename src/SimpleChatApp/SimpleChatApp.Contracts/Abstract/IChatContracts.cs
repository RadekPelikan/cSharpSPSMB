using SimpleChatApp.Domain.Models;

namespace SimpleChatApp.Contracts.Abstract;

public interface IChatContracts
{
    void RegisterSendMessage(Action<SendContractModel> func);
    
    void RegisterSendJoin(Action<SendContractModel> func);
}