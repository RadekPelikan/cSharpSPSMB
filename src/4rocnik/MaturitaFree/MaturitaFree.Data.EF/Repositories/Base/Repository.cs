using MaturitaFree.Common.Entities;
using MaturitaFree.Common.Repositories;
using MaturitaFree.Data.EF.Context;
using Microsoft.EntityFrameworkCore;

namespace MaturitaFree.Data.EF.Repositories;

public abstract class Repository<T> : IRepository<T> where T : BaseEntity
{
    private readonly IAppDbContext _context;
    private readonly DbSet<T> _dbSet;

    public Repository(IAppDbContext context)
    {
        _context = context;
        _dbSet = context.Set<T>();
    }

    public async Task<T?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        => await _dbSet.FindAsync([id], cancellationToken);

    public async Task<IReadOnlyList<T>> GetAllAsync(CancellationToken cancellationToken = default)
        => await _dbSet.AsNoTracking().ToListAsync(cancellationToken);

    public async Task AddAsync(T entity, CancellationToken cancellationToken = default)
    {
        await _dbSet.AddAsync(entity, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateAsync(T entity, CancellationToken cancellationToken = default)
    {
        _dbSet.Update(entity);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteAsync(int id, CancellationToken cancellationToken = default)
    {
        var entity = await GetByIdAsync(id, cancellationToken);
        if (entity is null) return;

        // Soft delete
        entity.IsDeleted = true;
        entity.DateDeleted = DateTime.UtcNow;
        _dbSet.Update(entity);
        await _context.SaveChangesAsync(cancellationToken);
    }
}
