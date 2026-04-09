using MaturitaFree.Common.Entities;
using MaturitaFree.Common.Repositories;
using MaturitaFree.Data.EF.Context;
using Microsoft.EntityFrameworkCore;

namespace MaturitaFree.Data.EF.Repositories;

public sealed class BookRepository : Repository<BookEntity>, IBookRepository
{
    private readonly IAppDbContext _context;

    public BookRepository(IAppDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<BookEntity?> GetByIdWithChaptersAsync(int id, CancellationToken cancellationToken = default)
        => await _context.Set<BookEntity>()
            .Include(b => b.Chapters.OrderBy(c => c.Order))
                .ThenInclude(c => c.Paragraphs.OrderBy(p => p.Order))
            .FirstOrDefaultAsync(b => b.Id == id, cancellationToken);

    public async Task<BookEntity?> GetByIdWithContributorsAsync(int id, CancellationToken cancellationToken = default)
        => await _context.Set<BookEntity>()
            .Include(b => b.Contributers)
                .ThenInclude(c => c.Person)
            .FirstOrDefaultAsync(b => b.Id == id, cancellationToken);
}
