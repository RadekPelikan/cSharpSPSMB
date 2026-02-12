using EFCoreVIrgin.Data.EF.Context;

namespace EFCOreVirgin.Data.EF.Tests;

public class BaseRepositoryTests
{
    protected AppDbContext DbContext { get; private set; }
    
    public BaseRepositoryTests()
    {
        var dbContext = new AppDbContext();
    }
}