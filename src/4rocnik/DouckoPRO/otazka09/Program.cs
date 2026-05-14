// See https://aka.ms/new-console-template for more information


/**
 * Vytvořte record Movie, který obsahuje property pro každou hodnotu v hlavičce movies.csv
 * Načtěte veškeré filmy do kolekce List<Movie>
 * Z tohoto listu serializujte hodnoty do jsonu a ulože jej do souboru movies.json
 *
 * Vypište následující hodnoty:
 * - Vypište počet filmů
 * - Vypište nejvyšší Porfitability a název filmu
 * - Vypište nejčastější žánr
*/

var movies = new List<Movie>();
using (var reader = new StreamReader("movies.csv"))
{
    var head = reader.ReadLine();
    var line = "";
    while ((line = reader.ReadLine()) != null)
    {
        var parts = line.Split(",");

        var movie = new Movie()
        {
            Film = parts[0],
            Genre = parts[1],
            LeadStudio = parts[2],
            AudienceScore = double.Parse(parts[3]),
            Profitability = double.Parse(parts[4]),
            RottenTomatoes = double.Parse(parts[5]),
            WorldWideGross = double.Parse(parts[6].Replace("$", "")),
            Year = int.Parse(parts[7])
        };
        movies.Add(movie);
    }
}

Console.WriteLine($"Počet: {movies.Count}");
var max = movies.MaxBy(e => e.Profitability);
Console.WriteLine($"Nejvyšší Porfitability: {max.Profitability} movie: {max.Film}");
var genre = movies.CountBy(m => m.Genre).MaxBy(e => e.Value);
Console.WriteLine($"Vypište nejčastější žánr: {genre.Key}, počet {genre.Value}");


public record Movie
{
    public string Film;
    public string Genre;
    public string LeadStudio;
    public double AudienceScore;
    public double Profitability;
    public double RottenTomatoes;
    public double WorldWideGross;
    public int Year;
}