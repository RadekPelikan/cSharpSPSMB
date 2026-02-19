using EFCoreVirgin.Common.Repository;
using EFCoreVIrgin.Data.EF.Context;
using EFCoreVIrgin.Data.EF.Entity.Base;
using Microsoft.EntityFrameworkCore;

namespace KeycloakVirgin.Data.EF.Repository.Base;

public class BaseRepository<T>(AppDbContext DbContext) : IBaseRepository<T> where T : BaseEntity
{
    protected AppDbContext _dbContext { get; } = DbContext;

    public T? GetById(Guid id)
    {
        return _dbContext.Set<T>().FirstOrDefault(e => e.Id == id);
    }

    public List<T> GetAll()
    {
        return _dbContext.Set<T>().ToList();
    }

    public T Add(T entity)
    {
        _dbContext.Set<T>().Add(entity);
        _dbContext.SaveChanges();
        return entity;
    }

    public T? Update(T entity)
    {
        _dbContext.Set<T>().Update(entity);
        _dbContext.SaveChanges();
        return entity;
    }

    public T? Remove(Guid id)
    {
        var entity = GetById(id);
        _dbContext.Set<T>().Remove(entity);
        _dbContext.SaveChanges();
        return entity;
    }
}