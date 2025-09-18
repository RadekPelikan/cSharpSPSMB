using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace Files
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            List<Movies.Movies> movies = new List<Movies.Movies>();
            string[] items = new string[8];
            bool isHeader = true;

            foreach (string line in File.ReadLines("movies.csv"))
            {
                if (isHeader)
                {
                    isHeader = false;
                    continue;
                }

                items = line.Split(',');
                string worldwidegrossstring = items[6].Replace("$", "");

                movies.Add(new Movies.Movies()
                {
                    Film = items[0],
                    Genre = items[1],
                    LeadStudio = items[2],
                    AudienceScore = int.Parse(items[3]),
                    Profitability = double.Parse(items[4], CultureInfo.InvariantCulture),
                    RottenTomatoes = int.Parse(items[5]),
                    WorldwideGross = double.Parse(worldwidegrossstring, CultureInfo.InvariantCulture),
                    Year = int.Parse(items[7])
                });
            }

            var moviesByYear = movies.GroupBy(m => m.Year).ToDictionary(g => g.Key, g => g.ToList());

            foreach (var yearGroup in moviesByYear)
            {
                var worstRatedMovie = yearGroup.Value.OrderBy(m => m.RottenTomatoes).First();
                var bestRatedMovie = yearGroup.Value.OrderByDescending(m => m.RottenTomatoes).First();
                var leastProfitableMovie = yearGroup.Value.OrderBy(m => m.Profitability).First();
                var mostProfitableMovie = yearGroup.Value.OrderByDescending(m => m.Profitability).First();
                var averageWorldwideGross = yearGroup.Value.Average(m => m.WorldwideGross);

                Console.WriteLine($"Worst rated movie in {yearGroup.Key}, {worstRatedMovie.Film} {worstRatedMovie.RottenTomatoes}%");
                Console.WriteLine($"Best rated movie in {yearGroup.Key}, {bestRatedMovie.Film} {bestRatedMovie.RottenTomatoes}%");
                Console.WriteLine($"Least profitable movie in {yearGroup.Key}, {leastProfitableMovie.Film} {leastProfitableMovie.Profitability}$");
                Console.WriteLine($"Most profitable movie in {yearGroup.Key}, {mostProfitableMovie.Film} {mostProfitableMovie.Profitability}$");
                Console.WriteLine($"Average Worldwide Gross in {yearGroup.Key}, {averageWorldwideGross}$");
            }

            var allYears = movies.Select(m => m.Year).OrderBy(y => y).ToList();
            double medianYear;
            int count = allYears.Count();

            if (count % 2 == 1)
            {
                medianYear = allYears[count / 2];
            }
            else
            {
                medianYear = (allYears[(count / 2) - 1] + allYears[count / 2]) / 2.0;
            }

            Console.WriteLine($"Median Year: {medianYear}");
        }
    }
}