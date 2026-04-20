using EFCoreVIrgin.Data.EF.Context;
using EFCoreVIrgin.Data.EF.Entity;

namespace EFCoreVirgin.Common.Repository;

public class SubjectRepository : IBaseRepository<SubjectEntity>
{
    private readonly AppDbContext _dbContext;

    public SubjectRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
    }

    public SubjectEntity GetById(int id)
    {
        var subject = _dbContext.Set<SubjectEntity>().FirstOrDefault(s => s.Id == id);

        if (subject is null)
            throw new Exception($"Subject with ID {id} was not found.");

        return subject;
    }

    public List<SubjectEntity> GetAll()
    {
        return _dbContext.Set<SubjectEntity>().ToList();
    }

    public SubjectEntity Add(SubjectEntity entity)
    {
        _dbContext.Set<SubjectEntity>().Add(entity);
        _dbContext.SaveChanges();
        return entity;
    }

    public SubjectEntity Update(SubjectEntity entity)
    {
        _dbContext.Set<SubjectEntity>().Update(entity);
        _dbContext.SaveChanges();
        return entity;
    }

    public SubjectEntity Remove(int id)
    {
        var subject = _dbContext.Set<SubjectEntity>().FirstOrDefault(s => s.Id == id);

        if (subject is null)
            throw new Exception($"Subject with ID {id} was not found.");

        _dbContext.Set<SubjectEntity>().Remove(subject);
        _dbContext.SaveChanges();
        return subject;
    }
}