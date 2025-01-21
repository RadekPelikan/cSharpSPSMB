using DatabaseConnection;
using MySql.Data.MySqlClient;

var serverDomain = "localhost";
var username = "root";
var password = "";
var database = "duolingo";

string connectionString = $"Server={serverDomain};Database={database};User={username};Password={password};Port=3306;";

using (MySqlConnection connection = new MySqlConnection(connectionString))
{
    try
    {
        connection.Open();
        using (var command = new MySqlCommand("SELECT * FROM users;", connection))
        {
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Console.WriteLine($"id: {reader.GetInt32(0)}");
                    Console.WriteLine($"username: {reader.GetString(1)}");
                }
            }
        }
    }
    catch (MySqlException ex)
    {
        Console.WriteLine($"Error: {ex.Message}");
    }
}