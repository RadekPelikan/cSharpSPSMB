using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;
using static Files.Movies;

namespace Files
{
  internal class Program
  {
    public static void Main(string[] args)
    {
      List<Movies> movies = new List<Movies>();
      var lines = File.ReadAllLines("movies.csv");
      var header = true;

      foreach (var line in lines)
      {
        if (header) { header = false; continue; }

        var parts = line.Split(',');

        var film = parts[0];
        var genre = parts[1];
        var studio = parts[2];
        var audienceScore = int.Parse(parts[3]);
        var profit = double.Parse(parts[4] );
        var rottenTomatoesScore = int.Parse(parts[5]);
        var worldWideGross = double.Parse(parts[6]);
        var year = int.Parse(parts[7]);

        movies.Add(new Movies(film, genre, studio, audienceScore, profit, rottenTomatoesScore, worldWideGross, year));
      }

      foreach (var year in years)
      {
        var moviesInYear = movies.Where(m => m.year == year).ToList();
        
        var bestRT = movies.OrderByDescending(m => m.rottenTomatoes).First();
        var worstRT = movies.OrderBy(m => m.rottenTomatoes).First();
        var mostProfitable = movies.OrderByDescending(m => m.profit).First();
        var leastProfitable = movies.OrderBy(m => m.profit).First();
        var avgGross = movies.Average(m => m.worldwideGross);

      }
     
    }
    
    static void AddNewMovie(List<Movie> movies)
    {
      Console.WriteLine("\nPřidání nového filmu:");

      Movie newMovie = new Movie();

      Console.Write("Film: ");
      newMovie.Film = Console.ReadLine();

      Console.Write("Genre: ");
      newMovie.Genre = Console.ReadLine();

      Console.Write("Lead Studio: ");
      newMovie.LeadStudio = Console.ReadLine();

      Console.Write("Audience score %: ");
      newMovie.AudienceScore = int.Parse(Console.ReadLine());

      Console.Write("Profitability: ");
      newMovie.Profitability = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

      Console.Write("Rotten Tomatoes %: ");
      newMovie.RottenTomatoes = int.Parse(Console.ReadLine());

      Console.Write("Worldwide Gross: ");
      newMovie.WorldwideGross = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

      Console.Write("Year: ");
      newMovie.Year = int.Parse(Console.ReadLine());

      movies.Add(newMovie);

      // Zápis do CSV
      using (var writer = new StreamWriter(csvFile, append: true))
      {
        writer.WriteLine($"{newMovie.Film},{newMovie.Genre},{newMovie.LeadStudio},{newMovie.AudienceScore},{newMovie.Profitability.ToString(CultureInfo.InvariantCulture)},{newMovie.RottenTomatoes},{newMovie.WorldwideGross.ToString(CultureInfo.InvariantCulture)},{newMovie.Year}");
      }

      Console.WriteLine("Film byl přidán.");
    }
  }
}