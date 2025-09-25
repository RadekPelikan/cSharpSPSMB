using OopExamples.Interfaces;

namespace OopExamples.Classes;

public class CPU: IComputer
{
    public IEntity Owner { get; init; }
    public IMotherBoard MotherBoard { get; init; }
    public ICPU Cpu { get; init; }
    public IGPU Gpu { get; init; }
    public IRAM Ram { get; init; }
    public IPowerSupply PowerSupply { get; init; }
    public ICase Case { get; init; }
    public IMonitor[] Monitors { get; }
    public bool IsOn { get; }
    public bool IsPersonalPC { get; }
    public bool IsCompanyPC { get; }

    public CPU(IEntity owner, IMotherBoard motherBoard, ICPU cpu, IGPU gpu, IRAM ram, IPowerSupply powerSupply, ICase @case, IMonitor[] monitors, bool isOn, bool isPersonalPc, bool isCompanyPc)
    {
        Owner = owner;
        MotherBoard = motherBoard;
        Cpu = cpu;
        Gpu = gpu;
        Ram = ram;
        PowerSupply = powerSupply;
        Case = @case;
        Monitors = monitors;
        IsOn = isOn;
        IsPersonalPC = isPersonalPc;
        IsCompanyPC = isCompanyPc;
    }

    public void PowerUp()
    {
        
    }

    public void ShutDown()
    {
        throw new NotImplementedException();
    }

    public void PressPowerButton()
    {
        throw new NotImplementedException();
    }

    public void Print(string text)
    {
        throw new NotImplementedException();
    }

    public float Compute(string equation)
    {
        throw new NotImplementedException();
    }

    public IComputer BuildNewComputer(IComputerConfiguration configuration)
    {
        throw new NotImplementedException();
    }
}