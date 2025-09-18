public class CPU : ICPU
{
    public string Model { get; private set; }
    public int Cores { get; private set; }
    public float FrequencyGHz { get; private set; }

    public CPU(string model, int cores, float frequencyGHz)
    {
        Model = model;
        Cores = cores;
        FrequencyGHz = frequencyGHz;
    }

    public override string ToString()
    {
        return $"{Model}, {Cores} cores, {FrequencyGHz} GHz";
    }
}