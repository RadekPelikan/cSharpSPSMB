// See https://aka.ms/new-console-template for more information


/**
 * Zadání 1.
 * Vytvořte record Movie, který obsahuje property pro každou hodnotu v hlavičce movies.csv
 * Načtěte veškeré filmy do kolekce List<Movie>
 * Z tohoto listu serializujte hodnoty do jsonu a ulože jej do souboru movies.json
 *
 * Vypište následující hodnoty:
 * - Vypište počet filmů
 * - Vypište nejvyšší Porfitability a název filmu
 * - Vypište nejčastější žánr
*/

/**
 * Zadání 2.
 * Nadefinujte si record Movie dle struktury json objektu
 * Načtěte movies.json do Listu record Movie
 * Vypište průměrný Profitability
 *
 * Udělejte funkci na vracení n-tého řádku z movies.csv
 */

using System.Text.Json;

string ReadCsvLine(int n)
{
    var useReader = true;
    if (!useReader)
    {
        var lines = File.ReadAllLines("movies.csv");
        return lines[n];
    }

    using var reader = new StreamReader("movies.csv");
    int current = 0;
    string line = "";
    while (reader.EndOfStream is false)
    {
        line = reader.ReadLine();
        if (current == n)
        {
            break;
        }
        else
        {
            current++;
        }
    }

    return line;
}

var jsonText = File.ReadAllText("movies.json");

var movies = JsonSerializer.Deserialize<List<Movie>>(jsonText);


var profitability = movies.Average(e => e.Profitability);

foreach (var movie in movies)
{
    Console.WriteLine(movie);
}

Console.WriteLine($"Průměrné profitability: {profitability}");
Console.WriteLine($"5. řádek: {ReadCsvLine(1)}");
