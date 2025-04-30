namespace ThreadingLesson;

class TaskExample
{
    public static async Task Run()
    {
        Task t1 = Task.Run(() => DoWork("Task 1"));
        Task t2 = Task.Run(() => DoWork("Task 2"));

        await Task.WhenAll(t1, t2);
        Console.WriteLine("All tasks completed.");
    }

    static void DoWork(string name)
    {
        for (int i = 0; i < 3; i++)
        {
            Console.WriteLine($"{name} - {i}");
            Thread.Sleep(500);
        }
    }
}