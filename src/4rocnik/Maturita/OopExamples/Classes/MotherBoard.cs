using OopExamples.Interfaces;

namespace OopExamples.Classes;

public class MotherBoard:IMotherBoard
{
    public string Name { get; set; }

    public MotherBoard(string name)
    {
        Name = name;
    }
}