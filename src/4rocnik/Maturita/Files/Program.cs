using System;
using System.Collections.Generic;
using System.IO;

namespace Files
{
  internal class Program
  {
    public static void Main(string[] args)
    {
       List<Movie> AllMovies = GetAllMovies();

       int yearOftheOldestMovie = 2025;
       int yearOfTheNewestMovie = 0;
       
       foreach (var movie in AllMovies)
       {
         if (movie.Year < yearOftheOldestMovie)
         {
           yearOftheOldestMovie = movie.Year;
         }
         if (movie.Year > yearOfTheNewestMovie)
         {
           yearOfTheNewestMovie = movie.Year;
         }
       }

       Console.WriteLine(yearOfTheNewestMovie);
       Console.WriteLine(yearOftheOldestMovie);

       for (int year = yearOftheOldestMovie; year <= yearOfTheNewestMovie; year++)
       {
         Console.WriteLine($"-------------------YEAR {year}------------------------");
         Console.WriteLine(LowestProfitability(AllMovies, year).FilmName);
         Console.WriteLine(HighestProfitability(AllMovies, year).FilmName);
         Console.WriteLine(LowestRated(AllMovies, year).FilmName);
         Console.WriteLine(HighestRated(AllMovies, year).FilmName);
         Console.WriteLine(AverageGross(AllMovies, year));
         Console.WriteLine($"----------------------------------------------------");
         Console.WriteLine();
       }
       
       Console.WriteLine(YearMedian(AllMovies));
       
       
    }

    public static List<Movie> GetAllMovies()
    {
      List<Movie> AllMovies = new List<Movie>();
      using(var reader = new StreamReader(@"./movies.csv"))
      {
        reader.ReadLine();
        while (!reader.EndOfStream)
        {
          var line = reader.ReadLine();
          Movie movie = new Movie(line);
          AllMovies.Add(movie);
          //Console.WriteLine(movie);
        }
      }
      return AllMovies;
    }

    public static Movie LowestProfitability(List<Movie> AllMovies, int year)
    {
      
      decimal lowestProfibalitiy = int.MaxValue;
      int index = 0;
      for (int i = 0; i < AllMovies.Count; i++)
      {
        if(AllMovies[i].Year != year) continue;
        if (AllMovies[i].Profitability >= lowestProfibalitiy) continue;
        lowestProfibalitiy = AllMovies[i].Profitability;
        index = i;
      }
      return AllMovies[index];
      
    }
    
    public static Movie HighestProfitability(List<Movie> AllMovies, int year)
    {
      decimal highestProfitability = 0;
      int index = 0;
      for (int i = 0; i < AllMovies.Count; i++)
      {
        if(AllMovies[i].Year != year) continue;
        if (AllMovies[i].Profitability <= highestProfitability) continue;
        highestProfitability = AllMovies[i].Profitability;
        index = i;
      }
      return AllMovies[index];
    }
    
    public static Movie LowestRated(List<Movie> AllMovies, int year)
    {
      
      int lowestRated = int.MaxValue;
      int index = 0;
      for (int i = 0; i < AllMovies.Count; i++)
      {
        if(AllMovies[i].Year != year) continue;
        if (AllMovies[i].RottenTomatoes >= lowestRated) continue;
        lowestRated = AllMovies[i].RottenTomatoes;
        index = i;
      }
      return AllMovies[index];
    }
    
    public static Movie HighestRated(List<Movie> AllMovies, int year)
    {
      
      int highestRated = 0;
      int index = 0;
      for (int i = 0; i < AllMovies.Count; i++)
      {
        if(AllMovies[i].Year != year) continue;
        if (AllMovies[i].RottenTomatoes <= highestRated) continue;
        highestRated = AllMovies[i].RottenTomatoes;
        index = i;
      }
      return AllMovies[index];
    }

    public static decimal AverageGross(List<Movie> AllMovies, int year)
    {
      decimal sum = 0;
      foreach (var movie in AllMovies)
      {
        if(movie.Year != year) continue;
        sum += movie.WorldwideGross;
      }
      return sum / AllMovies.Count;
    }

    public static int YearMedian(List<Movie> AllMovies)
    {
      return AllMovies[AllMovies.Count / 2].Year;
    }
  }
}