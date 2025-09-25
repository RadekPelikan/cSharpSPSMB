using System.Reflection;
using OopExamples.Interfaces;
using OopExamples.Tests.Extensions;

namespace OopExamples.Tests;

public class NewComputerTests
{
    protected readonly IComputerConfiguration ComputerConfiguration;
    protected readonly IComputer Computer;
    protected readonly IComputerBuilder Builder;
    protected readonly IPerson Person;
    protected readonly ICompany Company;
    protected readonly IEnumerable<IMonitor> Monitors;

    private readonly List<GPUConnector> MonitorConnectors =
    [
        GPUConnector.AVG,
        GPUConnector.AVG,
        GPUConnector.DVI,
        GPUConnector.HDMI
    ];

    private new Dictionary<string, object> InitProperties => new()
    {
        { "Name", "test name" },
    };

    public NewComputerTests()
    {
        ComputerConfiguration = InstantiateImplementation<IComputerConfiguration>(
            InitProperties
                .AddProperty(nameof(ComputerConfiguration.MotherBoard), 
                    InstantiateImplementation<IMotherBoard>(InitProperties))
                .AddProperty(nameof(ComputerConfiguration.Cpu), 
                    InstantiateImplementation<ICPU>(InitProperties))
                .AddProperty(nameof(ComputerConfiguration.Gpu), 
                    InstantiateImplementation<IGPU>(InitProperties))
                .AddProperty(nameof(ComputerConfiguration.Ram), 
                    InstantiateImplementation<IRAM>(InitProperties))
                .AddProperty(nameof(ComputerConfiguration.PowerSupply), 
                    InstantiateImplementation<IPowerSupply>(InitProperties))
                .AddProperty(nameof(ComputerConfiguration.Case), 
                    InstantiateImplementation<ICase>(InitProperties))
            );
        
        
        Builder = InstantiateImplementation<IComputerBuilder>(
            InitProperties);
        Computer = Builder.BuildFromConfiguration(ComputerConfiguration);
        Person = InstantiateImplementation<IPerson>(
            InitProperties);
        Company = InstantiateImplementation<ICompany>(
            InitProperties
                .AddProperty(nameof(ICompany.Owner), "Test owner")
            );
        
        // For Monitors, create one instance per connector
        Monitors = MonitorConnectors.Select(connector =>
            InstantiateImplementation<IMonitor>(
                InitProperties
                    .AddProperty(nameof(IMonitor.Connector), connector)
            )
        ).ToList();
    }

    [Fact]
    public void IsValidSetup()
    {
        Assert.NotNull(ComputerConfiguration);
        Assert.NotNull(Builder);
        Assert.NotNull(Computer);
        Assert.NotNull(Person);
        Assert.NotNull(Company);
        Assert.NotNull(Monitors);

        Assert.NotEmpty(Monitors);
        Assert.Equal(MonitorConnectors.Count, Monitors.Count());
        Assert.All(Monitors, monitor =>
            Assert.Contains(monitor.Connector, MonitorConnectors));
    }

    protected void IsValidComputer(IComputer computer)
    {
        Assert.NotNull(computer.MotherBoard);
        Assert.NotNull(computer.Gpu);
        Assert.NotNull(computer.Ram);
        Assert.NotNull(computer.PowerSupply);
        Assert.NotNull(computer.Case);
    }

    private T InstantiateImplementation<T>(Dictionary<string, object> propertyValues = null) where T : class
    {
        var interfaceType = typeof(T);

        var types = Assembly.GetExecutingAssembly().GetTypes();

        foreach (var type in types)
        {
            if (type.IsClass &&
                !type.IsAbstract &&
                interfaceType.IsAssignableFrom(type) &&
                type.Namespace != null &&
                type.Namespace.IndexOf("implementations", StringComparison.OrdinalIgnoreCase) >= 0)
            {
                try
                {
                    // Create instance using parameterless constructor
                    var instance = Activator.CreateInstance(type);
                    if (instance == null) continue;

                    if (propertyValues != null)
                    {
                        foreach (var kvp in propertyValues)
                        {
                            var prop = type.GetProperty(kvp.Key,
                                BindingFlags.Instance | BindingFlags.Public | BindingFlags.IgnoreCase);

                            if (prop != null && prop.CanWrite)
                            {
                                prop.SetValue(instance, kvp.Value);
                            }
                        }
                    }

                    return instance as T;
                }
                catch
                {
                    // Ignore exceptions and try next type
                }
            }
        }

        return null;
    }
}