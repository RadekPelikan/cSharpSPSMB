namespace FileManagement;

public record Movie(string Name, int Year)
{
    public override string ToString()
    {
        return $"{Name} - {Year}";
    }
}