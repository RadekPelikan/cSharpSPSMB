namespace KeycloakVirgin.Models;

public record ProductModelEditModel : ProductModel
{
    public Guid Id { get; set; }
    
    public string? Name { get; set; }

    public decimal? Price { get; set; }

    public string? Description { get; set; }
}