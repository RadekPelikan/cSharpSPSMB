namespace SimpleChatApp.Domain.Models;

public record SendMessageModel(Guid UserId, string Content, string ChannelName) : SendContractModel;