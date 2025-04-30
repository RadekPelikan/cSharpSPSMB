namespace ThreadingLesson;

class ThreadPoolExample
{
    static void Work(object state)
    {
        Console.WriteLine("Work on ThreadPool");
    }

    static void Run()
    {
        ThreadPool.QueueUserWorkItem(Work);
        Console.WriteLine("Main thread done.");
        Thread.Sleep(1000);
    }
}