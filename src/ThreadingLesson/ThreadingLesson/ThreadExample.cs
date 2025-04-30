namespace ThreadingLesson;

class ThreadExample
{
    static void PrintNumbers()
    {
        for (int i = 0; i < 5; i++)
        {
            Console.WriteLine($"From thread: {i}");
            // Thread.Sleep(500);
        }
    }

    public static void Run()
    {
        Thread t = new Thread(PrintNumbers);
        t.Start();

        for (int i = 0; i < 5; i++)
        {
            Console.WriteLine($"From main: {i}");
            // Thread.Sleep(500);
        }
    }
}
