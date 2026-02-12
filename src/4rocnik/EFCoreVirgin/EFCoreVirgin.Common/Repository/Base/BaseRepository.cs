using EFCoreVIrgin.Data.EF.Entity.Base;

namespace EFCoreVirgin.Common.Repository;

public interface IBaseRepository<T> where T : BaseEntity
{
    T GetById(int id);
    
    List<T> GetAll();
    
    T Add(T entity);
    
    T Update(T entity);
    
    T Remove(int id);
}