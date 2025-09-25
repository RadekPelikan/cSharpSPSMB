namespace OopExamples.Interfaces;

public interface IGPU : IComponent
{
    GPUConnector[] Connectors { get; }
    IComputer? Computer { get; }
    GPUConnector[] AvailableConnectors { get; }
    IMonitor[] ConnectedMonitors { get; }

    /// <summary>
    /// If GPU is used by the computer, if Computer is null, then GPU is not inserted in any PC
    /// </summary>
    bool IsUsed { get; }
    
    /// <summary>
    /// If GPU is already connected to a computer, throw an ComponentAlreadyConnectedException
    ///
    /// if it isn't, set the computer to null
    /// </summary>
    /// <param name="computer"></param>
    void Connect(IComputer computer);
    
    /// <summary>
    /// If GPU is not connected to any computer, throw an ComponentNotConnectedException
    ///
    /// If it is, set the computer
    /// </summary>
    void Disconnect();    
    
    /// <summary>
    /// If that monitor is already connected to the Computer, then throw ComponentAlreadyConnectedException
    ///
    /// if there isn't a available connector, that the monitor has, then throw InvalidConnectorException
    ///
    /// If there is available monitor connector in the GPU connectors, then connect the monitors
    /// </summary>
    /// <param name="monitor"></param>
    void ConnectMonitor(IMonitor monitor);
    
    /// <summary>
    /// If Connector is not connected, then throw ComponentNotConnectedException
    ///
    /// If it is connected, then disconnect the monitor
    /// </summary>
    /// <param name="monitor"></param>
    void DisconnectMonitor(IMonitor monitor);
}