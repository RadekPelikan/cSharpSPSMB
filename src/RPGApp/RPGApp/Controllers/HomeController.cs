using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using RPGApp.Models;

namespace RPGApp.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public string Index()
    {
        return "Ahoj svete";
    }
}