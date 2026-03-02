using MaturitaFree.Common.Entities;

namespace MaturitaFree.Common.Repositories;

public interface IBookParagraphRepository : IRepository<BookParagraphEntity>
{
    Task<IReadOnlyList<BookParagraphEntity>> GetByChapterIdAsync(int chapterId, CancellationToken cancellationToken = default);
}
