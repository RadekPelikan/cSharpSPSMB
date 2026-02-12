using EFCoreVIrgin.Data.EF.Context;
using EFCoreVIrgin.Data.EF.Entity;

namespace EFCoreVirgin.Common.Repository;

public class ClassRepository : IBaseRepository<ClassEntity>
{
    private readonly AppDbContext _dbContetx;

    public ClassRepository(AppDbContext dbContext)
    {
        _dbContetx = dbContext;
    }
    
    public List<ClassEntity> GetAll()
    {
        return _dbContetx.Classes
            .Include(c => c.Students)
            .Include(c => c.TimeTableRecords)
            .ToList();
    }
    
    public ClassEntity GetById(int id)
    {
        var entity = _dbContetx.Classes.Find(id);
        if (entity == null)
        {
            return null;
        }
        var entityGet = _dbContetx.Classes
            .Include(c => c.Students)
            .Include(c => c.TimeTableRecords)
            .FirstOrDefault(c => c.Id == id);
        return entityGet;
    }
    
    public ClassEntity Add(ClassEntity entity)
    {
        var addedEntity = _dbContetx.Classes.Add(entity).Entity;
        _dbContetx.SaveChanges();
        return addedEntity;
    }

    public ClassEntity Update(ClassEntity entity)
    {
        var updatedEntity = _dbContetx.Classes.Update(entity).Entity;
        _dbContetx.SaveChanges();
        return updatedEntity;
    }

    public ClassEntity Remove(int id)
    {
        var entity = _dbContetx.Classes.Find(id);
        if (entity == null)
        {
            return null;
        }
        var removedEntity = _dbContetx.Classes.Remove(entity).Entity;
        _dbContetx.SaveChanges();
        return removedEntity;
    }
}