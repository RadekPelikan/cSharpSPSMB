using MySqlConnector;

namespace DatabaseViewForm;

public class DBDriver
{
    private static DBDriver? instance;
    public string ServerDomain = "vydb1.spsmb.cz";
    public string Username = "tomas.urban";
    public string Password = "";
    public string Database = "student_tomas.urban_duolingo";
    public string connectionString => 
        $"Server={ServerDomain};Database={Database};User={Username};Password={Password};Port=3306;";

    public DBDriver(string password)
    {
        Password = password;
        DBDriver.instance = this;
    }

    public static DBDriver GetInstanceOrNull()
    {
        return instance;
    }

    public MySqlConnection GetConnection()
    {
        return new MySqlConnection(connectionString);
    }

    public void AddUser(string username)
    {
        MySqlConnection connection = GetConnection();
        connection.Open();
        using (var command = new MySqlCommand("INSERT INTO users (username) VALUES (@username);", connection))
        {
            command.Parameters.AddWithValue("@username", username);
            command.ExecuteNonQuery();
        }
    }
    
    public void AddRegistration(int id1, int id2)
    {
        MySqlConnection connection = GetConnection();
        connection.Open();
        using (var command = new MySqlCommand("INSERT INTO user_language_registrations (user_id, language_id) VALUES (@id1, @id2);", connection))
        {
            command.Parameters.AddWithValue("@id1", id1);
            command.Parameters.AddWithValue("@id2", id2);
            command.ExecuteNonQuery();
        }
    }
    
    public void AddLanguage(string name)
    {
        MySqlConnection connection = GetConnection();
        connection.Open();
        using (var command = new MySqlCommand("INSERT INTO languages (name) VALUES (@name);", connection))
        {
            command.Parameters.AddWithValue("@name", name);
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
    
    public void RemoveLanguage(int id)
    {
        MySqlConnection connection = GetConnection();
        connection.Open();
        using (var command = new MySqlCommand("DELETE FROM languages WHERE ID = @id;", connection))
        {
            command.Parameters.AddWithValue("@id", id);
            command.ExecuteNonQuery();
        }
    }
    
    public void RemoveRegistration(int id)
    {
        MySqlConnection connection = GetConnection();
        connection.Open();
        using (var command = new MySqlCommand("DELETE FROM user_language_registrations WHERE ID = @id;", connection))
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
    
    public List<Registration> GetRegistrations()
    {
        List<Registration> registrations = new List<Registration>();
        MySqlConnection connection = GetConnection();
        connection.Open();
        string query = "SELECT * FROM user_language_registrations";
        MySqlCommand command = new MySqlCommand(query, connection);
        // execute reader
        var reader = command.ExecuteReader();
        // while reader.next
        while (reader.Read())
        {
            // create new user
            var registration = new Registration();
            registration.Id = reader.GetInt32(0);
            registration.UserId = reader.GetInt32(1);
            registration.LanguageId= reader.GetInt32(2);
            // add user to the list
            registrations.Add(registration);
        }

        // return list
        return registrations;
    }
    
    public List<Language> GetLanguages()
    {
        List<Language> languages = new List<Language>();
        MySqlConnection connection = GetConnection();
        connection.Open();
        string query = "SELECT * FROM languages";
        MySqlCommand command = new MySqlCommand(query, connection);
        // execute reader
        var reader = command.ExecuteReader();
        // while reader.next
        while (reader.Read())
        {
            // create new user
            var language = new Language();
            language.Id = reader.GetInt32(0);
            language.Name = reader.GetString(1);
            language.CreatedAt = reader.GetDateTime(2);
            language.ModifiedAt = reader.GetDateTime(3);
            // add user to the list
            languages.Add(language);
        }

        // return list
        return languages;
    }
}
