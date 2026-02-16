using OopExamples.Interfaces;

namespace OopExamples.Classes;

public class Person:IPerson
{
    public string Name { get; set; }

    public Person(string name)
    {
        Name = name;
    }
}