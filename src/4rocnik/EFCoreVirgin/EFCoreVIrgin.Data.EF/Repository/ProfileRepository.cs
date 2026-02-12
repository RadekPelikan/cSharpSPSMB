using System.Runtime;
using EFCoreVIrgin.Data.EF.Entity;
using Microsoft.EntityFrameworkCore;

namespace EFCoreVirgin.Common.Repository;

public class ProfileRepository : IBaseRepository<ProfileEntity>
{
    private readonly DbContext _context;
    private readonly DbSet<ProfileEntity>? _dbSet;

    public ProfileRepository(DbContext context)
    {
        _context = context;
        _dbSet = _context.Set<ProfileEntity>();
    }
    
    public ProfileEntity GetById(int id)
    {
        return _dbSet
            .Include(p => p.Student)
            .FirstOrDefault(p => p.Id == id);
    }

    public List<ProfileEntity> GetAll()
    {
        return _dbSet
            .Include(p => p.Student)
            .ToList();
    }

    public ProfileEntity Add(ProfileEntity entity)
    {
        _dbSet.Add(entity);
        _context.SaveChanges();
        return entity;
    }

    public ProfileEntity Update(ProfileEntity entity)
    {
        _dbSet.Update(entity);
        _context.SaveChanges();
        return entity;
    }

    public ProfileEntity Remove(int id)
    {
        var entity = GetById(id);
        _dbSet.Remove(entity);
        _context.SaveChanges();
        return entity;
    }
}