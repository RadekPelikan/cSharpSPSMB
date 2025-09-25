using OopExamples.Interfaces;
using OopExamples.Interfaces.Exceptions;

namespace OopExamples.classes;

public class ComputerBuilder : IComputerBuilder
{
    private Computer _computer;
    private int _count;
    
    public ComputerBuilder()
    {
        _computer = new Computer();
    }
    
    public IComputer BuildFromConfiguration(IComputerConfiguration configuration)
    {
        return new Computer().BuildNewComputer(configuration);
    }

    public IComputerBuilder AddMotherBoard(IMotherBoard motherBoard)
    {
        if (_computer.MotherBoard == null) _count++;
        _computer.MotherBoard = motherBoard;
        return this;
    }

    public IComputerBuilder AddCPU(ICPU cpu)
    {
        if (_computer.Cpu == null) _count++;
        _computer.Cpu = cpu;
        return this;
    }

    public IComputerBuilder AddGPU(IGPU gpu)
    {
        if (_computer.Gpu == null) _count++;
        _computer.Gpu = gpu;
        return this; 
    }

    public IComputerBuilder AddRam(IRAM ram)
    {
        if (_computer.Ram == null) _count++;
        _computer.Ram = ram;
        return this;
    }

    public IComputerBuilder AddPowerSupply(IPowerSupply powerSupply)
    {
        if (_computer.PowerSupply == null) _count++;
        _computer.PowerSupply = powerSupply;
        return this;
    }

    public IComputerBuilder AddCase(ICase pcCase)
    {
        if (_computer.Case == null) _count++;
        _computer.Case = pcCase;
        return this;
    }

    public IComputer Build()
    {
        if (_count < 6) throw new ComputerMissingComponentsException();
        Console.WriteLine(_count);
        return _computer;
    }
}