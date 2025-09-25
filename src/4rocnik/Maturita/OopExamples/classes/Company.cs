using OopExamples.Interfaces;

namespace OopExamples.classes;

public class Company : ICompany
{
    public string Name { get; set; }
    public IPerson Owner { get; set; }
}