using MySqlConnector;
using RPGApp.DAL;

namespace DatabaseViewForm;

public class DBDriver
{
    public string ServerDomain = "vydb1.spsmb.cz";
    public string Username = "radek.pelikan";
    public string Password = "";
    public string Database => $"student_{Username}_RPGApp";

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

    public List<Enemy> GetAllEnemies()
    {
        List<Enemy> enemies = new List<Enemy>();
        MySqlConnection connection = GetConnection();
        try
        {
            connection.Open();
            string query = "SELECT * FROM enemy";
            MySqlCommand command = new MySqlCommand(query, connection);
            // execute reader
            var reader = command.ExecuteReader();
            // while reader.next
            while (reader.Read())
            {
                // create new Enemy
                var enemy = new Enemy
                {
                    Id = reader.GetGuid("id"),
                    Name = reader.GetString("name"),
                    Health = reader.GetInt32("health"),
                    Damage = reader.GetInt32("damage"),
                    Armor = reader.GetInt32("armor"),
                    CriticalChance = reader.GetFloat("criticalChance"),
                    CriticalScaler = reader.GetFloat("criticalScaler"),
                };
                // add Enemy to the list
                enemies.Add(enemy);
            }
        }
        catch (MySqlException ex)
        {
            ThrownException = ex;
            Console.Error.WriteLine(ex.Message);
        }

        // return list
        return enemies;
    }

    public void InsertEnemy(Enemy Enemy)
    {
        MySqlConnection connection = GetConnection();
        try
        {
            connection.Open();
            string query = @"
                INSERT INTO enemy VALUES 
                (@id, @name, @health, @damage, @armor, @criticalChance, @criticalScaler);";
            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@id", Enemy.Id);
            command.Parameters.AddWithValue("@name", Enemy.Name);
            command.Parameters.AddWithValue("@health", Enemy.Health);
            command.Parameters.AddWithValue("@damage", Enemy.Damage);
            command.Parameters.AddWithValue("@armor", Enemy.Armor);
            command.Parameters.AddWithValue("@criticalChance", Enemy.CriticalChance);
            command.Parameters.AddWithValue("@criticalScaler", Enemy.CriticalScaler);
            command.ExecuteNonQuery();
        }
        catch (MySqlException ex)
        {
            ThrownException = ex;
            Console.Error.WriteLine(ex.Message);
        }
    }
}