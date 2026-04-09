using MaturitaFree.Common.Entities;

namespace MaturitaFree.Common.Repositories;

public interface IBookRepository : IRepository<BookEntity>
{
    Task<BookEntity?> GetByIdWithChaptersAsync(int id, CancellationToken cancellationToken = default);
    Task<BookEntity?> GetByIdWithContributorsAsync(int id, CancellationToken cancellationToken = default);
}
