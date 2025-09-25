using OopExamples.Interfaces;

namespace OopExamples.Classes;

public class Company: ICompany
{
    public string Name { get; set; }
    public IPerson Owner { get; set; }
}
