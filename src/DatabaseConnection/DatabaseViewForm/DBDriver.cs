using MySqlConnector;

namespace DatabaseViewForm;

public class DBDriver
{
    public string ServerDomain = "vydb1.spsmb.cz";
    public string Username = "tomas.urban";
    public string Password = "";
    public string Database = "student_tomas.urban_duolingo";
    public string connectionString => 
        $"Server={ServerDomain};Database={Database};User={Username};Password={Password};Port=3306;";

    public DBDriver(string password)
    {
        Password = password;
    }

    public MySqlConnection GetConnection()
    {
        return new MySqlConnection(connectionString);
    }

    public void AddUser(string username)
    {
        MySqlConnection connection = GetConnection();
        connection.Open();
        using (var command = new MySqlCommand("INSERT INTO users (name) VALUES (@username);", connection))
        {
            command.Parameters.AddWithValue("@username", username);
            command.ExecuteNonQuery();
        }
    }

    public void UpdateName(string name, int id)
    {
        MySqlConnection connection = GetConnection();
        connection.Open();
        using (var command = new MySqlCommand("UPDATE users SET name = @name WHERE ID = @id", connection))
        {
            command.Parameters.AddWithValue("@name", name);
            command.Parameters.AddWithValue("@id", id);
            command.ExecuteNonQuery();
        }
    }

    public void RemoveUser(int id)
    {
        MySqlConnection connection = GetConnection();
        connection.Open();
        using (var command = new MySqlCommand("DELETE FROM users WHERE ID = @id;", connection))
        {
            command.Parameters.AddWithValue("@id", id);
            command.ExecuteNonQuery();
        }
    }
    
    public List<User> GetUsers()
    {
        List<User> users = new List<User>();
        MySqlConnection connection = GetConnection();
        connection.Open();
        string query = "SELECT * FROM users";
        MySqlCommand command = new MySqlCommand(query, connection);
        // execute reader
        var reader = command.ExecuteReader();
        // while reader.next
        while (reader.Read())
        {
            // create new user
            var user = new User();
            user.Id = reader.GetInt32(0);
            user.Username = reader.GetString(1);
            user.CreatedAt = reader.GetDateTime(2);
            user.ModifiedAt = reader.GetDateTime(3);
            // add user to the list
            users.Add(user);
        }

        // return list
        return users;
    }
}
