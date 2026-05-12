namespace otazka01;

public static class Run
{
    public static void Task01()
    {
        Console.Write("číslo a: ");
        var aStr = Console.ReadLine();

        if (double.TryParse(aStr, out var a))
        {
            Console.WriteLine("Invalid value for a");
        }
        
        Console.Write("číslo b: ");
        var bStr = Console.ReadLine();
        
        if (double.TryParse(bStr, out var b))
        {
            Console.WriteLine("Invalid value for b");
        }
        
        Console.WriteLine($"součet: {a + b}");
        Console.WriteLine($"rozdíl: {a - b}");
        Console.WriteLine($"součin: {a * b}");
        Console.WriteLine($"podíl: {a / b}");
    }


    public static void Task02()
    {
        while (true)
        {
            Console.Write("Vložte text: ");
            var input = Console.ReadLine();
            string reversed = "";
            for (var i = input.Length - 1; i >= 0; i--)
            {
                reversed += input[i];
            }

            Console.WriteLine($"Palindrom: {input == reversed}");
        }
    }


    public static void Task03()
    {
        int n = 100;
        List<int> numbersList = new List<int>();
        numbersList.Add(0);
        numbersList.Add(1);
        for (int i = 0; i < n; i++)
        {
            numbersList.Add(numbersList[i] + numbersList[i + 1]);
        }

        Console.WriteLine(numbersList[n - 1]);
    }
}