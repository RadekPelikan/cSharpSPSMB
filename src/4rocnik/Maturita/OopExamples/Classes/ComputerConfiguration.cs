using OopExamples.Interfaces;

namespace OopExamples.Classes;

public class ComputerConfiguration: IComputerConfiguration
{
    public IMotherBoard MotherBoard { get; set; }
    public ICPU Cpu { get; set; }
    public IGPU Gpu { get; set; }
    public IRAM Ram { get; set; }
    public IPowerSupply PowerSupply { get; set; }
    public ICase Case { get; set; }

    public ComputerConfiguration(IMotherBoard motherBoard, ICPU cpu, IGPU gpu, IRAM ram, IPowerSupply powerSupply, ICase @case)
    {
        MotherBoard = motherBoard;
        Cpu = cpu;
        Gpu = gpu;
        Ram = ram;
        PowerSupply = powerSupply;
        Case = @case;
    }
}