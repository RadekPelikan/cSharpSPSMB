public interface ICPU
{
    string Model { get; }
    int Cores { get; }
    float FrequencyGHz { get; }
}