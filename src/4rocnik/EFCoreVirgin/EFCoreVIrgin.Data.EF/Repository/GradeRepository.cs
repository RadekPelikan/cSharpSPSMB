using EFCoreVIrgin.Data.EF.Context;
using EFCoreVIrgin.Data.EF.Entity;

namespace EFCoreVirgin.Common.Repository;

public class GradeRepository : IBaseRepository<GradeEntity>
{
    private readonly AppDbContext _dbContetx;

    public GradeRepository(AppDbContext dbContext)
    {
        _dbContetx = dbContext;
    }
    
    public GradeEntity GetById(int id)
    {
        throw new NotImplementedException();
    }

    public List<GradeEntity> GetAll()
    {
        throw new NotImplementedException();
    }

    public GradeEntity Add(GradeEntity entity)
    {
        throw new NotImplementedException();
    }

    public GradeEntity Update(GradeEntity entity)
    {
        throw new NotImplementedException();
    }

    public GradeEntity Remove(int id)
    {
        throw new NotImplementedException();
    }
}