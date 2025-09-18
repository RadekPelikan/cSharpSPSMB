namespace OopExamples.Interfaces;

public interface IComputer
{
    IEntity Owner { get; }
    IMotherBoard MotherBoard { get; }
    ICPU Cpu { get; }
    IGPU Gpu { get; }
    IRAM Ram { get; }
    IPowerSupply PowerSupply { get; }
    ICase Case { get; }
    IMonitor[] Monitors { get; }
    
    bool IsOn { get; }
    bool IsPersonalPC { get; }
    bool IsCompanyPC { get; }
    
    void PowerUp();
    void ShutDown();
    void PressPowerButton();
    void Print(string text);
    float Compute(string equation);
    void ChangeOwner(IEntity? newOwner);
    void RemoveOwner();
    IComputer BuildNewComputer(IComputerConfiguration configuration);
}