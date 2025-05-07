using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SpsmbBlog.DB.Entities;
using SpsmbBlog.DB.Repositories;
using SpsmbBlog.Models;

namespace SpsmbBlog.Controllers;

public class IndexController : Controller
{
    private readonly ILogger<IndexController> _logger;
    private readonly BlogRepository _blogRepository;

    public IndexController(ILogger<IndexController> logger, BlogRepository blogRepository)
    {
        _logger = logger;
        _blogRepository = blogRepository;
    }

    [HttpGet("")]
    public IActionResult Index()
    {
        return View();
    }

    [HttpGet("Privacy")]
    public IActionResult Privacy()
    {
        return View();
    }

    public IActionResult Blogs()
    {
        var blogPosts = _blogRepository.GetAll();
        
        return View(new BlogsViewModel()
        {
            BlogPosts = blogPosts
        });
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}