using EFCoreVirgin.Common.Repository;
using EFCoreVIrgin.Data.EF.Context;
using EFCoreVIrgin.Data.EF.Entity.Base;
using Microsoft.EntityFrameworkCore;

namespace KeycloakVirgin.Data.EF.Repository.Base;

public class BaseRepository<T>(IAppDbContext dbContext) : IBaseRepository<T> where T : BaseEntity
{
    protected IAppDbContext _dbContext { get; } = dbContext;

    public virtual T? GetById(Guid id)
    {
        return _dbContext.Set<T>().FirstOrDefault(e => e.Id == id);
    }

    public virtual List<T> GetAll()
    {
        return _dbContext.Set<T>().ToList();
    }

    public virtual T Add(T entity)
    {
        _dbContext.Set<T>().Add(entity);
        return entity;
    }

    public virtual T? Update(T entity)
    {
        _dbContext.Set<T>().Update(entity);
        return entity;
    }

    public virtual T? Remove(Guid id)
    {
        var entity = GetById(id);
        _dbContext.Set<T>().Remove(entity);
        return entity;
    }

    public void Commit()
    {
        _dbContext.SaveChanges();
    }
}