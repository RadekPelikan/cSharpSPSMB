using SimpleChatApp.Domain.Entities;

namespace SimpleChatApp.Data.Abstract.Repositories;

public interface IRepository<T> where T : BaseEntity
{
    T Get(Guid id);
    
    IEnumerable<T> Get();
    
    T Insert(T entity);
    
    T Update(T entity);
    
    T Delete(Guid id);
}