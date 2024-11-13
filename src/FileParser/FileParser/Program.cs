using System.IO; //℃

try
{

    var lines = File.ReadLines("movies.csv");
    Console.WriteLine(lines);
    List<Movie> jenda = new List<Movie>();
    
    foreach (string line in lines)
    {
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
    

     return new Movie(words[0],
         words[1],
         words[2],
         Double.Parse(words[3]),
         Int32.Parse(words[4]),
         Int32.Parse(words[5]),
         Int32.Parse(words[6]),
         Int32.Parse(words[7]));
 }
