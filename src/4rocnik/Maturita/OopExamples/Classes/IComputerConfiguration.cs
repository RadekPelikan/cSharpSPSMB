public interface IComputerConfiguration
{
    string CPUModel { get; }
    int CPUCores { get; }
    float CPUFrequencyGHz { get; }

    string GPUModel { get; }
    int GPUMemoryGB { get; }

    int RAMCapacityGB { get; }
    int RAMSpeedMHz { get; }

    string MotherBoardModel { get; }
    string MotherBoardSocket { get; }

    int PowerSupplyWattage { get; }

    string CaseModel { get; }
    string CaseSize { get; }
}

public class ComputerConfiguration : IComputerConfiguration
{
    public string CPUModel { get; private set; }
    public int CPUCores { get; private set; }
    public float CPUFrequencyGHz { get; private set; }

    public string GPUModel { get; private set; }
    public int GPUMemoryGB { get; private set; }

    public int RAMCapacityGB { get; private set; }
    public int RAMSpeedMHz { get; private set; }

    public string MotherBoardModel { get; private set; }
    public string MotherBoardSocket { get; private set; }

    public int PowerSupplyWattage { get; private set; }

    public string CaseModel { get; private set; }
    public string CaseSize { get; private set; }

    public ComputerConfiguration(
        string cpuModel, int cpuCores, float cpuFreq,
        string gpuModel, int gpuMem,
        int ramCap, int ramSpeed,
        string mbModel, string mbSocket,
        int psuWattage,
        string caseModel, string caseSize)
    {
        CPUModel = cpuModel;
        CPUCores = cpuCores;
        CPUFrequencyGHz = cpuFreq;

        GPUModel = gpuModel;
        GPUMemoryGB = gpuMem;

        RAMCapacityGB = ramCap;
        RAMSpeedMHz = ramSpeed;

        MotherBoardModel = mbModel;
        MotherBoardSocket = mbSocket;

        PowerSupplyWattage = psuWattage;

        CaseModel = caseModel;
        CaseSize = caseSize;
    }
}
