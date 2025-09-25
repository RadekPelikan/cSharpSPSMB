using OopExamples.Interfaces;
using OopExamples.Interfaces.Exceptions;

namespace OopExamples.classes;

public class GPU : IGPU
{
    public string Name { get; set; }
    public GPUConnector[] Connectors { get; init; }
    public IComputer? Computer { get; set; }
    public GPUConnector[] AvailableConnectors { get; }
    public IMonitor[] ConnectedMonitors { get; set; }
    public bool IsUsed { get; }
    public void Connect(IComputer computer)
    {
        if (Computer != null) throw new ComponentAlreadyConnectedException();
        Computer = computer;
    }

    public void Disconnect()
    {
        if (Computer == null) throw new ComponentNotConnectedException();
        Computer = null;
    }

    public void ConnectMonitor(IMonitor monitor)
    {
        IMonitor[] monitors = new IMonitor[ConnectedMonitors.Length + 1];
        for (int i = 0; i < monitors.Length; i++)
        {
            if(ConnectedMonitors[i].Equals(monitor)) throw new ComponentAlreadyConnectedException();
            monitors[i] = ConnectedMonitors[i];
        }
        monitors[ConnectedMonitors.Length] = monitor;
        ConnectedMonitors = monitors;
    }

    public void DisconnectMonitor(IMonitor monitor)
    {
        IMonitor[] monitors = new IMonitor[ConnectedMonitors.Length - 1];
        int d = 0;
        for (int i = 0; i < ConnectedMonitors.Length; i++)
        {
            if (ConnectedMonitors[i].Equals(monitor))
            {
                d--;
            }
            else
            {
                monitors[i + d] = ConnectedMonitors[i];
            }
        }
        if(d == 0) throw new ComponentNotConnectedException();
        ConnectedMonitors = monitors;
    }
}