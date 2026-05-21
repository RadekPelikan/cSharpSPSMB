

/**
 * Vytvořte databázi otazka11.rp
 *
 * Vytvořte tabulku User, která má sloupce:
 * Id, Name, Age, CreatedAt, UpdatedAt
 *
 * Vytvořte tabulku Item, která obsahuje:
 * Id, Name, Count, UserId, CreatedAt, UpdatedAt
 *
 * Vytořte metodu pro vypisování všech uživatelů s jejich košíkem
 * void PrintUsers()
 * Fanda(1): [rohlík: 5, Jablko: 3, mouka: 1]
 * Lukáš(2): [cukr: 3, bramobry: 50, ocet: 4]
 *
 * Vytvořte metodu na přidání položky do košiku uživateli
 * void AddToCart(int userId, Item item)
 */


using MySqlConnector;

string ServerDomain = "localhost";
string Username = "root";
string Password = "rootpassword";
string Database = "otazka11.rp";

string connectionString = $"Server={ServerDomain};Database={Database};User={Username};Password={Password};SslMode=None;";

AddToCart(1, new Item("mouka", 1));
PrintUsers();

void PrintUsers()
{
    using var connection = new MySqlConnection(connectionString);
    connection.Open();

    var command = new MySqlCommand(@"
SELECT
u.Name AS UserName,
u.Id AS UserId,
i.Name AS ItemName,
i.Count
FROM User u
JOIN Item i 
ON i.UserId = u.Id;
", connection);
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

void AddToCart(int userId, Item item)
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


record User(int Id, string Name, List<Item> items);
record Item(string Name, int Count);