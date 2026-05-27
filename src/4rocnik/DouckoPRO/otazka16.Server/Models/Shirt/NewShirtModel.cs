namespace otazka16.Server.Models.Blogs;

public record NewShirtModel()
{
    public string Color { get; set; }
    public string Size { get; set; }
    public DateTime CreatedAt { get; set; }
};