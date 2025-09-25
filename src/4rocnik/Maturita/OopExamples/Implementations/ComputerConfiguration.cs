using OopExamples.Interfaces;

namespace OopExamples.Implementations;

public class ComputerConfiguration : IComputerConfiguration
{
    public IMotherBoard MotherBoard { get; set; }
    public ICPU Cpu { get; set; }
    public IGPU Gpu { get; set; }
    public IRAM Ram { get; set; }
    public IPowerSupply PowerSupply { get; set; }
    public ICase Case { get; set; }
}