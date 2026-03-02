using MaturitaFree.Common.Entities;
using MaturitaFree.Common.Repositories;
using MaturitaFree.Data.EF.Context;
using Microsoft.EntityFrameworkCore;

namespace MaturitaFree.Data.EF.Repositories;

public sealed class BookChapterRepository : Repository<BookChapterEntity>, IBookChapterRepository
{
    private readonly IAppDbContext _context;

    public BookChapterRepository(IAppDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<IReadOnlyList<BookChapterEntity>> GetByBookIdAsync(int bookId, CancellationToken cancellationToken = default)
        => await _context.Set<BookChapterEntity>()
            .AsNoTracking()
            .Where(c => c.BookId == bookId)
            .OrderBy(c => c.Order)
            .ToListAsync(cancellationToken);

    public async Task<BookChapterEntity?> GetByIdWithParagraphsAsync(int id, CancellationToken cancellationToken = default)
        => await _context.Set<BookChapterEntity>()
            .Include(c => c.Paragraphs.OrderBy(p => p.Order))
            .FirstOrDefaultAsync(c => c.Id == id, cancellationToken);
}
