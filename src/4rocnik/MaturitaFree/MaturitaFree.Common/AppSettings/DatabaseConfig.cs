using Microsoft.Extensions.Configuration;

namespace MaturitaFree.Common.AppSettings;

public record DatabaseConfig
{
    public DatabaseConfig() { }

    public DatabaseConfig(IConfiguration configuration) : this()
    {
        if (configuration is null)
        {
            throw new ArgumentNullException(nameof(configuration));
        }

        configuration.GetSection("Database").Bind(this);
    }

    public DatabaseProvider Provider { get; set; } = DatabaseProvider.Sqlite;
    
    public string ConnectionString { get; set; } = "";
    
    // SQLite specific
    public string SqliteFileName { get; set; } = "maturita.free.db";

    public string GetConnectionString()
    {
        if (!string.IsNullOrEmpty(ConnectionString))
        {
            return ConnectionString;
        }

        return Provider switch
        {
            DatabaseProvider.Sqlite => $"Data Source={SqliteFileName}",
            // DatabaseProvider.PostgreSql => !string.IsNullOrEmpty(PostgresConnectionString) 
            //     ? PostgresConnectionString 
            //     : $"Host={Host};Port={Port};Database={Database};Username={Username};Password={Password}",
            _ => throw new ArgumentException($"Unsupported database provider: {Provider}")
        };
    }
}