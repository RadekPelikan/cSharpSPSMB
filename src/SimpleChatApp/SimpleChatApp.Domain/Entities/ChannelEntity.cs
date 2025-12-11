namespace SimpleChatApp.Domain.Entities;

public record ChannelEntity(Guid Id, string ChannelName, int Capacity, DateTime CreatedAt) : BaseEntity(Id);