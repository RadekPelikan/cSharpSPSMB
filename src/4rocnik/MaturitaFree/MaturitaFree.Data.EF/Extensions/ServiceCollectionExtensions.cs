using MaturitaFree.Common.Repositories;
using MaturitaFree.Data.EF.Context;
using MaturitaFree.Data.EF.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace MaturitaFree.Data.EF.Extensions;

public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Registers the EF Core AppDbContext with SQLite and the generic repository.
    /// </summary>
    /// <param name="services">The service collection.</param>
    /// <param name="databasePath">
    /// Full path to the SQLite database file, e.g. <c>AppData\maturita.db</c>.
    /// Defaults to <c>maturita.db</c> next to the executable.
    /// </param>
    public static IServiceCollection AddDataLayer(
        this IServiceCollection services,
        string? databasePath = null)
    {
        databasePath ??= Path.Combine(
            AppContext.BaseDirectory,
            "maturita.db");

        services.AddDbContext<AppDbContext>(options =>
            options.UseSqlite($"Data Source={databasePath}"));

        // Expose AppDbContext through IAppDbContext so consumers depend on the abstraction
        services.AddScoped<IAppDbContext>(sp => sp.GetRequiredService<AppDbContext>());

        // Concrete repositories — each is reachable via its specific interface
        // or via IRepository<T> for generic CRUD usage
        services.AddScoped<IBookRepository, BookRepository>();
        services.AddScoped<IRepository<Common.Entities.BookEntity>>(sp => sp.GetRequiredService<IBookRepository>());

        services.AddScoped<IPersonRepository, PersonRepository>();
        services.AddScoped<IRepository<Common.Entities.PersonEntity>>(sp => sp.GetRequiredService<IPersonRepository>());

        services.AddScoped<IPersonWorkingOnBookRepository, PersonWorkingOnBookRepository>();
        services.AddScoped<IRepository<Common.Entities.PersonWorkingOnBook>>(sp => sp.GetRequiredService<IPersonWorkingOnBookRepository>());

        services.AddScoped<IBookChapterRepository, BookChapterRepository>();
        services.AddScoped<IRepository<Common.Entities.BookChapterEntity>>(sp => sp.GetRequiredService<IBookChapterRepository>());

        services.AddScoped<IBookParagraphRepository, BookParagraphRepository>();
        services.AddScoped<IRepository<Common.Entities.BookParagraphEntity>>(sp => sp.GetRequiredService<IBookParagraphRepository>());

        return services;
    }

    /// <summary>
    /// Ensures the SQLite database is created and all pending migrations are applied.
    /// Call this once at application startup after building the service provider.
    /// </summary>
    public static IServiceProvider MigrateDatabase(this IServiceProvider provider)
    {
        using var scope = provider.CreateScope();
        var db = scope.ServiceProvider.GetRequiredService<IAppDbContext>();
        db.Database.Migrate();
        return provider;
    }
}
