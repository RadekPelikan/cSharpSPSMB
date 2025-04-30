namespace ThreadingLesson;

class ThreadPoolExample
{
    private static int threadNumber = 0;
    private static double number = 1e10;
    
    static void Work(object state)
    {
        var threadNumber = ThreadPoolExample.threadNumber++;
        for (double i = 0; i < number; i++)
        {
            if (i % 200000000 == 0)
            {
                Console.WriteLine($"ThreadPool {threadNumber} Work: {i / 200000000}");
            }
        }
        Console.WriteLine($"Work on ThreadPool");
    }

    public static void Run()
    {
        Console.WriteLine("TEST");
        var threadCount = 10;
        for (var i = 0; i < threadCount; i++)
        {
            ThreadPool.QueueUserWorkItem(Work);
        }
        Console.WriteLine($"Main thread done.");
        Thread.Sleep(2000000);
    }
}