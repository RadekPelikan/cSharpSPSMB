// See https://aka.ms/new-console-template for more information

using otazka06;

Console.WriteLine("Hello, World!");


// každé číslo v poli převeďte na abecedu

// existuje abeceda: ABCDEFGHIJ
// Vytvořte pole čísel od 0 do 10_000
// 0 = A
// 10 = BA
// 111 = BBB
// 9999 = JJJJ
// 7070 = HAHA

// LINQ - Select, Where, Count
// Vyhodnoťte kolikrát se v tomto poli zobrazí slovo "HA"

// výsledek:
// HA nalezeno: 70 krát
// Run.Task03();

// Zadání 4.
// Objednávky, kde jedna hodnta je předmět nákupu a druhá hodnota je počet položek
// Následovný vstup:
// jablko:4
// rohlik:5
// pomeranc:4
// jablko:6
// sroubovak:1
// vejce:20
// vejce:5
// ""
var lines = new List<string>();
string? line;
do
{
    line = Console.ReadLine();
    lines.Add(line);
} while (line != "");


var items = lines
        // Odebrani prazdnych radku
        .Where(l => l != "")
        // Validace radku
        .Where(l =>
        {
            var parts = l.Split(":");
            if (parts.Length != 2)
            {
                return false;
            }

            var countStr = parts[1];
            if (int.TryParse(countStr, out var count) is false)
            {
                return false;
            }

            if (count <= 0)
            {
                return false;
            }

            return true;
        })
        // prevod na tuple (sring item, int count)
        .Select(l =>
        {
            var parts = l.Split(":");

            var item = parts[0].Trim();
            var count = int.Parse(parts[1]);

            return (item, count);
        })
        // group by pro seskupeni vsech polozek dle klice do kolekci
        // -- priklad:
        // rohlik: 5
        // rohlik: 3
        // jablko: 2
        // -- vystup:
        // rohlik: [(rohlik, 5), (rohlik, 3)]
        // jablko: [(jablko, 3)]
        // .GroupBy() je zde kvuli tomu, ze .ToDictionary() neumi samo groupnout hodnoty, nemuzeme tedy pridat 2x stejny klic napr. rohlik
        .GroupBy(itemCount => itemCount.item)
        // to dictionary prevadi grouping na dictionary
        // pro kazdy klic, (napr: rohlik, jablko) to udela novy zaznam v dictionary
        // pro kazdy klic tato ToDictionary() secte veskere count hodnoty
        // -- vystup:
        // rohlik, 8
        // jablko, 2
        .ToDictionary(
            kvp => kvp.Key,
            kvp =>
            {
                var itemCounts = kvp.ToList();

                var sum = itemCounts.Sum(itemCount => itemCount.count);
                return sum;
            }
        )
    ;

foreach (var item in items)
{
    Console.WriteLine($"{item.Key}, {item.Value}");
}
// jablko:4 -> string item; int count;
// 
// var items = new Dictionary<string, int>();
// vystup:
// jabko, 10
// rohlik, 5
// pomeranc, 4
// sroubovak, 1
// vejce, 25

// potrebne LINQ metody: .Select(), .Where(), .Count(), .ToDictionary()