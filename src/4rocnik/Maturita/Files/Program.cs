using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Files
{
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
            return $"{Film} ({Year}) | {Genre} | Studio: {LeadStudio} | " +
                   $"Audience: {AudienceScore}% | RT: {RottenTomatoes}% | " +
                   $"Profitability: {Profitability} | Gross: ${WorldwideGross}M";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;

            List<Movie> movies = new List<Movie>
            {
                new Movie { Film="Zack and Miri Make a Porno", Genre="Romance", LeadStudio="The Weinstein Company", AudienceScore=70, Profitability=1.747541667, RottenTomatoes=64, WorldwideGross=41.94, Year=2008 },
                new Movie { Film="Youth in Revolt", Genre="Comedy", LeadStudio="The Weinstein Company", AudienceScore=52, Profitability=1.09, RottenTomatoes=68, WorldwideGross=19.62, Year=2010 },
                new Movie { Film="You Will Meet a Tall Dark Stranger", Genre="Comedy", LeadStudio="Independent", AudienceScore=35, Profitability=1.211818182, RottenTomatoes=43, WorldwideGross=26.66, Year=2010 },
                new Movie { Film="When in Rome", Genre="Comedy", LeadStudio="Disney", AudienceScore=44, Profitability=0, RottenTomatoes=15, WorldwideGross=43.04, Year=2010 },
                new Movie { Film="What Happens in Vegas", Genre="Comedy", LeadStudio="Fox", AudienceScore=72, Profitability=6.267647029, RottenTomatoes=28, WorldwideGross=219.37, Year=2008 },
                new Movie { Film="WALL-E", Genre="Animation", LeadStudio="Disney", AudienceScore=89, Profitability=2.896019067, RottenTomatoes=96, WorldwideGross=521.28, Year=2008 },
                new Movie { Film="Twilight", Genre="Romance", LeadStudio="Summit", AudienceScore=82, Profitability=10.18002703, RottenTomatoes=49, WorldwideGross=376.66, Year=2008 },
                new Movie { Film="The Proposal", Genre="Comedy", LeadStudio="Disney", AudienceScore=74, Profitability=7.8675, RottenTomatoes=43, WorldwideGross=314.70, Year=2009 },
                new Movie { Film="Tangled", Genre="Animation", LeadStudio="Disney", AudienceScore=88, Profitability=1.365692308, RottenTomatoes=89, WorldwideGross=355.01, Year=2010 },
                new Movie { Film="The Twilight Saga: New Moon", Genre="Drama", LeadStudio="Summit", AudienceScore=78, Profitability=14.1964, RottenTomatoes=27, WorldwideGross=709.82, Year=2009 },
            };

            Console.WriteLine("=== All Movies ===");
            movies.ForEach(m => Console.WriteLine(m));

            Console.WriteLine("\n=== Top 5 by Audience Score ===");
            var topAudience = movies.OrderByDescending(m => m.AudienceScore).Take(5);
            foreach (var m in topAudience) Console.WriteLine(m);

            Console.WriteLine("\n=== Average Rotten Tomatoes Score ===");
            double avgRt = movies.Average(m => m.RottenTomatoes);
            Console.WriteLine($"Average RT Score: {avgRt:F2}%");
        }
    }
}
