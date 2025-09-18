using OopExamples.Interfaces;

namespace OopExamples.Tests;

public class NewComputerTests
{
    protected readonly IComputer Computer;
    protected readonly IPerson Person;
    protected readonly ICompany Company;

    public NewComputerTests()
    {
        // Create instance of interfaces, using your implementation
        Computer = null;
        Person = null;
        Company = null;
        
        // Do not touch this
        Computer = Computer ?? throw new System.NotImplementedException($"{nameof(Computer)} not implemented");
        Person = Person ?? throw new System.NotImplementedException($"{nameof(Person)} not implemented");
        Company = Company ?? throw new System.NotImplementedException($"{nameof(Company)} not implemented");
    }
}