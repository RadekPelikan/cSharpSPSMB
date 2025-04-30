namespace ThreadingLesson;

public class ImageProcessing
{
    private static readonly uint _imageCount = 50;

    public static async Task Run()
    {
        var imgPath = @"C:\Users\pelikan\Desktop\cSharpSPSMB\src\ThreadingLesson\ThreadingLesson\img";
        DateTime start, end;
        
        start = DateTime.Now;
        await ProcessImageParallel(imgPath);
        end = DateTime.Now;
        var parallelElapsed = end - start;
        
        
        start = DateTime.Now;
        await ProcessImageAsync(imgPath);
        end = DateTime.Now;
        var asyncElapsed = end - start;

        Console.WriteLine($"Parralel Time Elapsed: {parallelElapsed}");
        Console.WriteLine($"Async Time Elapsed: {asyncElapsed}");
    }
    
    /// <summary>
    /// Method will create multiple threads, thread for each processed image
    /// Parallelism example
    /// </summary>
    /// <param name="imagePath"></param>
    public static async Task ProcessImageParallel(string imagePath)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Method will run each file processing on different task
    /// Concurrency example
    /// </summary>
    /// <param name="imagePath"></param>
    public static async Task ProcessImageAsync(string imagePath)
    {
        throw new NotImplementedException();
    }
}