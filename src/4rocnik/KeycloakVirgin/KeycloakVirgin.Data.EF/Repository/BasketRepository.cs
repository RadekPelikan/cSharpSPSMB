using EFCoreVIrgin.Data.EF.Context;
using EFCoreVIrgin.Data.EF.Entity;
using KeycloakVirgin.Common.Repository;
using KeycloakVirgin.Data.EF.Audit;
using KeycloakVirgin.Data.EF.Repository.Base;
using Microsoft.EntityFrameworkCore;

namespace KeycloakVirgin.Data.EF.Repository;

public class BasketRepository(IAppDbContext dbContext, AuditContext auditContext) : BaseOwnerAuditRepository<BasketEntity>(dbContext, auditContext),IBasketRepository
{
    public BasketEntity? GetByUserId(Guid userId)
    {
        return _dbContext.Set<BasketEntity>()
            .Include(e => e.Products)
            .FirstOrDefault(e => e.UserId == userId);
    }

    public Guid? GetBasketIdByUserId(Guid userId)
    {
        return _dbContext.Set<BasketEntity>()
            .Where(e => e.UserId == userId)
            .Select(e => e.Id)
            .FirstOrDefault();
    }

    public ProductEntity? AddProduct(ProductEntity product)
    {
        _dbContext.Set<ProductEntity>().Add(product);

        return product;
    }

    public ProductEntity? GetByUserAndProductIdId(Guid userId, Guid productId)
    {
        return _dbContext.Set<BasketEntity>()
            .Where(e => 
                e.UserId == userId)
            .SelectMany(e => e.Products)
            .FirstOrDefault(e => e.Id == productId);
    }
}