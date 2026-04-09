using EFCoreVIrgin.Data.EF.Entity;
using EFCoreVIrgin.Data.EF.Entity.Base;
using Microsoft.EntityFrameworkCore;

namespace EFCoreVIrgin.Data.EF.Context;

public interface IAppDbContext : IDisposable
{
    Guid? CurrentUser { get; set; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    int SaveChanges();
    DbSet<TEntity> Set<TEntity>() where TEntity : class;
}