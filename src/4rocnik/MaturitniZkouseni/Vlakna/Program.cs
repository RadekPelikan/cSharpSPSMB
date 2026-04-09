// See https://aka.ms/new-console-template for more information

Console.WriteLine("Hello, World!");

// ukazat jak vyuzit 100% CPU za pomoci vlaken
// ukazat rozdily mezi Thread, ThreadPool, Task 
// ukazat jak funguje lock

object myLock = new ThreadState(10);
var numbers = new List<string>();
int workCounter = 0;

void DoWork()
{
    int wokerId = workCounter++;

    var a = 0;
    for (int i = 0; i < 10e8 / 2; i++)
    {
        if (i % 10e7 * 2 == 0)
        {
            // lock (myLock)
            // {
            numbers.Add($"{wokerId}_{i}");
            // }

            Console.WriteLine($"worker {wokerId}: {i}");
        }

        a += 1;
        // Console.WriteLine("Working");
    }

    Console.WriteLine(a);
}

for (int i = 0; i < 32; i++)
{
    new Thread(DoWork).Start();
}


void TheadPoolWork(ThreadState state)
{
    var a = 0;
    for (int i = 0; i < state.Count; i++)
    {
        if (i % 10e4 == 0)
        {
            Console.WriteLine($"worker {workCounter}: {i}");
        }

        a += 1;
        // Console.WriteLine("Working");
    }

    Console.WriteLine(a);
}


// for (int i = 0; i < 32; i++)
// {
//     ThreadPool.QueueUserWorkItem(TheadPoolWork, new ThreadState(10e10), false);
// }

// Console.WriteLine(ThreadPool.PendingWorkItemCount);


Task DoWorkAsync()
{
    workCounter++;
    var a = 0;
    for (int i = 0; i < 10e8; i++)
    {
        if (i % 10e4 == 0)
        {
            Console.WriteLine($"worker {workCounter}: {i}");
        }

        a += 1;
        // Console.WriteLine("Working");
    }

    Console.WriteLine(a);
    return Task.CompletedTask;
}

// Task.WhenAll([
//     DoWorkAsync(),
//     DoWorkAsync(),
//     DoWorkAsync(),
//     DoWorkAsync(),
//     DoWorkAsync(),
//     DoWorkAsync(),
// ]);
Console.ReadKey();


foreach (var number in numbers)
{
    Console.WriteLine(number);
}

Console.WriteLine(numbers.Count);

public record ThreadState(double Count);