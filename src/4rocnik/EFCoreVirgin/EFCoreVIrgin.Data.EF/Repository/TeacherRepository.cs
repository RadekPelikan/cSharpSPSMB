using EFCoreVIrgin.Data.EF.Context;
using EFCoreVIrgin.Data.EF.Entity;
using Microsoft.EntityFrameworkCore;

namespace EFCoreVirgin.Common.Repository;

public class TeacherRepository : IBaseRepository<TeacherEntity>
{
    private readonly AppDbContext _dbContetx;

    public TeacherRepository(AppDbContext dbContext)
    {
        _dbContetx = dbContext;
    }

   
    public TeacherEntity GetById(int id)
    {
        return _dbContetx.Teachers
            .Include(t => t.TimeTableRecords)
                                    .FirstOrDefault(t => t.Id == id);
    }

    public List<TeacherEntity> GetAll()
    {
        return _dbContetx.Teachers.ToList();
    }

    public TeacherEntity Add(TeacherEntity entity)
    {
        _dbContetx.Teachers.Add(entity);
        _dbContetx.SaveChanges();
        return entity;
    }

    public TeacherEntity Update(TeacherEntity entity)
    {
        _dbContetx.Teachers.Update(entity);
        _dbContetx.SaveChanges();

        return entity;
    }

    public TeacherEntity Remove(int id)
    {
        var teacher = _dbContetx.Teachers
            .Include(t => t.TimeTableRecords)
            .FirstOrDefault(t => t.Id == id);
        _dbContetx.Teachers.Remove(teacher);
        _dbContetx.SaveChanges();
        return teacher;
    }
}