using OopExamples.Interfaces;

namespace OopExamples.Classes;

public class ComputerBuilder:IComputerBuilder
{
    public IComputer BuildFromConfiguration(IComputerConfiguration configuration)
    {
        throw new NotImplementedException();
    }

    public IComputerBuilder AddMotherBoard(IMotherBoard motherBoard)
    {
        throw new NotImplementedException();
    }

    public IComputerBuilder AddCPU(ICPU cpu)
    {
        throw new NotImplementedException();
    }

    public IComputerBuilder AddGPU(IGPU gpu)
    {
        throw new NotImplementedException();
    }

    public IComputerBuilder AddRam(IRAM ram)
    {
        throw new NotImplementedException();
    }

    public IComputerBuilder AddPowerSupply(IPowerSupply powerSupply)
    {
        throw new NotImplementedException();
    }

    public IComputerBuilder AddCase(ICase pcCase)
    {
        throw new NotImplementedException();
    }
}