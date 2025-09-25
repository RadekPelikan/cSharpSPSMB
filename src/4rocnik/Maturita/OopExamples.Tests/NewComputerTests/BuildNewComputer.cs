using OopExamples.Interfaces.Exceptions;

namespace OopExamples.Tests;

public class BuildNewComputer : NewComputerTests
{
    [Fact]
    public void ValidComputer_IsValid()
    {
        var computer = Builder
            .AddMotherBoard(ComputerConfiguration.MotherBoard)
            .AddCPU(ComputerConfiguration.Cpu)
            .AddGPU(ComputerConfiguration.Gpu)
            .AddRam(ComputerConfiguration.Ram)
            .AddPowerSupply(ComputerConfiguration.PowerSupply)
            .AddCase(ComputerConfiguration.Case)
            .Build();
        IsValidComputer(computer);
    }

    [Fact]
    public void ComputerWithNothing_ThrowsMissingComponents()
    {
        Assert.Throws<ComputerMissingComponentsException>(() =>
        {
            var computer = Builder
                .Build();
        });
    }

    [Fact]
    public void ComputerWithOnlyCpu_ThrowsMissingComponents()
    {
        Assert.Throws<ComputerMissingComponentsException>(() =>
        {
            var computer = Builder
                .AddCPU(ComputerConfiguration.Cpu)
                .Build();
        });
    }

    [Fact]
    public void ComputerWithOnlyGpu_ThrowsMissingComponents()
    {
        Assert.Throws<ComputerMissingComponentsException>(() =>
        {
            var computer = Builder
                .AddGPU(ComputerConfiguration.Gpu)
                .Build();
        });
    }

    [Fact]
    public void ComputerWithOnlyRam_ThrowsMissingComponents()
    {
        Assert.Throws<ComputerMissingComponentsException>(() =>
        {
            var computer = Builder
                .AddRam(ComputerConfiguration.Ram)
                .Build();
        });
    }

    [Fact]
    public void ComputerWithOnlyPowerSupply_ThrowsMissingComponents()
    {
        Assert.Throws<ComputerMissingComponentsException>(() =>
        {
            var computer = Builder
                .AddPowerSupply(ComputerConfiguration.PowerSupply)
                .Build();
        });
    }

    [Fact]
    public void ComputerWithOnlyCase_ThrowsMissingComponents()
    {
        Assert.Throws<ComputerMissingComponentsException>(() =>
        {
            var computer = Builder
                .AddCase(ComputerConfiguration.Case)
                .Build();
        });
    }
}