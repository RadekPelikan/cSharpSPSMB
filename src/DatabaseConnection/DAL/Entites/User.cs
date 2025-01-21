namespace DBDriver.Entites;

public class User
{
    public int Id { get; set; }
    public string Username { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime ModifiedAt { get; set; }
}