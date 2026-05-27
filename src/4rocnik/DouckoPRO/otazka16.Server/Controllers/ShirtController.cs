

using Microsoft.AspNetCore.Mvc;
using otazka16.Server.Models.Blogs;

namespace otazka16.Server.Controllers;

public class ShirtController : Controller
{
    private static List<NewShirtModel> _shirts = new();
    
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult New(NewShirtModel shirt)
    {
        shirt.CreatedAt = DateTime.UtcNow;

        if (shirt.Size == "67")
        {
            return BadRequest("Size could not be 67");
        }
        
        _shirts.Add(shirt);
        foreach (var newShirtModel in _shirts)
        {
            Console.WriteLine(newShirtModel);
        }

        return RedirectToAction("Index");
    }
}
