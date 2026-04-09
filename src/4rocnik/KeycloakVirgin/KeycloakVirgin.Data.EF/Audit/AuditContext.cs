namespace KeycloakVirgin.Data.EF.Audit;

public record AuditContext()
{
    public Guid UserId { get; set; }
}