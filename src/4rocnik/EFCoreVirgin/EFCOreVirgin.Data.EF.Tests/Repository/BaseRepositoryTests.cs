using EFCoreVIrgin.Data.EF.Context;
using Microsoft.EntityFrameworkCore;

namespace EFCOreVirgin.Data.EF.Tests;

public class BaseRepositoryTests
{
    protected AppDbContext DbContext { get; private set; }
    
    public BaseRepositoryTests()
    {
        DbContext = new AppDbContext();

        DbContext.Database.Migrate();
    }
}