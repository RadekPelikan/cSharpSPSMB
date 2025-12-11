using SimpleChatApp.Contracts;

namespace SimpleChatApp.BE.Facades;

public class ChatFacade
{
    public IChatContracts _contracts;
    public IChatMessageRepository _repository;
    
    public ChatFacade()
    {
        _contracts.RegisterSendJoin(HandleSendMessage);
    }

    private void HandleSendMessage(SendContractModel model)
    {
        if (model is not SendMessageModel)
        {
            throw new InvalidDataException("Non valid model for sending Messages");
        }

        var sendMessageModel = model as SendMessageModel;
        // _repository.Insert(new ChatMessage());
    }
}