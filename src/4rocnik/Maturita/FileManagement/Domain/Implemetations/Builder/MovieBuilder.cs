namespace FileManagement.Domain.Implemetations;

public class MovieBuilder
{
    private Movie _instance = new Movie(null, 0);

    public MovieBuilder AddName(string name)
    {
        _instance = _instance with { Name = name };
        return this;
    }

    public MovieBuilder AddYear(int year)
    {
        _instance = _instance with { Year = year };
        return this;
    }

    public Movie Build()
    {
        return _instance;
    }
}