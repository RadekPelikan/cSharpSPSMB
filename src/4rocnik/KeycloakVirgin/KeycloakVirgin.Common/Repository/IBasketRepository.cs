using EFCoreVirgin.Common.Repository;
using EFCoreVIrgin.Data.EF.Entity;

namespace KeycloakVirgin.Common.Repository;

public interface IBasketRepository : IBaseRepository<BasketEntity>
{
    BasketEntity? GetByUserId(Guid userId);
}