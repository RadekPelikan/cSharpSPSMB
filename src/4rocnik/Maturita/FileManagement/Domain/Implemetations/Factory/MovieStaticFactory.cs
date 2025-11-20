namespace FileManagement.Domain.Implemetations;

public static class MovieStaticFactory
{
    public static Movie GetFastAndFurious1() =>
        new Movie("Fast and Furious 1", 2001);


    public static Movie GetFastAndFurious(int i) =>
        new[]
        {
            new Movie("Fast and Furious 1", 2001),
            new Movie("Fast and Furious 2", 2003),
        }[i - 1];
}