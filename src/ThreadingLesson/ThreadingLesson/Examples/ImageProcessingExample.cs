using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;

namespace ThreadingLesson;

public class ImageProcessingExample
{
    public void Run()
    {
        using (Image image = Image.Load("input.jpg"))
        {
            image.Mutate(x => x.Grayscale());
            image.Save("output.jpg");
        }
    }
}