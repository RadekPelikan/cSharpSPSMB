using DatabaseViewForm;
using Microsoft.AspNetCore.Mvc;
using RPGApp.DAL;

namespace RPGapp.Controllers;

[Route("api/[controller]")]

public class EnemyController : Controller
{
    private readonly ILogger<EnemyController> _logger;
    private readonly DBDriver _dbDriver;

    public EnemyController(ILogger<EnemyController> logger, DBDriver dbDriver)
    {
        _logger = logger;
        _dbDriver = dbDriver;
    }

    [HttpGet]

    public List<Enemy> GetAllEnemies()
    {
        return _dbDriver.GetAll();
    }
}