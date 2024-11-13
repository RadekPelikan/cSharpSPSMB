using System.Globalization;
using System.IO;
using FileParser; //℃

try
{
    var lines = File.ReadLines("movies.csv");
    List<Movie> jenda = new List<Movie>();

    bool isHeader = true;
    foreach (string line in lines)
    {
        if (isHeader)
        {
            isHeader = false; 
            continue;
        }
            
        Console.WriteLine(line);
        jenda.Add(ParseMovie(line));
    }
    Console.WriteLine(jenda.Count);
    Console.ReadLine();
}
catch (FileNotFoundException ex)
{
    Console.WriteLine(ex.Message);
    Console.ReadLine();
 
    Environment.Exit(1);
}

// ༼ つ ◕_◕ ༽つ
 Movie ParseMovie(string movieLine)
 {
     
     var words = movieLine.Split(",");
     Currency currency = new Currency("$", decimal.Parse(words[6].Split("$")[1], new CultureInfo("en-US")));
     

     return new Movie(words[0],
         words[1],
         words[2],
         Double.Parse(words[3]),
         Double.Parse(words[4], new CultureInfo("en-US")),
         Int32.Parse(words[5]),
         currency,
         Int32.Parse(words[7]));
 }














































// ＞﹏＜