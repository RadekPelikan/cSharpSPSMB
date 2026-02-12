using EFCoreVIrgin.Data.EF.Context;
using EFCoreVIrgin.Data.EF.Entity;
using Microsoft.EntityFrameworkCore;

namespace EFCoreVirgin.Common.Repository;

public class TimeTableRecordRepository : IBaseRepository<TimeTableRecordEntity>
{
    private readonly AppDbContext _dbContext;
    public TimeTableRecordRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public TimeTableRecordEntity GetById(int id)
    {
        return _dbContext.TimeTableRecords.Include(t => t.Class)
            .FirstOrDefault(x => x.Id == id);
        
    }

    public List<TimeTableRecordEntity> GetAll()
    {
        throw new NotImplementedException();
    }

    public TimeTableRecordEntity Add(TimeTableRecordEntity entity)
    {
        throw new NotImplementedException();
    }

    public TimeTableRecordEntity Update(TimeTableRecordEntity entity)
    {
        throw new NotImplementedException();
    }

    public TimeTableRecordEntity Remove(int id)
    {
        throw new NotImplementedException();
    }
}