using System.Security.Claims;
using System.Security.Principal;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KeycloakVirgin.Controllers;

[ApiController]
[Route("[controller]")]
public class TestAuthController : ControllerBase
{
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

    [HttpGet("Identifiers")]
    [Authorize]
    public string? IDentifiers()
    {
        return User.FindFirst("nameidentifier")?.Value;
    }
}