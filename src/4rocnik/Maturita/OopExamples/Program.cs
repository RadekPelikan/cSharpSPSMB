// See https://aka.ms/new-console-template for more information


using OopExamples.Interfaces;

IComputerBuilder builder;

var computer = builder
    .AddCase(null)
    .AddCPU(null)
    .AddGPU(null)
    .AddCPU(null)
    .AddMotherBoard(null)
    .AddPowerSupply(null)
    .AddRam(null)
    .Build();