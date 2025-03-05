using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using RPGapp.Models;

namespace RPGapp.Controllers;

public class HomeController : Controller{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public string Index()
    {
        return "ahojda";
    }
}