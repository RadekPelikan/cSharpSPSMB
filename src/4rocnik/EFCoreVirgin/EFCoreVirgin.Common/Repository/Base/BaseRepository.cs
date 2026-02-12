using EFCoreVIrgin.Data.EF.Entity.Base;

namespace EFCoreVirgin.Common.Repository;

public interface BaseRepository<T> where T : BaseEntity
{
    T GetById(int id);
    
    T GetAll();
    
    T Add(T entity);
    
    T Update(T entity);
    
    T Remove(int id);
}