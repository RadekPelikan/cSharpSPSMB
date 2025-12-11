namespace SimpleChatApp.Contracts;

public interface IChatContracts
{
    void RegisterSendMessage(Action<SendContractModel> func);
    
    void RegisterSendJoin(Action<SendContractModel> func);
}

public interface IClientChatContracts
{
    void SendMessage(SendMessageModel model);
    
    void SendJoin(SendJoinModel model);
}

public record SendContractModel();
public record SendMessageModel(Guid UserId, string Content, string ChannelName) : SendContractModel;

public record SendJoinModel(Guid UserId, string ChannelName): SendContractModel;