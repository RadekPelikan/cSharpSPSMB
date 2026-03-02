namespace MaturitaFree.Common.AppSettings;

public enum DatabaseProvider
{
    Sqlite,
    PostgreSql
}

public record DatabaseConfig
{
    public DatabaseProvider Provider { get; set; } = DatabaseProvider.Sqlite;
    
    public string ConnectionString { get; set; } = string.Empty;
    
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