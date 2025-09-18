public interface IComputerBuilder
{
    IComputer Build();
}

public class ComputerBuilder : IComputerBuilder
{
    public IComputer Build()
    {
        var cpu = new CPU("Intel i9-13900K", 24, 5.8f);
        var gpu = new GPU("NVIDIA RTX 4090", 24);
        var ram = new RAM(64, 6000);
        var mb = new MotherBoard("ASUS ROG STRIX Z790-E", "LGA1700");
        var psu = new PowerSupply(1200);
        var pcCase = new Case("NZXT H710", "Mid Tower");

        return new Computer(cpu, gpu, ram, mb, psu, pcCase);
    }
}