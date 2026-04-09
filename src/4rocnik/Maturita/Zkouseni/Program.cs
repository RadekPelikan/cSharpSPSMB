using System.Text.Json;

Console.WriteLine("Ahoj");

/**
 * Naprogramuj čtení movies.json souboru
 * Přečti fimly do recordu Movie
 * Ulož je do List<Movie>
 * Uložený list vyprintuj
 * Uložený list ulož do movies2.json
 *
 * Přečti mi 6., 7. řádek z movies.csv
 */


using StreamReader ahoj = new StreamReader("movies.csv");
string houba;
while ((houba = ahoj.ReadLine()) != null)
{
    Console.WriteLine(houba.Split(",")[0]);
}

using StreamWriter jo = new StreamWriter("text.txt");
jo.WriteLine("prvni radek");

// string json = File.ReadAllLines("movies.json");

JsonSerializer.Serialize()