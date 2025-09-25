using OopExamples.Interfaces;

namespace OopExamples.Classes;

public class ComputerBuilder:IComputerBuilder
{
    private IMotherBoard _motherBoard;
    private IComputerConfiguration _computerConfiguration;
    private IPowerSupply _powerSupply;
    private ICase _case;
    private IMonitor[] _monitors;
    
    public IComputer BuildFromConfiguration(IComputerConfiguration configuration)
    {
        throw new NotImplementedException();
    }

    public IComputerBuilder AddMotherBoard(IMotherBoard motherBoard)
    {
        _computerConfiguration.MotherBoard = motherBoard;
        return this;
    }

    public IComputerBuilder AddCPU(ICPU cpu)
    {
        _computerConfiguration.Cpu = cpu;
        return this;
    }

    public IComputerBuilder AddGPU(IGPU gpu)
    {
        _computerConfiguration.Gpu = gpu;
        return this;
    }

    public IComputerBuilder AddRam(IRAM ram)
    {
        _computerConfiguration.Ram = ram;
        return this;
    }

    public IComputerBuilder AddPowerSupply(IPowerSupply powerSupply)
    {
        _computerConfiguration.PowerSupply = powerSupply;
        return this;
    }

    public IComputerBuilder AddCase(ICase pcCase)
    {
         _computerConfiguration.Case = pcCase;
        return this;
    }

    public IComputer Build()
    {
        throw new NotImplementedException();
    }
}