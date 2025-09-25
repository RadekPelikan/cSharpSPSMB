using OopExamples.Interfaces;

namespace OopExamples.Classes;

public class GPU:IGPU
{
    public string Name { get; set; }
    public GPUConnector[] Connectors { get; }
    public IComputer? Computer { get; }
    public GPUConnector[] AvailableConnectors { get; }
    public IMonitor[] ConnectedMonitors { get; }
    public bool IsUsed { get; }
    public void Connect(IComputer computer)
    {
        
    }

    public void Disconnect()
    {
        throw new NotImplementedException();
    }

    public void ConnectMonitor(IMonitor monitor)
    {
        throw new NotImplementedException();
    }

    public void DisconnectMonitor(IMonitor monitor)
    {
        throw new NotImplementedException();
    }
}