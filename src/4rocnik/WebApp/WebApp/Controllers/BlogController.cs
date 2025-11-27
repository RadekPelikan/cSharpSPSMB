using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Controllers;

public class BlogController : Controller
{
    public static List<Blog> Blogs { get; } = new List<Blog>();
    
    // GET
    [HttpPost]
    public IActionResult Index([FromForm] Blog blog)
    {
        Blogs.Add(blog);
        return Ok(Blogs);
    }
}