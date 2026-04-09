using Microsoft.Extensions.Configuration;

namespace KeycloakVirgin.Common.AppSettings;

public enum DatabaseProvider
{
    Sqlite,
    PostgreSql
}

public class DatabaseConfig
{
    public DatabaseConfig(IConfiguration configuration)
    {
        if (configuration is null)
        {
            throw new ArgumentNullException(nameof(configuration));
        }

        configuration.GetSection("Database").Bind(this);
    }

    public DatabaseProvider Provider { get; set; } = DatabaseProvider.Sqlite;
    
    public string ConnectionString { get; set; } = string.Empty;
    
    // SQLite specific
    public string SqliteFileName { get; set; } = "virgin.db";
    
    // PostgreSQL specific
    public string PostgresConnectionString { get; set; } = string.Empty;
    public string Host { get; set; } = "localhost";
    public int Port { get; set; } = 5432;
    public string Database { get; set; } = "keycloak";
    public string Username { get; set; } = "keycloak";
    public string Password { get; set; } = "keycloak";

    public string GetConnectionString()
    {
        if (!string.IsNullOrEmpty(ConnectionString))
        {
            return ConnectionString;
        }

        return Provider switch
        {
            DatabaseProvider.Sqlite => $"Data Source={SqliteFileName}",
            DatabaseProvider.PostgreSql => !string.IsNullOrEmpty(PostgresConnectionString) 
                ? PostgresConnectionString 
                : $"Host={Host};Port={Port};Database={Database};Username={Username};Password={Password}",
            _ => throw new ArgumentException($"Unsupported database provider: {Provider}")
        };
    }
}