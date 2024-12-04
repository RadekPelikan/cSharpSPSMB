using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using FirstWebApp.Models;

namespace FirstWebApp.Controllers;

[Controller]
public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public Ingredient Index()
    {
        return new Ingredient() {Name = "Sugar", Grams=10, Description = "White Sugar", Image = "/img/sugar.png"};
    }


}