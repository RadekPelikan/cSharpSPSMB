using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace MaturitaFree.Data.EF.Context;

/// <summary>
/// Design-time factory used by <c>dotnet ef</c> to create <see cref="AppDbContext"/>
/// without needing a running application host.
/// </summary>
/// <remarks>
/// Run migrations from the solution root:
/// <code>
/// dotnet ef migrations add &lt;MigrationName&gt; --project MaturitaFree.Data.EF --startup-project MaturitaFree.App
/// dotnet ef database update              --project MaturitaFree.Data.EF --startup-project MaturitaFree.App
/// </code>
/// </remarks>
public sealed class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
{
    public AppDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();

        // Design-time database — a local file next to the project
        var dbPath = Path.Combine(
            AppContext.BaseDirectory,
            "maturita_design.db");

        optionsBuilder.UseSqlite($"Data Source={dbPath}");

        return new AppDbContext(optionsBuilder.Options);
    }
}
