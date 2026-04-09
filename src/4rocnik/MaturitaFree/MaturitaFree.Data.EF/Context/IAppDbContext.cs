using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace MaturitaFree.Data.EF.Context;

public interface IAppDbContext
{
    /// <summary>Exposes the database façade for migrations, connections, etc.</summary>
    DatabaseFacade Database { get; }

    /// <summary>Exposes the change tracker for audit hooks and state inspection.</summary>
    ChangeTracker ChangeTracker { get; }

    /// <summary>Returns a <see cref="DbSet{TEntity}"/> for the given entity type.</summary>
    DbSet<T> Set<T>() where T : class;

    int SaveChanges();
    int SaveChanges(bool acceptAllChangesOnSuccess);

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default);
}
