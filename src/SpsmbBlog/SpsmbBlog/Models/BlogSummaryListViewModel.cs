using SpsmbBlog.DB.Entities;

namespace SpsmbBlog.Models;

public class BlogSummaryListViewModel
{
    public IEnumerable<BlogSummaryViewModel> BlogPosts { get; set; }
}