using DatabaseConnection;
using MySqlConnector;

var serverDomain = "vydb1.spsmb.cz";
var username = "radek.pelikan";
var password = Helpers.ReadSecret("Enter password: ");
var database = "student_radek.pelikan_duolingo";

string connectionString = $"Server={serverDomain};Database={database};User={username};Password={password};Port=3306;";

// ukol2
void PrintUsers()
{
    
}

void InsertUser(string username)
{
    
}

// ukol3
void PrintUserWithName(string username)
{
    
}
    
// ukol 4
/*
 * Aby metody vraceli objekt User misto printovani
 * InsertUser zustane stejny
List<User> GetUsers()
User GetUserWithName(string username)
 */
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