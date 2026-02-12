using EFCoreVIrgin.Data.EF.Context;
using EFCoreVIrgin.Data.EF.Entity;

namespace EFCoreVirgin.Common.Repository;

public class ClassRepository : IBaseRepository<ClassEntity>
{
    private readonly AppDbContext _dbContext;

    public ClassRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public ClassEntity GetById(int id)
    {
        throw new NotImplementedException();
    }

    public List<ClassEntity> GetAll()
    {
        throw new NotImplementedException();
    }

    public ClassEntity Add(ClassEntity entity)
    {
        throw new NotImplementedException();
    }

    public ClassEntity Update(ClassEntity entity)
    {
        throw new NotImplementedException();
    }

    public ClassEntity Remove(int id)
    {
        throw new NotImplementedException();
    }
}