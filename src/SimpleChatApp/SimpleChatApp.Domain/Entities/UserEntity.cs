namespace SimpleChatApp.Domain.Entities;

public record UserEntity(Guid Id, string UserName, DateTime CreatedAt) : BaseEntity(Id);