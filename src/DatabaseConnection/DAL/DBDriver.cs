using DatabaseConnection;
using MySqlConnector;

namespace DBDriver;

public class DBDriver
{
    public string ServerDomain = "vydb1.spsmb.cz";
    public string Username = "radek.pelikan";
    public string Password = "heslo123";
    public string Database = "student_radek.pelikan_duolingo";

    public DBDriver()
    {
    }

    string connectionString =>
        $"Server={ServerDomain};Database={Database};User={Username};Password={Password};SslMode=None;";

    public DBDriver(string serverDomain, string username, string password, string database)
    {
        this.ServerDomain = serverDomain;
        this.Username = username;
        this.Password = password;
        this.Database = database;
    }

    public MySqlConnection GetConnection()
    {
        try
        {
            var connection = new MySqlConnection(connectionString);
            connection.Open();
            return connection;
        }
        catch (MySqlException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
            return null;
        }
    }

    public int ExecuteNonQuery(string query)
    {
        using var connection = GetConnection();
        if (connection == null) throw new InvalidOperationException("Failed to establish a database connection.");

        using var command = new MySqlCommand(query, connection);
        return command.ExecuteNonQuery();
    }

    public MySqlDataReader ExecuteReader(string query)
    {
        var connection = GetConnection();
        if (connection == null) throw new InvalidOperationException("Failed to establish a database connection.");

        var command = new MySqlCommand(query, connection);
        return command.ExecuteReader();
    }
}