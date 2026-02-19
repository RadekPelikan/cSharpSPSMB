using EFCoreVirgin.Common.Repository;
using EFCoreVIrgin.Data.EF.Entity;

namespace KeycloakVirgin.Common.Repository;

public interface IBasketRepository : IBaseRepository<BasketEntity>
{
    BasketEntity? GetByUserId(Guid userId);

    Guid? GetBasketIdByUserId(Guid userId);

    ProductEntity? AddProduct(ProductEntity product);

    ProductEntity? GetByUserAndProductIdId(Guid userId, Guid productId);
}