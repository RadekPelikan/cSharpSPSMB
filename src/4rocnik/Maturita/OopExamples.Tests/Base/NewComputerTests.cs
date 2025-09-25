using OopExamples.Interfaces;

namespace OopExamples.Tests;

public class NewComputerTests
{
    protected readonly IComputerConfiguration ComputerConfiguration;
    protected readonly IComputer Computer;
    protected readonly IComputerBuilder Builder;
    protected readonly IPerson Person;
    protected readonly ICompany Company;

    public NewComputerTests()
    {
        // tests
        // Create instance of interfaces, using your implementation
        ComputerConfiguration = null;
        Builder = null;
        Computer = null;
        Person = null;
        Company = null;
        
        // Do not touch this
        Computer = Computer ?? throw new System.NotImplementedException($"{nameof(Computer)} not implemented");
        Person = Person ?? throw new System.NotImplementedException($"{nameof(Person)} not implemented");
        Company = Company ?? throw new System.NotImplementedException($"{nameof(Company)} not implemented");
    }

    protected void IsValidComputer(IComputer computer)
    {
        Assert.NotNull(Computer.MotherBoard);
        Assert.NotNull(Computer.Gpu);
        Assert.NotNull(Computer.Ram);
        Assert.NotNull(Computer.PowerSupply);
        Assert.NotNull(Computer.Case);
    }
}