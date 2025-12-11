using SimpleChatApp.Contracts.Abstract;
using SimpleChatApp.Data.Abstract.Repositories;
using SimpleChatApp.Domain.Entities;
using SimpleChatApp.Domain.Models;

namespace SimpleChatApp.BE.Facades;

public class ChatFacade(
    IChatContracts _contracts,
    IChatMessageRepository _messageRepository,
    IUserRepository _userRepository,
    IChannelRepository _channelRepository)
{

    public ChatFacade()
    {
        _contracts.RegisterSendMessage(HandleSendMessage);
        _contracts.RegisterSendJoin(HandleSendJoin);
    };

    private void HandleSendJoin(SendContractModel model)
    {
        if (model is not SendJoinModel)
        {
            throw new InvalidDataException("Non valid model for sending Messages");
        }

        var sendJoinModel = model as SendJoinModel;
    }

    private void HandleSendMessage(SendContractModel model)
    {
        if (model is not SendMessageModel)
        {
            throw new InvalidDataException("Non valid model for sending Messages");
        }

        var sendMessageModel = model as SendMessageModel;

        var channelEntity = _channelRepository.GetByName(sendMessageModel.ChannelName);
        var channelId = channelEntity.Id;

        var chatEntity = new ChatMessageEntity(
            Guid.NewGuid(),
            sendMessageModel.UserId,
            channelId,
            sendMessageModel.Content,
            DateTime.UtcNow
        );
        _messageRepository.Insert(chatEntity);
    }
}