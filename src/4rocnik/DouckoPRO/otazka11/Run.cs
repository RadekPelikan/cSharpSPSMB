using MySqlConnector;

namespace otazka11;

public class Run
{
    static string ServerDomain = "localhost";
    static string Username = "root";
    static string Password = "rootpassword";
    static string Database = "otazka11.rp";

    static string connectionString =
        $"Server={ServerDomain};Database={Database};User={Username};Password={Password};SslMode=None;";

    public static void Task01()
    {
        Console.WriteLine(connectionString);
        AddToCart(1, new Item("mouka", 1));
        PrintUsers();

        void PrintUsers()
        {
            using var connection = new MySqlConnection(connectionString);
            connection.Open();

            var sql = @"
SELECT
u.Name AS UserName,
u.Id AS UserId,
i.Name AS ItemName,
i.Count
FROM User u
JOIN Item i 
ON i.UserId = u.Id;
";
            var command = new MySqlCommand(sql, connection);
            var reader = command.ExecuteReader();

            var users = new Dictionary<int, User>();
            while (reader.Read())
            {
                var user = new User(
                    reader.GetInt32("UserId"),
                    reader.GetString("UserName"),
                    new List<Item>()
                );
                var item = new Item(
                    reader.GetString("ItemName"),
                    reader.GetInt32("Count")
                );

                if (users.ContainsKey(user.Id) is false)
                {
                    users[user.Id] = user;
                }

                users[user.Id].items.Add(item);
            }

            foreach (var keyValuePair in users)
            {
                var user = keyValuePair.Value;
                var items = user.items.Select(e => $"{e.Name}: {e.Count}");
                Console.WriteLine($"{user.Name} - {string.Join(", ", items)}");
            }

            connection.Close();
        }
    }


    private static void AddToCart(int userId, Item item)
    {
        using var connection = new MySqlConnection(connectionString);
        connection.Open();

        var command = new MySqlCommand(@"
INSERT INTO `Item` (`Name`, `Count`, `UserId`) VALUES (@Name, @Count, @UserId);
", connection);

        command.Parameters.AddWithValue("@Name", item.Name);
        command.Parameters.AddWithValue("@Count", item.Count);
        command.Parameters.AddWithValue("@UserId", userId);

        var updatedRows = command.ExecuteNonQuery();
        Console.WriteLine($"Updated rows: {updatedRows}");
    }
}