using EFCoreVIrgin.Data.EF.Context;
using EFCoreVIrgin.Data.EF.Entity.Base;
using KeycloakVirgin.Data.EF.Audit;

namespace KeycloakVirgin.Data.EF.Repository.Base;

public class BaseOwnerAuditRepository<T> : BaseRepository<T> where T : BaseOwnerAuditEntity
{
    public BaseOwnerAuditRepository(IAppDbContext dbContext, AuditContext auditContext) : base(dbContext)
    {
        dbContext.CurrentUser = auditContext.UserId;
    }
}