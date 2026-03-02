using MaturitaFree.Common.Entities;

namespace MaturitaFree.Common.Repositories;

public interface IPersonWorkingOnBookRepository : IRepository<PersonWorkingOnBook>
{
    Task<IReadOnlyList<PersonWorkingOnBook>> GetByBookIdAsync(int bookId, CancellationToken cancellationToken = default);
    Task<IReadOnlyList<PersonWorkingOnBook>> GetByPersonIdAsync(int personId, CancellationToken cancellationToken = default);
}
