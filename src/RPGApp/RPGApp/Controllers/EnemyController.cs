using Microsoft.AspNetCore.Mvc;
using RPGApp.DAL;

namespace RPGApp.Controllers;

public class EnemyController : Controller
{
    private readonly ILogger<EnemyController> _logger;

    public EnemyController(ILogger<EnemyController> logger)
    {
        _logger = logger;
    }
}