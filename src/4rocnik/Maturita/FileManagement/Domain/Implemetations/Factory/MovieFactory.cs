namespace FileManagement.Domain.Implemetations;

public class MovieFactory
{
    private readonly string _presetName;

    public MovieFactory(string presetName)
    {
        _presetName = presetName;
    }
    
    public Movie GetFastAndFurious1() =>
        new Movie($"{_presetName}_Fast and Furious 1", 2001);


    public Movie GetFastAndFurious(int i) =>
        new[]
        {
            new Movie($"{_presetName}_Fast and Furious 1", 2001),
            new Movie($"{_presetName}_Fast and Furious 2", 2003),
        }[i];
}