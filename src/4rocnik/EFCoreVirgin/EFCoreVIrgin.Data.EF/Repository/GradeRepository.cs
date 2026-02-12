using EFCoreVIrgin.Data.EF.Context;
using EFCoreVIrgin.Data.EF.Entity;
using EFCoreVIrgin.Data.EF.Migrations;
using Microsoft.EntityFrameworkCore;

namespace EFCoreVirgin.Common.Repository;

public class GradeRepository : IBaseRepository<GradeEntity>
{
    private readonly AppDbContext _dbContext;

    public GradeRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public GradeEntity GetById(int id)
    {
        return _dbContext.Grades.Include(t => t.Profile).FirstOrDefault(t => t.Id == id);
    }

    public List<GradeEntity> GetAll()
    {
        return _dbContext.Grades.ToList();
    }

    public GradeEntity Add(GradeEntity entity)
    {
        _dbContext.Grades.Add(entity);
        _dbContext.SaveChanges();

        return entity;
    }

    public GradeEntity Update(GradeEntity entity)
    {
        var existingEntity = _dbContext.Grades.Find(entity.Id);

        if (existingEntity is null)
        {
            throw new KeyNotFoundException($"Grade with id {entity.Id} was not found.");
        }

        _dbContext.Entry(existingEntity).CurrentValues.SetValues(entity);
        _dbContext.SaveChanges();

        return existingEntity;
    }

    public GradeEntity Remove(int id)
    {
        var grade = _dbContext.Grades.Find(id);

        if (grade is null)
        {
            throw new KeyNotFoundException($"Grade with id {id} was not found.");
        }

        _dbContext.Grades.Remove(grade);
        _dbContext.SaveChanges();

        return grade;
    }
}