using Microsoft.Data.Sqlite;

namespace SimpleChatApp.BE;

public class ChatMessageRepository
{
    private SqliteConnection GetConnection() => new SqliteConnection("Data Source=chat.db");

    public ChatMessageRepository()
    {
        using (var connection = GetConnection())
        {
            connection.Open();
            var command = connection.CreateCommand();
            command.CommandText =
                @"
                CREATE TABLE IF NOT EXISTS chatMessages (
                    id INTEGER PRIMARY KEY AUTOINCREMENT,
                    sender TEXT NOT NULL,
                    message TEXT NOT NULL,
                    created_at DATETIME NOT NULL
                )
            ";
            command.ExecuteNonQuery();
        }
    }

    public void Insert(ChatMessage chatMessage)
    {
        using (var connection = GetConnection())
        {
            connection.Open();
            var command = connection.CreateCommand();
            command.CommandText =
                @"
                    INSERT INTO chatMessages (sender, message, created_at)
                    VALUES ($sender, $message, $created_at)
                ";
            command.Parameters.AddWithValue("$sender", chatMessage.Sender);
            command.Parameters.AddWithValue("$message", chatMessage.Message);
            command.Parameters.AddWithValue("$created_at", DateTime.UtcNow);

            command.ExecuteNonQuery();
        }
    }

    public List<ChatMessage> GetAll()
    {
        using (var connection = GetConnection())
        {
            connection.Open();
            var command = connection.CreateCommand();
            command.CommandText =
                @"
                    SELECT sender, message, created_at
                    FROM chatMessages
                ";
            
            var messages = new List<ChatMessage>();
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    var message = new ChatMessage(
                        reader.GetString(0), 
                        reader.GetString(1),
                        reader.GetDateTime(2));
                    messages.Add(message);
                }
            }
            return messages;
        }
    }
}

public record ChatMessage(string Sender, string Message, DateTime createdAt)
{
    public override string ToString()
    {
        return $"{Sender} [{createdAt.ToLocalTime().ToShortTimeString()}]: {Message}";
    }
};