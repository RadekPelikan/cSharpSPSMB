using MySqlConnector;

namespace DatabaseViewForm;

public class DBDriver
{
    public string ServerDomain = "vydb1.spsmb.cz";
    public string Username = "radek.pelikan";
    public string Password = "";
    public string Database = "student_radek.pelikan_duolingo";

    public string connectionString =>
        $"Server={ServerDomain};Database={Database};User={Username};Password={Password};Port=3306;";

    public Exception? ThrownException;

    public DBDriver(string password)
    {
        Password = password;
    }

    public MySqlConnection GetConnection()
    {
        return new MySqlConnection(connectionString);
    }

    public List<User> GetUsers()
    {
        List<User> users = new List<User>();
        MySqlConnection connection = GetConnection();
        try
        {
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
        }
        catch (MySqlException ex)
        {
            ThrownException = ex;
        }

        // return list
        return users;
    }

    public void InsertUser(User user)
    {
        MySqlConnection connection = GetConnection();
        try
        {
            connection.Open();
            string query = "INSERT INTO users (username) VALUES (@username);";
            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@username", user.Username);
            command.ExecuteNonQuery();
        }
        catch (MySqlException ex)
        {
            ThrownException = ex;
        }
    }

    public void DeteteUserWithId(int id)
    {
        MySqlConnection connection = GetConnection();
        try
        {
            connection.Open();
            string query = "DELETE FROM users WHERE id = @id;";
            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@id", id);
            int effectedRows = command.ExecuteNonQuery();
            if (effectedRows == 0)
            {
                ThrownException = new InvalidUserException(id);
            }
        }
        catch (MySqlException ex)
        {
            ThrownException = ex;
        }
    }
}