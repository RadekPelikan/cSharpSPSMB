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
                    message TEXT NOT NULL
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
                    INSERT INTO chatMessages (sender, message)
                    VALUES ($sender, $message)
                ";
            command.Parameters.AddWithValue("$sender", chatMessage.Sender);
            command.Parameters.AddWithValue("$message", chatMessage.Message);

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
                    SELECT sender, message
                    FROM chatMessages
                ";
            
            var messages = new List<ChatMessage>();
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    var message = new ChatMessage(
                        reader.GetString(0), 
                        reader.GetString(1));
                    messages.Add(message);
                }
            }
            return messages;
        }
    }
}

public record ChatMessage(string Sender, string Message)
{
    public override string ToString()
    {
        return $"{Sender}: {Message}";
    }
};