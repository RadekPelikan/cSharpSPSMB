using DatabaseViewForm;
using Microsoft.AspNetCore.Mvc;
using RPGApp.DAL;

namespace RPGApp.Controllers;

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
        return _dbDriver.GetAllEnemies();
    }

    [HttpPost]
    public Enemy InsertEnemy([FromBody] Enemy enemy)
    {
        Console.WriteLine(enemy);
        _dbDriver.InsertEnemy(enemy);
        return enemy;
    } 
}