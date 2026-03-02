using MaturitaFree.Common.Entities;
using MaturitaFree.Common.Repositories;
using MaturitaFree.Data.EF.Context;
using Microsoft.EntityFrameworkCore;

namespace MaturitaFree.Data.EF.Repositories;

public sealed class PersonRepository : Repository<PersonEntity>, IPersonRepository
{
    private readonly IAppDbContext _context;

    public PersonRepository(IAppDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<PersonEntity?> GetByIdWithBooksAsync(int id, CancellationToken cancellationToken = default)
        => await _context.Set<PersonEntity>()
            .Include(p => p.WorkedOnBooks)
                .ThenInclude(w => w.Book)
            .FirstOrDefaultAsync(p => p.Id == id, cancellationToken);
}
