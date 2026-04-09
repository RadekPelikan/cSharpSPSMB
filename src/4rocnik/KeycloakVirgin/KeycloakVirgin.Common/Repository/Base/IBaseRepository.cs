using EFCoreVIrgin.Data.EF.Entity.Base;

namespace EFCoreVirgin.Common.Repository;

public interface IBaseRepository<T> where T : BaseEntity
{
    T? GetById(Guid id);
    
    List<T> GetAll();
    
    T Add(T entity);
    
    T? Update(T entity);
    
    T? Remove(Guid id);
    
    void Commit();
}