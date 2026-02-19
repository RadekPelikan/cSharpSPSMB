using System.Security.Claims;
using System.Security.Principal;
using EFCoreVIrgin.Data.EF.Entity;
using KeycloakVirgin.Common.Repository;
using KeycloakVirgin.Models;
using KeycloakVirgin.Models.Business;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace KeycloakVirgin.Controllers;

[ApiController]
[Route("[controller]")]
public class TestAuthController(
    IBasketRepository basketRepository,
    ILogger<TestAuthController> logger) : ControllerBase
{
    private static Dictionary<Guid, BasketModel> _baskets = new Dictionary<Guid, BasketModel>();

    private IBasketRepository _basketRepository { get; } = basketRepository;

    private readonly ILogger<TestAuthController> _logger = logger;


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
    [HttpGet("memory/basket")]
    public BasketModel GetBasket()
    {
        var guid = GetUserId();

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
    [HttpPost("memory/basket")]
    public BasketModel AddToBasket([FromBody] ProductModel product)
    {
        var basket = GetBasket();

        basket.Products.Add(product);

        return GetBasket();
    }

    [Authorize]
    [HttpGet("persistent/basket")]
    public BasketModel GetPersistentBasket()
    {
        var guid = GetUserId();

        var basketE = _basketRepository.GetByUserId(guid);
        if (basketE is null)
        {
            return new BasketModel()
            {
                UserId = guid,
                Products = new List<ProductModel>()
            };
        }

        return new BasketModel()
        {
            UserId = guid,
            Products = basketE.Products.Select(p => new ProductModel()
                {
                    Name = p.Name,
                    Price = p.Price,
                    Description = p.Description
                }
            ).ToList()
        };
    }

    [Authorize]
    [HttpPost("persistent/basket")]
    public BasketModel AddToPersistentBasket([FromBody] ProductModel product)
    {
        var guid = GetUserId();

        var productE = new ProductEntity()
        {
            Name = product.Name,
            Price = product.Price,
            Description = product.Description,
        };

        var basketE = _basketRepository.GetByUserId(guid);
        if (basketE is null)
        {
            _basketRepository.Add(new BasketEntity()
            {
                UserId = guid,
                Products = new List<ProductEntity>()
                {
                    productE
                }
            });
        }
        else
        {
            _basketRepository.AddProduct(productE with { Basket = basketE });
        }

        _basketRepository.Commit();


        return GetPersistentBasket();
    }

    [Authorize]
    [HttpPut("persistent/basket")]
    public IActionResult UpdateProduct([FromBody] ProductModelEditModel product)
    {
        var guid = GetUserId();

        var productE = _basketRepository.GetByUserAndProductIdId(guid, product.Id);
        if (productE is null)
        {
            return NotFound(new NotFoundModel());
        }
        else
        {
            if (product.Name is not null) productE.Name = product.Name;
            if (product.Price is not null) productE.Price = product.Price.Value;
            if (product.Description is not null) productE.Description = product.Description;
        }

        _basketRepository.Commit();

        return Ok(GetPersistentBasket());
    }

    private Guid GetUserId()
    {
        var type = ClaimTypes.NameIdentifier;
        var sub = User.FindFirst(type)?.Value;
        if (sub is null)
        {
            throw new ArgumentNullException($"{type} is not present in jwt");
        }

        if (Guid.TryParse(sub, out var guid) is false)
        {
            throw new ArgumentNullException($"Invalid {nameof(Guid)} in {type} in jwt");
        }

        return guid;
    }
}