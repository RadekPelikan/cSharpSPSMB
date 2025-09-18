namespace OopExamples.Interfaces;

public interface IComputerBuilder
{
    IComputer BuildFromConfiguration(IComputerConfiguration configuration);
    IComputerBuilder AddMotherBoard(IMotherBoard motherBoard);
    IComputerBuilder AddCPU(ICPU cpu);
    IComputerBuilder AddGPU(IGPU gpu);
    IComputerBuilder AddRam(IRAM ram);
    IComputerBuilder AddPowerSupply(IPowerSupply powerSupply);
    IComputerBuilder AddCase(ICase pcCase);
    IComputer Build();
}