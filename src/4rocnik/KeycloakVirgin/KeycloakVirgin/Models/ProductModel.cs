namespace KeycloakVirgin.Models;

public record ProductModel
{
    public string Name { get; set; }
    public decimal Price { get; set; }
    public string Description { get; set; }
}

public record BasketModel
{
    public Guid UserId { get; set; }
    
    public int ProductCount => Products?.Count ?? 0; 
    public List<ProductModel> Products { get; set; } = new List<ProductModel>();
}