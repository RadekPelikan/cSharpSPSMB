using System.Text.Json;

namespace otazka09;

public class Run
{
    public static void Task01()
    {
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
                    WorldWideGross = parts[6].Replace("$", ""),
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


        var jsonMovies = JsonSerializer.Serialize(movies, new JsonSerializerOptions()
        {
            WriteIndented = true,
            IncludeFields = true
        });
        File.WriteAllText("movies.json", jsonMovies);
    }
}