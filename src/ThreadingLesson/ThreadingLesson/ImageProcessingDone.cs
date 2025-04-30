using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;

namespace ThreadingLesson;

public class ImageProcessingDone
{
    private static readonly uint _imageCount = 5;

    public static async Task RunSameImage()
    {
        var imgPath = @"C:\Users\pelikan\Desktop\cSharpSPSMB\src\ThreadingLesson\ThreadingLesson\img\image01.jpg";
        DateTime start, end;

        start = DateTime.Now;
        ProcessImageParallel(imgPath);
        end = DateTime.Now;
        var parallelElapsed = end - start;


        Console.WriteLine($" ==== Parralel Time Elapsed: {parallelElapsed} ==== ");
        start = DateTime.Now;
        await ProcessImageAsync(imgPath);
        end = DateTime.Now;
        var asyncElapsed = end - start;

        Console.WriteLine($" ==== Async Time Elapsed: {asyncElapsed} ==== ");
        Console.WriteLine("\n\n\n");
        Console.WriteLine($" ==== Parralel Time Elapsed: {parallelElapsed} ==== ");
        Console.WriteLine($" ==== Async Time Elapsed: {asyncElapsed} ==== ");
    }

    public static async Task RunMultipleImages()
    {
        var imagePaths = new List<string>()
        {
            @"C:\Users\pelikan\Desktop\cSharpSPSMB\src\ThreadingLesson\ThreadingLesson\img\image01.jpg",
            @"C:\Users\pelikan\Desktop\cSharpSPSMB\src\ThreadingLesson\ThreadingLesson\img\image02.jpg",
            @"C:\Users\pelikan\Desktop\cSharpSPSMB\src\ThreadingLesson\ThreadingLesson\img\image03.jpg",
            @"C:\Users\pelikan\Desktop\cSharpSPSMB\src\ThreadingLesson\ThreadingLesson\img\image04.jpg",
            @"C:\Users\pelikan\Desktop\cSharpSPSMB\src\ThreadingLesson\ThreadingLesson\img\image05.jpg",
        };
        DateTime start, end;

        start = DateTime.Now;
        ProcessImagesParallel(imagePaths);
        end = DateTime.Now;
        var parallelElapsed = end - start;


        Console.WriteLine($" ==== Parralel Time Elapsed: {parallelElapsed} ==== ");
        start = DateTime.Now;
        await ProcessImagesAsync(imagePaths);
        end = DateTime.Now;
        var asyncElapsed = end - start;

        Console.WriteLine($" ==== Async Time Elapsed: {asyncElapsed} ==== ");
        Console.WriteLine("\n\n\n");
        Console.WriteLine($" ==== Parralel Time Elapsed: {parallelElapsed} ==== ");
        Console.WriteLine($" ==== Async Time Elapsed: {asyncElapsed} ==== ");
        
    }

    private static void ProcessImagesParallel(List<string> imagePaths)
    {
        Parallel.ForEach(imagePaths, imagePath =>
        {
            var extension = Path.GetExtension(imagePath);
            var outfilename = string.Join("", imagePath.Split(".").SkipLast(1));
            var outfile = $"{outfilename}.processed{Interlocked.Increment(ref outFileCounter):D2}.parallel{extension}";
            outFileCounter++;
            ProcessImage(imagePath, outfile).Wait();
        });
    }

    private static async Task ProcessImagesAsync(List<string> imagePaths)
    {
        foreach (var imagePath in imagePaths)
        {
            var extension = Path.GetExtension(imagePath);
            var outfilename = string.Join("", imagePath.Split(".").SkipLast(1));
            var outfile = $"{outfilename}.processed{outFileCounter++:D2}.async{extension}";
            await ProcessImage(imagePath, outfile);
        }
    }

    /// <summary>
    /// Method will create multiple threads, thread for each processed image
    /// Parallelism example
    /// </summary>
    /// <param name="imagePath"></param>
    public static void ProcessImageParallel(string imagePath)
    {
        var extension = Path.GetExtension(imagePath);
        var outfilename = string.Join("", imagePath.Split(".").SkipLast(1));
        Parallel.For(0, (int)_imageCount, i =>
        {
            var outfile = $"{outfilename}.processed{Interlocked.Increment(ref outFileCounter):D2}.parallel{extension}";
            outFileCounter++;
            ProcessImage(imagePath, outfile).Wait();
        });
        // var tasks = new List<Task>();
        // for (int i = 0; i < _imageCount; i++)
        // {
        //     var outfile = $"{outfilename}.processed{outFileCounter++:D2}.async{extension}";
        //     tasks.Add(Task.Run(() => ProcessImage(imagePath, outfile)));
        // }
        // Task.WhenAll(tasks);
    }

    /// <summary>
    /// Method will run each file processing on different task
    /// Concurrency example
    /// </summary>
    /// <param name="imagePath"></param>
    public static async Task ProcessImageAsync(string imagePath)
    {
        var extension = Path.GetExtension(imagePath);
        var outfilename = string.Join("", imagePath.Split(".").SkipLast(1));
        for (int i = 0; i < _imageCount; i++)
        {
            var outfile = $"{outfilename}.processed{outFileCounter++:D2}.async{extension}";
            await ProcessImage(imagePath, outfile);
        }
    }


    private static uint outFileCounter = 0;
    private static async Task ProcessImage(string imagePath, string outFile)
    {
        var processedPath = @"C:\Users\pelikan\Desktop\cSharpSPSMB\src\ThreadingLesson\ThreadingLesson\img\processed";
        
        var filename = Path.GetFileName(outFile);
        Console.WriteLine($"{filename} : LOAD REQUESTED");

        using Image image = await Image.LoadAsync(imagePath);
        Console.WriteLine($"{filename} : LOADED");
        image.Mutate(x => x.Grayscale());
        Console.WriteLine($"{filename} : MUTATED");
        await image.SaveAsync(Path.Combine(processedPath, outFile));
        Console.WriteLine($"{filename} : SAVED");
    }
}