using EFCoreVIrgin.Data.EF.Context;
using EFCoreVIrgin.Data.EF.Entity;
using Microsoft.EntityFrameworkCore;

namespace EFCoreVirgin.Common.Repository;

public class ProfileRepository : IBaseRepository<ProfileEntity>
{
    private readonly AppDbContext _dbContext;

    public ProfileRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public List<ProfileEntity> GetAll()
    {
        return _dbContext.Set<ProfileEntity>()
            .Include(p => p.Student)
            .ToList();
    }

    public ProfileEntity GetById(int id)
    {
        var entity = _dbContext.Set<ProfileEntity>().Find(id);
        if (entity == null)
        {
            return null;
        }

        var entityGet = _dbContext.Set<ProfileEntity>()
            .Include(p => p.Student)
            .FirstOrDefault(p => p.Id == id);

        return entityGet;
    }

    public ProfileEntity Add(ProfileEntity entity)
    {
        var addedEntity = _dbContext.Set<ProfileEntity>().Add(entity).Entity;
        _dbContext.SaveChanges();
        return addedEntity;
    }

    public ProfileEntity Update(ProfileEntity entity)
    {
        var updatedEntity = _dbContext.Set<ProfileEntity>().Update(entity).Entity;
        _dbContext.SaveChanges();
        return updatedEntity;
    }

    public ProfileEntity Remove(int id)
    {
        var entity = _dbContext.Set<ProfileEntity>().Find(id);
        if (entity == null)
        {
            return null;
        }

        var removedEntity = _dbContext.Set<ProfileEntity>().Remove(entity).Entity;
        _dbContext.SaveChanges();
        return removedEntity;
    }
}