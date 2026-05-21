namespace otazka06;

public static class Run
{
    public static void Task00()
    {
        var counts = Enumerable.Range(0, 10_000)
            .GroupBy(n => n / 1000)
            .Select(kvp => (kvp.Key, kvp.Count(n => n.ToString().Contains("67"))));

        foreach (var grouping in counts)
        {
            Console.WriteLine(grouping);
        }
    }

    public static void Task01()
    {
        var alphabet = "ABCDEFGHIJ";

        var word = "CHA";
        var i = 0;
        var numbers = new int[10_000].Select(e => i++);
        var words = numbers
            .Select(n =>
                string.Join("",
                    n.ToString().Select(c => alphabet[c - '0'])
                )
            )
            .ToList();
        Console.WriteLine(words);
        var count = words.Count(e => e.Contains(word));

        Console.WriteLine(count);
    }

    private static IEnumerable<int> GenerujCisla()
    {
        // var ms = 1000;
        // Thread.Sleep(ms);
        // yield return 0;
        // Thread.Sleep(ms);
        // yield return 1;
        //
        // Thread.Sleep(ms);
        // yield return 2;
        //
        // Thread.Sleep(ms);
        // yield return 3;
        //
        // Thread.Sleep(ms);
        // yield return 4;
        //
        // Thread.Sleep(ms);
        // yield return 5;
        //
        // Thread.Sleep(ms);
        // yield return 6;
        //
        // Thread.Sleep(ms);


        var ms = 1000;
        for (int i = 0; i < 7; i++)
        {
            Thread.Sleep(ms);
            yield return i;
        }
    }

    private static IEnumerable<int> GenerujCislaKolekce()
    {
        var ms = 1000;
        List<int> arr = new List<int>();
        for (int i = 0; i < 7; i++)
        {
            Thread.Sleep(ms);
            arr.Add(i);
        }

        return arr;
    }

    public static void Task02()
    {
        foreach (var i in GenerujCisla())
        {
            Console.WriteLine(i);
        }
    }

    private static IEnumerable<int> EvenNumbers()
    {
        for (int i = 0; i < int.MaxValue; i += 2)
        {
            yield return i;
        }
    }

    public static void Task03()
    {
        foreach (var i in EvenNumbers())
        {
            Console.WriteLine(i);
        }
    }

    public static void Task04()
    {
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
    }
}