using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SpsmbBlog.DB.Entities;
using SpsmbBlog.DB.Repositories;
using SpsmbBlog.Models;

namespace SpsmbBlog.Controllers;

public class BlogsController : Controller
{
    private readonly ILogger<IndexController> _logger;
    private readonly BlogRepository _blogRepository;

    public BlogsController(ILogger<IndexController> logger, BlogRepository blogRepository)
    {
        _logger = logger;
        _blogRepository = blogRepository;
    }

    public IActionResult Index()
    {
        var blogPosts = _blogRepository.GetAll();

        return View(new BlogsViewModel()
        {
            BlogPosts = blogPosts
        });
    }

    public IActionResult New()
    {
        return View(new NewBlogViewModel());
    }

    [HttpPost("/blogs/new")]
    public IActionResult New([FromForm] NewBlogViewModel newBlog)
    {
        if (string.IsNullOrEmpty(newBlog.Title))
            return BadRequest();
        if (string.IsNullOrEmpty(newBlog.Body))
            return BadRequest();
        
        _blogRepository.Create(new BlogPost()
        {
            Title = newBlog.Title,
            Body = newBlog.Body,
        });
        
        return RedirectToAction("Index", "Blogs");
    }

[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}