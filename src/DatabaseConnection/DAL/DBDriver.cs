using MySqlConnector;

namespace DBDriver;

public class DBDriver
{
    private string serverDomain = "localhost";
    private string username = "root";
    private string password = "";
    private string database = "duolingo";

    public DBDriver()
    {
    }

    string connectionString =>
        $"Server={serverDomain};Database={database};User={username};Password={password};SslMode=None;";

    public DBDriver(string serverDomain, string username, string password, string database)
    {
        this.serverDomain = serverDomain;
        this.username = username;
        this.password = password;
        this.database = database;
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