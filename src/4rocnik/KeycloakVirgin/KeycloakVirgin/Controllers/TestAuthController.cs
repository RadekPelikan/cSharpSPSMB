using System.Security.Claims;
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
    public Dictionary<string, string> GetMe(ClaimsPrincipal claimsPrincipal)
    {
        return claimsPrincipal.Claims.ToDictionary(c => c.Type, c => c.Value);
    }
}