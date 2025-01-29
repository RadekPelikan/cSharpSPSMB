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

    public DBDriver(string password)
    {
        Password = password;
    }

    public MySqlConnection GetConnection()
    {
        return new MySqlConnection();
    }
}