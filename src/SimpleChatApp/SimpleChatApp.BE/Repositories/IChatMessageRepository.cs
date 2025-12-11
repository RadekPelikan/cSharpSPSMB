namespace SimpleChatApp.BE;

public interface IChatMessageRepository
{
    ChatMessage Get(Guid id);
    List<ChatMessage> GetAll();
    ChatMessage Insert(ChatMessage message);
}