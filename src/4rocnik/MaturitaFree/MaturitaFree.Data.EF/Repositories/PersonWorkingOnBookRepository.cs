using MaturitaFree.Common.Entities;
using MaturitaFree.Common.Repositories;
using MaturitaFree.Data.EF.Context;
using Microsoft.EntityFrameworkCore;

namespace MaturitaFree.Data.EF.Repositories;

public sealed class PersonWorkingOnBookRepository : Repository<PersonWorkingOnBook>, IPersonWorkingOnBookRepository
{
    private readonly IAppDbContext _context;

    public PersonWorkingOnBookRepository(IAppDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<IReadOnlyList<PersonWorkingOnBook>> GetByBookIdAsync(int bookId, CancellationToken cancellationToken = default)
        => await _context.Set<PersonWorkingOnBook>()
            .AsNoTracking()
            .Where(w => w.BookId == bookId)
            .Include(w => w.Person)
            .ToListAsync(cancellationToken);

    public async Task<IReadOnlyList<PersonWorkingOnBook>> GetByPersonIdAsync(int personId, CancellationToken cancellationToken = default)
        => await _context.Set<PersonWorkingOnBook>()
            .AsNoTracking()
            .Where(w => w.PersonId == personId)
            .Include(w => w.Book)
            .ToListAsync(cancellationToken);
}
