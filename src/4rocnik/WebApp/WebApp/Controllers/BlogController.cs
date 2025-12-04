using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Controllers;

[Route("[controller]")]
public class BlogController : Controller
{
    public static List<Blog> Blogs { get; } = new List<Blog>();

    public IActionResult Index()
    {
        return View("New", new NewBlogModel());
    }

    // GET
    [HttpGet]
    [Route("/New")]
    public IActionResult GetNew([FromForm] Blog blog)
    {
        return View("New", new NewBlogModel());
    }

    // GET
    [HttpPost]
    public IActionResult New([FromForm] Blog blog)
    {
        if (
            blog.Title is null || blog.Description is null || blog.Content is null ||
            blog.Title?.Length == 0 || blog.Description?.Length == 0 || blog.Content?.Length == 0)
        {
            var errors = new string[] { "Fields must not be empty!", "fff" }.ToList();
            return View("New", new NewBlogModel(errors));
        }

        Blogs.Add(blog);
        return Ok(Blogs);
    }
}