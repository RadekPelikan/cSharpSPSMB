using KeycloakVirgin.Common.AppSettings;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace KeycloakVirgin.Data.EF.Pg.Context;

/// <summary>
/// Design-time factory for creating PostgreSqlAppDbContext instances for migrations.
/// This factory reads configuration from appsettings.json in the main project.
/// </summary>
public class PostgreSqlAppDbContextFactory : IDesignTimeDbContextFactory<PostgreSqlAppDbContext>
{
    public PostgreSqlAppDbContext CreateDbContext(string[] args)
    {
        // Build configuration from appsettings.json in the main project
        var basePath = Path.Combine(Directory.GetCurrentDirectory(), "../KeycloakVirgin");
        var configuration = new ConfigurationBuilder()
            .AddJsonFile(Path.Combine(basePath, "appsettings.json"), optional: false)
            .AddJsonFile(Path.Combine(basePath, "appsettings.Development.json"), optional: true)
            .Build();

        // Read database configuration from appsettings
        var databaseConfig = new DatabaseConfig(configuration);
        
        var optionsBuilder = new DbContextOptionsBuilder<PostgreSqlAppDbContext>();
        var connectionString = databaseConfig.GetConnectionString();
        
        optionsBuilder.UseNpgsql(connectionString,
            b => b.MigrationsHistoryTable("__EFMigrationsHistory_PostgreSql")
                  .MigrationsAssembly(typeof(PostgreSqlAppDbContext).Assembly.GetName().Name));

        return new PostgreSqlAppDbContext(optionsBuilder.Options, databaseConfig);
    }
}
