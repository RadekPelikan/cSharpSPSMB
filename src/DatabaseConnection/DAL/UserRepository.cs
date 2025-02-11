using DBDriver.Entites;
using MySqlConnector;

namespace DBDriver;

public class UserRepository
{
    private DBDriver _dbDriver;

    public UserRepository(DBDriver dbDriver)
    {
        _dbDriver = dbDriver;
    }

    public List<User> GetUsers()
    {
        List<User> users = new List<User>();

        using (var reader = _dbDriver.ExecuteReader("SELECT * FROM users"))
        {
            while (reader.Read())
            {
                users.Add(new User
                {
                    Id = reader.GetInt32(0),
                    Username = reader.GetString(1),
                    CreatedAt = reader.GetDateTime(2),
                    ModifiedAt = reader.GetDateTime(3),
                });
            }
        }

        return users;
    }

    public void InsertUser(string username)
    {
        using (var connection = _dbDriver.GetConnection())
        {
            using (var command = new MySqlCommand("INSERT INTO users (username) VALUES (@username);", connection))
            {
                command.Parameters.AddWithValue("@username", username);
                command.ExecuteNonQuery();
            }
        }
    }
}