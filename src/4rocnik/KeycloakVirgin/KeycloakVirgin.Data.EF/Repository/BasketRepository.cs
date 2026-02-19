using EFCoreVIrgin.Data.EF.Context;
using EFCoreVIrgin.Data.EF.Entity;
using KeycloakVirgin.Common.Repository;
using KeycloakVirgin.Data.EF.Repository.Base;

namespace KeycloakVirgin.Data.EF.Repository;

public class BasketRepository(AppDbContext DbContext) : BaseRepository<BasketEntity>(DbContext),IBasketRepository
{
    public BasketEntity? GetByUserId(Guid userId)
    {
        return _dbContext.Set<BasketEntity>().FirstOrDefault(e => e.UserId == userId);
    }
}