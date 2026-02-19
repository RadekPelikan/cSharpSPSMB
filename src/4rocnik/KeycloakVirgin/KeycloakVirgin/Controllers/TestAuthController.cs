using System.Security.Claims;
using System.Security.Principal;
using KeycloakVirgin.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KeycloakVirgin.Controllers;

[ApiController]
[Route("[controller]")]
public class TestAuthController : ControllerBase
{
    private static Dictionary<Guid, BasketModel> _baskets = new Dictionary<Guid, BasketModel>();
    
    private readonly ILogger<TestAuthController> _logger;


    public TestAuthController(ILogger<TestAuthController> logger)
    {
        _logger = logger;
    }

    [HttpGet("me")]
    [Authorize]
    public Dictionary<string, List<string>> GetMe()
    {
        return User.Claims
            .GroupBy(c => c.Type)
            .ToDictionary(
                g => g.Key,
                g => g.Select(c => c.Value).ToList()
            );
    }

    [Authorize]
    [HttpGet("basket")]
    public BasketModel GetBasket()
    {
        var _guid = GetUserId();

        if (_guid is not Guid guid)
        {
            throw new ArgumentNullException($"{nameof(guid)} sub is not present in jwt");
        }

        if (_baskets.TryGetValue(guid, out var basket) is false)
        {
            basket = new BasketModel()
            {
                UserId = guid,
            };
            _baskets.Add(guid, basket);
        }

        return basket;
    }
    
    [Authorize]
    [HttpPost("basket")]
    public BasketModel AddToBasket([FromBody] ProductModel product)
    {
        var basket = GetBasket();
        
        basket.Products.Add(product);

        return GetBasket();
    }
    
    private Guid? GetUserId()
    {
        var sub = User.FindFirst("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier")?.Value;
        if (sub is null)
        {
            return null;
        }

        return new Guid(sub);
    }
}