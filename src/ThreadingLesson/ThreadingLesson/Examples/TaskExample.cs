namespace ThreadingLesson;

class TaskExample
{
    public static async Task Run()
    {
        List<Task> tasks = new List<Task>();
        var count = 100;
        for (int i = 0; i < count; i++)
        {
            var i1 = i;
            tasks.Add(Task.Run(() => DoWork($"Task {i1}")));
        }

        await Task.WhenAll(tasks);
        Console.WriteLine("All tasks completed.");
    }

    static void DoWork(string name)
    {
        for (int i = 0; i < 1e10; i++)
        {
            Console.WriteLine($"thread: {name} - value: {i}");
            // Thread.Sleep(500);
        }
    }
}