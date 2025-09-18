public interface IMotherBoard
{
    string Model { get; }
    string Socket { get; }
}

public class MotherBoard : IMotherBoard
{
    public string Model { get; private set; }
    public string Socket { get; private set; }

    public MotherBoard(string model, string socket)
    {
        Model = model;
        Socket = socket;
    }

    public override string ToString()
    {
        return $"{Model}, Socket: {Socket}";
    }
}