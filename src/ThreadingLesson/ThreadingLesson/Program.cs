



using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;
using ThreadingLesson;

void ProcessImage()
{
    var imgPath = @"C:\Users\pelikan\Desktop\cSharpSPSMB\src\ThreadingLesson\ThreadingLesson\img";
    var processedPath = @"C:\Users\pelikan\Desktop\cSharpSPSMB\src\ThreadingLesson\ThreadingLesson\img\processed";
    var filename = @"image01.jpg";
    var outfile = @"image01.grayscale.jpg";
    using (Image image = Image.Load(Path.Combine(imgPath, filename)))
    {
        image.Mutate(x => x.Grayscale());
        image.Save(Path.Combine(processedPath, outfile));
    }
}

await ImageProcessingDone.RunSameImage();

