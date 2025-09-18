public interface IRAM
{
    int CapacityGB { get; }
    int SpeedMHz { get; }
}

public class RAM : IRAM
{
    public int CapacityGB { get; private set; }
    public int SpeedMHz { get; private set; }

    public RAM(int capacityGB, int speedMHz)
    {
        CapacityGB = capacityGB;
        SpeedMHz = speedMHz;
    }

    public override string ToString()
    {
        return $"{CapacityGB}GB @ {SpeedMHz}MHz";
    }
}