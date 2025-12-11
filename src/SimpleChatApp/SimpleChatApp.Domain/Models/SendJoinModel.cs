namespace SimpleChatApp.Domain.Models;

public record SendJoinModel(Guid UserId, string ChannelName): SendContractModel;