namespace ThreadingLesson;

public class ImageProcessing
{
    private static readonly uint _imageCount = 50;
    
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