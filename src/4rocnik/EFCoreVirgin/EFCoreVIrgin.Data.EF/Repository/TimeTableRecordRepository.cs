using EFCoreVIrgin.Data.EF.Context;
using EFCoreVIrgin.Data.EF.Entity;
using Microsoft.EntityFrameworkCore;

namespace EFCoreVirgin.Common.Repository;

public class TimeTableRecordRepository : ITimeTableRecordRepository
{
    private readonly AppDbContext _dbContext;

    public TimeTableRecordRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public TimeTableRecordEntity GetById(int id)
    {
        return _dbContext.TimeTableRecords
            .Include(t => t.Teacher)
            .Include(t => t.Class)
            .Include(t => t.Subject)
            .FirstOrDefault(t => t.Id == id);
    }

    public List<TimeTableRecordEntity> GetAll()
    {
        return _dbContext.TimeTableRecords.ToList();
    }

    public TimeTableRecordEntity Add(TimeTableRecordEntity entity)
    {
        _dbContext.TimeTableRecords.Add(entity);
        _dbContext.SaveChanges();

        return GetById(entity.Id);
    }

    public TimeTableRecordEntity Update(TimeTableRecordEntity entity)
    {
        _dbContext.TimeTableRecords.Update(entity);
        _dbContext.SaveChanges();

        return GetById(entity.Id);
    }

    public TimeTableRecordEntity Remove(int id)
    {
        var record = GetById(id);
        if (record != null)
        {
            _dbContext.TimeTableRecords.Remove(record);
            _dbContext.SaveChanges();
        }

        return record;
    }

    public List<TimeTableRecordEntity> GetByClassId(int id)
    {
        return _dbContext.TimeTableRecords
            .Include(t => t.Teacher)
            .Include(t => t.Class)
            .Include(t => t.Subject)
            .Where(t => t.ClassId == id)
            .ToList();
    }
}