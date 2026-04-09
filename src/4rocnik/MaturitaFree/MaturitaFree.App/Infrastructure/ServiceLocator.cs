using Microsoft.Extensions.DependencyInjection;

namespace MaturitaFree.App.Infrastructure;

/// <summary>
/// Singleton service locator — initialised once at startup.
/// Prefer constructor injection where possible; use this as a last resort
/// in WinForms contexts where constructor injection is not available.
/// </summary>
public sealed class ServiceLocator
{
    private static ServiceLocator? _instance;

    private readonly IServiceProvider _provider;

    private ServiceLocator(IServiceProvider provider) => _provider = provider;

    public static ServiceLocator Instance
        => _instance ?? throw new InvalidOperationException(
            "ServiceLocator has not been initialised. Call ServiceLocator.Initialize() at startup.");

    public static void Initialize(IServiceProvider provider)
    {
        if (_instance is not null)
            throw new InvalidOperationException("ServiceLocator is already initialised.");

        _instance = new ServiceLocator(provider);
    }

    /// <summary>Resolves a required service of type <typeparamref name="T"/>.</summary>
    public T GetService<T>() where T : notnull
        => _provider.GetRequiredService<T>();

    /// <summary>Creates a new DI scope (use inside a <c>using</c> block).</summary>
    public IServiceScope CreateScope()
        => _provider.CreateScope();
}
