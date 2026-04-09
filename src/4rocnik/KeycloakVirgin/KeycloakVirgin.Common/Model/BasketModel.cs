namespace KeycloakVirgin.Models;

public record BasketModel
{
    public Guid UserId { get; set; }
    
    public int ProductCount => Products?.Count ?? 0; 
    public List<ProductModel> Products { get; set; } = new List<ProductModel>();
}