namespace otazka06;

public static class Run
{
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

}