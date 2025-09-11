using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace Files
{
    // Třída Movie - reprezentuje 1 film (řádek z CSV)
    public class Movie
    {
        public string Film { get; set; }
        public string Genre { get; set; }
        public string LeadStudio { get; set; }
        public int AudienceScore { get; set; }
        public double Profitability { get; set; }
        public int RottenTomatoes { get; set; }
        public double WorldwideGross { get; set; }
        public int Year { get; set; }

        public override string ToString()
        {
            return $"{Film} ({Year}) - RT: {RottenTomatoes}%, Profit: {Profitability}, Gross: {WorldwideGross}";
        }
    }

    class Program
    {
        static void Main()
        {
            string filePath = "movies.csv";

            // 1) Načtení filmů
            List<Movie> movies = LoadMovies(filePath);

            if (movies.Count == 0)
            {
                Console.WriteLine("Soubor je prázdný nebo neexistuje.");
                return;
            }

            // 2) Výpočty podle roků
            var groupedByYear = movies.GroupBy(m => m.Year);

            foreach (var group in groupedByYear)
            {
                Console.WriteLine($"\n📅 Rok {group.Key}");

                var worstRated = group.OrderBy(m => m.RottenTomatoes).First();
                var bestRated = group.OrderByDescending(m => m.RottenTomatoes).First();
                var mostProfitable = group.OrderByDescending(m => m.Profitability).First();
                var leastProfitable = group.OrderBy(m => m.Profitability).First();
                double avgGross = group.Average(m => m.WorldwideGross);

                Console.WriteLine($"  ❌ Nejhorší hodnocení: {worstRated.Film} ({worstRated.RottenTomatoes}%)");
                Console.WriteLine($"  ✅ Nejlepší hodnocení: {bestRated.Film} ({bestRated.RottenTomatoes}%)");
                Console.WriteLine($"  💰 Nejvýdělečnější: {mostProfitable.Film} (Profit: {mostProfitable.Profitability})");
                Console.WriteLine($"  📉 Nejméně výdělečný: {leastProfitable.Film} (Profit: {leastProfitable.Profitability})");
                Console.WriteLine($"  📊 Průměrný Worldwide Gross: {avgGross:F2}");
            }

            // 3) Medián roků
            var years = movies.Select(m => m.Year).Distinct().OrderBy(y => y).ToList();
            int medianYear = years[years.Count / 2];
            Console.WriteLine($"\n📌 Medián roků: {medianYear}");

            // 4) Přidání nového filmu
            Console.WriteLine("\nChcete přidat nový film? (a/n)");
            string volba = Console.ReadLine()?.ToLower();

            if (volba == "a")
            {
                Movie newMovie = CreateMovieFromInput();
                AppendMovieToCsv(filePath, newMovie);
                Console.WriteLine("✅ Nový film byl přidán do CSV.");
            }
        }

        // Načtení CSV souboru
        static List<Movie> LoadMovies(string path)
        {
            var movies = new List<Movie>();

            if (!File.Exists(path)) return movies;

            var lines = File.ReadAllLines(path);
            for (int i = 1; i < lines.Length; i++) // přeskočí header
            {
                string[] parts = lines[i].Split(',');

                try
                {
                    movies.Add(new Movie
                    {
                        Film = parts[0].Trim(),
                        Genre = parts[1].Trim(),
                        LeadStudio = parts[2].Trim(),
                        AudienceScore = int.Parse(parts[3].Trim()),
                        Profitability = double.Parse(
                            CleanNumber(parts[4]), CultureInfo.InvariantCulture),
                        RottenTomatoes = int.Parse(parts[5].Trim()),
                        WorldwideGross = double.Parse(
                            CleanNumber(parts[6]), CultureInfo.InvariantCulture),
                        Year = int.Parse(parts[7].Trim())
                    });
                }
                catch
                {
                    Console.WriteLine($"⚠️ Chybný řádek: {lines[i]}");
                }
            }

            return movies;
        }

        // Vyčištění číselných hodnot (odstraní $, čárky, mezery)
        static string CleanNumber(string input)
        {
            return input.Trim()
                        .Replace("$", "")
                        .Replace(",", "")
                        .Replace(" ", "");
        }

        // Vytvoření filmu z inputu uživatele
        static Movie CreateMovieFromInput()
        {
            Movie m = new Movie();

            Console.Write("Film: ");
            m.Film = Console.ReadLine();

            Console.Write("Genre: ");
            m.Genre = Console.ReadLine();

            Console.Write("Lead Studio: ");
            m.LeadStudio = Console.ReadLine();

            Console.Write("Audience score %: ");
            m.AudienceScore = int.Parse(Console.ReadLine());

            Console.Write("Profitability: ");
            m.Profitability = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            Console.Write("Rotten Tomatoes %: ");
            m.RottenTomatoes = int.Parse(Console.ReadLine());

            Console.Write("Worldwide Gross: ");
            m.WorldwideGross = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            Console.Write("Year: ");
            m.Year = int.Parse(Console.ReadLine());

            return m;
        }

        // Přidání nového filmu do CSV
        static void AppendMovieToCsv(string path, Movie m)
        {
            using (var writer = new StreamWriter(path, true))
            {
                writer.WriteLine($"{m.Film},{m.Genre},{m.LeadStudio},{m.AudienceScore},{m.Profitability.ToString(CultureInfo.InvariantCulture)},{m.RottenTomatoes},{m.WorldwideGross.ToString(CultureInfo.InvariantCulture)},{m.Year}");
            }
        }
    }
}
