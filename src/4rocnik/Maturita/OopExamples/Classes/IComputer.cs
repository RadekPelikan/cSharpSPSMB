public interface IComputer
{
    ICPU CPU { get; }
    IGPU GPU { get; }
    IRAM RAM { get; }
    IMotherBoard MotherBoard { get; }
    IPowerSupply PowerSupply { get; }
    ICase Case { get; }
}

public class Computer : IComputer
{
    public ICPU CPU { get; private set; }
    public IGPU GPU { get; private set; }
    public IRAM RAM { get; private set; }
    public IMotherBoard MotherBoard { get; private set; }
    public IPowerSupply PowerSupply { get; private set; }
    public ICase Case { get; private set; }

    public Computer(ICPU cpu, IGPU gpu, IRAM ram, IMotherBoard motherBoard, IPowerSupply powerSupply, ICase pcCase)
    {
        CPU = cpu;
        GPU = gpu;
        RAM = ram;
        MotherBoard = motherBoard;
        PowerSupply = powerSupply;
        Case = pcCase;
    }

    public override string ToString()
    {
        return $"Computer:\nCPU: {CPU}\nGPU: {GPU}\nRAM: {RAM}\nMotherBoard: {MotherBoard}\nPower: {PowerSupply}\nCase: {Case}";
    }
}