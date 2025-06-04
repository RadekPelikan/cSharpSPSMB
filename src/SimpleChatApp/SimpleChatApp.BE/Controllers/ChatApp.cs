using Microsoft.AspNetCore.Mvc;

namespace SimpleChatApp.BE.Controllers;

public class ChatApp : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}