﻿namespace Enemy;
using MySqlConnector;
public class DBDriver
{
    public string ServerDomain = "vydb1.spsmb.cz";
    public string Username = "jan.fuka";
    public string Password = "";
    public string Database = "student_jan.fuka_rpg";

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
    
    public Guid ID { get; set; } = Guid.NewGuid();
    public string Name { get; set; }
    public int Health { get; set; }
    public int  Damage { get; set; }
    public int Defense { get; set; }
    public float CriticalChance { get; set; }
    public float CriticalScaler { get; set; }




    public void InsertEnemy(Enemy enemy)
    {
        MySqlConnection connection = GetConnection();
        try
        {
            connection.Open();
            string query =
                "INSERT INTO Enemy (ID, name,health , damage, defense, criticalChance, CriticalScaler) VALUES (@ID,@name,@health, @damage, @defense, @criticalChance, @CriticalScaler);";
            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@ID",enemy.ID.ToString() );
            command.Parameters.AddWithValue("@name", enemy.Name);
            command.Parameters.AddWithValue("@health", enemy.Health);
            command.Parameters.AddWithValue("@damage", enemy.Damage);
            command.Parameters.AddWithValue("@defense", enemy.Defense);
            command.Parameters.AddWithValue("@criticalChance", enemy.CriticalChance);
            command.Parameters.AddWithValue("@CriticalScaler", enemy.CriticalScaler);
            command.ExecuteNonQuery();
        }
        catch (MySqlException ex)
        {
            ThrownException = ex;
        }

    }


    public   List<Enemy> GetEnemies()
        {
            List<Enemy> users = new List<Enemy>();
            MySqlConnection connection = GetConnection();
            try
            {
                connection.Open();
                string query = "SELECT * FROM Enemy";
                MySqlCommand command = new MySqlCommand(query, connection);
                // execute reader
                var reader = command.ExecuteReader();
                // while reader.next
                while (reader.Read())
                {
                    // create new user
                    var user = new Enemy();
                    user.ID = reader.GetGuid("id");
                    user.Name = reader.GetString("name");
                    user.Health = reader.GetInt32("health");
                    user.Damage = reader.GetInt32("damage");
                    user.Defense = reader.GetInt32("armor");
                    user.CriticalChance = reader.GetFloat("criticalChance");
                    user.CriticalScaler = reader.GetFloat("criticalScaler");
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
        
    }
