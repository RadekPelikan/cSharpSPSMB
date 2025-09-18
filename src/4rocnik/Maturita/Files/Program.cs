using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace Files
{
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
            var years = movies.Select(m => m.Year).OrderBy(y => y).ToList();
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
                var raw = lines[i];
                if (string.IsNullOrWhiteSpace(raw)) continue;

                string[] parts = raw.Split(',');

                if (parts.Length < 8)
                {
                    Console.WriteLine($"⚠️ Chybný řádek: {raw}");
                    continue;
                }

                try
                {
                    movies.Add(new Movie
                    {
                        Film = parts[0].Trim(),
                        Genre = parts[1].Trim(),
                        LeadStudio = parts[2].Trim(),
                        AudienceScore = int.Parse(parts[3].Trim()),
                        Profitability = double.Parse(CleanNumber(parts[4]), CultureInfo.InvariantCulture),
                        RottenTomatoes = int.Parse(parts[5].Trim()),
                        WorldwideGross = double.Parse(CleanNumber(parts[6]), CultureInfo.InvariantCulture),
                        Year = int.Parse(parts[7].Trim())
                    });
                }
                catch
                {
                    Console.WriteLine($"⚠️ Chybný řádek: {raw}");
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

        // Přidání nového filmu do CSV (opravena nová řádka + header při vytvoření)
        static void AppendMovieToCsv(string path, Movie m)
        {
            // Pokud soubor neexistuje, vytvoř ho s hlavičkou
            if (!File.Exists(path))
            {
                using (var w = new StreamWriter(path, false))
                {
                    w.WriteLine("Film,Genre,Lead Studio,Audience score %,Profitability,Rotten Tomatoes %,Worldwide Gross,Year");
                }
            }

            // Zjisti, jestli poslední znak v souboru je newline
            bool needsNewline = false;
            var fi = new FileInfo(path);
            if (fi.Length > 0)
            {
                using (var fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                {
                    if (fs.Length > 0)
                    {
                        fs.Seek(-1, SeekOrigin.End);
                        int last = fs.ReadByte();
                        needsNewline = last != '\n';
                    }
                }
            }

            // Připoj nový záznam
            using (var writer = new StreamWriter(path, true))
            {
                if (needsNewline)
                {
                    writer.WriteLine();
                }

                writer.Write(
                    $"{m.Film},{m.Genre},{m.LeadStudio},{m.AudienceScore}," +
                    $"{m.Profitability.ToString(CultureInfo.InvariantCulture)}," +
                    $"{m.RottenTomatoes}," +
                    $"{m.WorldwideGross.ToString(CultureInfo.InvariantCulture)}," +
                    $"{m.Year}"
                );
            }
        }
    }
}
