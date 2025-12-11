namespace SimpleChatApp.Domain.Entities;

public record ChatMessageEntity(Guid Id, Guid UserId, Guid ChannelId, string Message, DateTime createdAt)
    : BaseEntity(Id);