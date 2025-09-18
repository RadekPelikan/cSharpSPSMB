public interface IGPU
{
    string Model { get; }
    int MemoryGB { get; }
}

public class GPU : IGPU
{
    public string Model { get; private set; }
    public int MemoryGB { get; private set; }

    public GPU(string model, int memoryGB)
    {
        Model = model;
        MemoryGB = memoryGB;
    }

    public override string ToString()
    {
        return $"{Model}, {MemoryGB}GB VRAM";
    }
}