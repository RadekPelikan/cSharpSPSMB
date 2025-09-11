using System.Collections.Generic;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;
using System.Security.Cryptography;

namespace Files
{

class Program
{
    static void Main()
    {
        List<Movies> movies = new List<Movies>();
        var lines = File.ReadAllLines("movies.csv");
        var header = true;

        foreach (var line in lines)
        {
            if (header) { header = false; continue; } 

            var parts = line.Split(',');

           
            string film = parts[0];
            string genere = parts[1];
            string studio = parts[2];
            int audienceScore = int.Parse(parts[3]);
            double profit = double.Parse(parts[4], CultureInfo.InvariantCulture);
            int rottenTomatoesScore = int.Parse(parts[5], CultureInfo.InvariantCulture);
            double worldWideGross = double.Parse(parts[6], CultureInfo.InvariantCulture);
            int year = int.Parse(parts[7]);
            movies.Add(new Movies(film, genere, studio, audienceScore, profit, rottenTomatoesScore, worldWideGross,
                year));
        }
        var byYear = movies.GroupBy(m => m.Year);

        foreach (var group in byYear)
        {
            int year = group.Key;

            var worstProfit = group.OrderBy(m => m.profit).First();
            var bestProfit = group.OrderByDescending(m => m.Profitability).First();
            var topRotten = group.OrderByDescending(m => m.RottenTomatoesScore).First();
            var lowRotten = group.OrderBy(m => m.RottenTomatoesScore).First();
            var avgGross = group.Average(m => m.WorldwideGross);

            Console.WriteLine($"Rok {year}:");
            Console.WriteLine($"   Nejhorší profitability: {worstProfit.Film} ({worstProfit.Profitability})");
            Console.WriteLine($"   Nejlepší profitability: {bestProfit.Film} ({bestProfit.Profitability})");
            Console.WriteLine($"   Nejvíc Rotten Tomatoes %: {topRotten.Film} ({topRotten.RottenTomatoesScore}%)");
            Console.WriteLine($"   Nej míň Rotten Tomatoes %: {lowRotten.Film} ({lowRotten.RottenTomatoesScore}%)");
            Console.WriteLine($"   Průměr Worldwide Gross: {avgGross:N2}");
            Console.WriteLine();
        }

        // --- medián roků ---
        var years = movies.Select(m => m.year).Distinct().OrderBy(y => y).ToList();
        double median;
        int count = years.Count;

        if (count % 2 == 1)
            median = years[count / 2];
        else
            median = (years[count / 2 - 1] + years[count / 2]) / 2.0;

        Console.WriteLine($"Medián roků: {median}");

       
    }
}
}