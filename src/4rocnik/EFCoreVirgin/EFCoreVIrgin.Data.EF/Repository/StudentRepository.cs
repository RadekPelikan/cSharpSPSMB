using EFCoreVIrgin.Data.EF.Context;
using EFCoreVIrgin.Data.EF.Entity;
using Microsoft.EntityFrameworkCore;

namespace EFCoreVirgin.Common.Repository;

public class StudentRepository : IBaseRepository<StudentEntity>
{
    private readonly AppDbContext _dbContext;

    public StudentRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public StudentEntity GetById(int id)
    {
        return _dbContext.Students
            .Include(s => s.Profile)
            .Include(s => s.Class)
            .FirstOrDefault(s => s.Id == id);
    }

    public List<StudentEntity> GetAll()
    {
       return _dbContext.Students
       .Include(s => s.Profile)
       .Include(s => s.Class).ToList();
    }

    public StudentEntity Add(StudentEntity entity)
    {
        _dbContext.Students.Add(entity);
        _dbContext.SaveChanges();
        return entity;
    }

    public StudentEntity Update(StudentEntity entity)
    {
        var existingEntity = _dbContext.Students.Find(entity.Id);
        if (existingEntity != null)
        {
            _dbContext.Entry(existingEntity).CurrentValues.SetValues(entity);
            _dbContext.SaveChanges();
            return existingEntity;
        }
        return null;
    }

    public StudentEntity Remove(int id)
    {
        var entity = _dbContext.Students.Find(id);
        if (entity != null)
        {
            _dbContext.Students.Remove(entity);
            _dbContext.SaveChanges();
        }
        return entity;
    }
}