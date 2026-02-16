using OopExamples.Interfaces;

namespace OopExamples.Classes;

public class CPU: ICPU
{
    public string Name { get; set; }

    public CPU(string name)
    {
        Name = name;
    }
}