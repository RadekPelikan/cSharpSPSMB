using MaturitaFree.Common.Entities;

namespace MaturitaFree.Common.Repositories;

public interface IPersonRepository : IRepository<PersonEntity>
{
    Task<PersonEntity?> GetByIdWithBooksAsync(int id, CancellationToken cancellationToken = default);
}
