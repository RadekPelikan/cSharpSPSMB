using OopExamples.Interfaces;
using OopExamples.Interfaces.Exceptions;

namespace OopExamples.Classes;

public class ComputerBuilder:IComputerBuilder
{
    private IMotherBoard _motherBoard;
    private IComputerConfiguration _computerConfiguration;
    private IPowerSupply _powerSupply;
    private ICase _case;
    private IMonitor[] _monitors;
    private IPerson _owner;
    private IComputer _computer;
    private ICPU _cpu;
    private IGPU _gpu;
    private IRAM _ram;
    
    
    public IComputer BuildFromConfiguration(IComputerConfiguration configuration)
    {
        return this
            .AddMotherBoard(configuration.MotherBoard)
            .AddCPU(configuration.Cpu)
            .AddGPU(configuration.Gpu)
            .AddRam(configuration.Ram)
            .AddPowerSupply(configuration.PowerSupply)
            .AddCase(configuration.Case)
            .Build();
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
        if (_motherBoard == null ||
            _cpu == null ||
            _gpu == null ||
            _ram == null ||
            _powerSupply == null ||
            _case == null)
        {
            throw new ComputerMissingComponentsException();
        }

        return new Computer
        {
            MotherBoard = _motherBoard,
            Cpu = _cpu,
            Gpu = _gpu,
            Ram = _ram,
            PowerSupply = _powerSupply,
            Case = _case,
        };
    }
}