using EFCoreVIrgin.Data.EF.Context;
using KeycloakVirgin.Common.AppSettings;
using Microsoft.EntityFrameworkCore;

namespace KeycloakVirgin.Data.EF.Sqlite.Context;

public class SqliteAppDbContext : AppDbContext
{
    public SqliteAppDbContext(DatabaseConfig databaseConfig)
        : base(databaseConfig)
    {
    }

    public SqliteAppDbContext(DbContextOptions<SqliteAppDbContext> options, DatabaseConfig databaseConfig)
        : base(options, databaseConfig)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            var connectionString = _databaseConfig.GetConnectionString();
            var migrationsAssembly = typeof(SqliteAppDbContext).Assembly.GetName().Name;
            
            optionsBuilder.UseSqlite(connectionString,
                b => b.MigrationsHistoryTable("__EFMigrationsHistory_Sqlite")
                      .MigrationsAssembly(migrationsAssembly));
        }
    }
}
