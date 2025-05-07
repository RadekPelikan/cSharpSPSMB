using MySqlConnector;

namespace SpsmbBlog.DB;

public class DbDriver
{
    public string ServerDomain = "vydb1.spsmb.cz";
    public string Username = "radek.pelikan";
    public string Password;
    public string Database => $"student_{Username}_SpsmbBlogDB";
    
    public string connectionString =>
        $"Server={ServerDomain};Database={Database};User={Username};Password={Password};Port=3306;";

    public Exception? ThrownException;

    public DbDriver(string password)
    {
        Password = password;
    }

    public MySqlConnection GetConnection()
    {
        return new MySqlConnection(connectionString);
    }

    public bool CanConnect()
    {
        try
        {
            GetConnection().Open();
            return true;
        }
        catch
        {
            return false;
        }
    }
    
}