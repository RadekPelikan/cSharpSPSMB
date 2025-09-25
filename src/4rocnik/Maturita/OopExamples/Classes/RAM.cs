using OopExamples.Interfaces;

namespace OopExamples.Classes;

public class RAM:IRAM
{
    public string Name { get; set; }

    public RAM(string name)
    {
        Name = name;
    }
}