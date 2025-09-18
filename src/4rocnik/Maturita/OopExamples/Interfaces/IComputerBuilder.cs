namespace OopExamples.Interfaces;

public interface IComputerBuilder
{
    static abstract IComputer BuildFromConfiguration(IComputerConfiguration configuration);
    static abstract IComputerBuilder AddMotherBoard(IMotherBoard motherBoard);
    static abstract IComputerBuilder AddCPU(ICPU cpu);
    static abstract IComputerBuilder AddGPU(IGPU gpu);
    static abstract IComputerBuilder AddRam(IRAM ram);
    static abstract IComputerBuilder AddPowerSupply(IPowerSupply powerSupply);
    static abstract IComputerBuilder AddCase(ICase pcCase);
    static abstract IComputer Build();
}