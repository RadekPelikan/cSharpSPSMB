namespace SpsmbBlog.DB.Entities;

public class BlogPost
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Body { get; set; }
    public DateTime DateCreated { get; set; }
    public DateTime DateModified { get; set; }
}