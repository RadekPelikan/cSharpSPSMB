using MaturitaFree.Common.Entities;
using MaturitaFree.Common.Repositories;
using MaturitaFree.Data.EF.Context;
using Microsoft.EntityFrameworkCore;

namespace MaturitaFree.Data.EF.Repositories;

public sealed class BookParagraphRepository : Repository<BookParagraphEntity>, IBookParagraphRepository
{
    private readonly IAppDbContext _context;

    public BookParagraphRepository(IAppDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<IReadOnlyList<BookParagraphEntity>> GetByChapterIdAsync(int chapterId, CancellationToken cancellationToken = default)
        => await _context.Set<BookParagraphEntity>()
            .AsNoTracking()
            .Where(p => p.ChapterId == chapterId)
            .OrderBy(p => p.Order)
            .ToListAsync(cancellationToken);
}
