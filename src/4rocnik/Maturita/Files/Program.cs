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

       
    }
}
}