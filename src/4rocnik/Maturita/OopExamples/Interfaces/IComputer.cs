namespace OopExamples.Interfaces;

public interface IComputer
{
    IEntity Owner { get; init; }
    IMotherBoard MotherBoard { get; init; }
    ICPU Cpu { get; init; }
    IGPU Gpu { get; init; }
    IRAM Ram { get; init; }
    IPowerSupply PowerSupply { get; init; }
    ICase Case { get; init; }
    IMonitor[] Monitors { get; init; }
    
    bool IsOn { get; }
    bool IsPersonalPC { get; }
    bool IsCompanyPC { get; }
    
    void PowerUp();
    void ShutDown();
    void PressPowerButton();
    void Print(string text);
    float Compute(string equation);
    IComputer BuildNewComputer(IComputerConfiguration configuration);
}