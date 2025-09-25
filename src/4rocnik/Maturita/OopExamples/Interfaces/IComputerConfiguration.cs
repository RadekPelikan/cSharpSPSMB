namespace OopExamples.Interfaces;

public interface IComputerConfiguration
{
    IMotherBoard MotherBoard { get; set; }
    ICPU Cpu { get; set; }
    IGPU Gpu { get; set; }
    IRAM Ram { get; set; }
    IPowerSupply PowerSupply { get; set; }
    ICase Case { get; set; }
}