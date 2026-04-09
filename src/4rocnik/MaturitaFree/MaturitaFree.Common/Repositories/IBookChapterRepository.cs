using MaturitaFree.Common.Entities;

namespace MaturitaFree.Common.Repositories;

public interface IBookChapterRepository : IRepository<BookChapterEntity>
{
    Task<IReadOnlyList<BookChapterEntity>> GetByBookIdAsync(int bookId, CancellationToken cancellationToken = default);
    Task<BookChapterEntity?> GetByIdWithParagraphsAsync(int id, CancellationToken cancellationToken = default);
}
