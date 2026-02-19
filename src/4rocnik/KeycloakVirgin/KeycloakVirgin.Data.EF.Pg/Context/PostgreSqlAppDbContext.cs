using EFCoreVIrgin.Data.EF.Context;
using KeycloakVirgin.Common.AppSettings;
using Microsoft.EntityFrameworkCore;

namespace KeycloakVirgin.Data.EF.Pg.Context;

public class PostgreSqlAppDbContext : AppDbContext
{
    public PostgreSqlAppDbContext(DatabaseConfig databaseConfig)
        : base(databaseConfig)
    {
    }

    public PostgreSqlAppDbContext(DbContextOptions<PostgreSqlAppDbContext> options, DatabaseConfig databaseConfig)
        : base(options, databaseConfig)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            var connectionString = _databaseConfig.GetConnectionString();
            var migrationsAssembly = typeof(PostgreSqlAppDbContext).Assembly.GetName().Name;
            
            optionsBuilder.UseNpgsql(connectionString,
                b => b.MigrationsHistoryTable("__EFMigrationsHistory_PostgreSql")
                      .MigrationsAssembly(migrationsAssembly));
        }
    }
}
