using DatabaseConnection;
using MySqlConnector;

var serverDomain = "vydb1.spsmb.cz";
var username = "radek.pelikan";
var password = Helpers.ReadSecret("Enter password: ");
var database = "student_radek.pelikan_duolingo";

string connectionString = $"Server={serverDomain};Database={database};User={username};Password={password};Port=3306;";

void PrintUsers()
{
    
}

void InsertUser(string username)
{
    
}

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