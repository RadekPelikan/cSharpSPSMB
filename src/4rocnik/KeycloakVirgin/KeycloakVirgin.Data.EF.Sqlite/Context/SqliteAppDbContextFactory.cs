using KeycloakVirgin.Common.AppSettings;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace KeycloakVirgin.Data.EF.Sqlite.Context;

/// <summary>
/// Design-time factory for creating SqliteAppDbContext instances for migrations.
/// This factory reads configuration from appsettings.json in the main project.
/// </summary>
public class SqliteAppDbContextFactory : IDesignTimeDbContextFactory<SqliteAppDbContext>
{
    public SqliteAppDbContext CreateDbContext(string[] args)
    {
        // Build configuration from appsettings.json in the main project
        var basePath = Path.Combine(Directory.GetCurrentDirectory(), "../KeycloakVirgin");
        var configuration = new ConfigurationBuilder()
            .AddJsonFile(Path.Combine(basePath, "appsettings.json"), optional: false)
            .AddJsonFile(Path.Combine(basePath, "appsettings.Development.json"), optional: true)
            .Build();

        // Read database configuration from appsettings
        var databaseConfig = new DatabaseConfig(configuration);
        
        var optionsBuilder = new DbContextOptionsBuilder<SqliteAppDbContext>();
        var connectionString = databaseConfig.GetConnectionString();
        
        optionsBuilder.UseSqlite(connectionString,
            b => b.MigrationsHistoryTable("__EFMigrationsHistory_Sqlite")
                  .MigrationsAssembly(typeof(SqliteAppDbContext).Assembly.GetName().Name));

        return new SqliteAppDbContext(optionsBuilder.Options, databaseConfig);
    }
}
