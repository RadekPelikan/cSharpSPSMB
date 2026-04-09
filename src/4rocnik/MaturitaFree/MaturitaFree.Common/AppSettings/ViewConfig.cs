using Microsoft.Extensions.Configuration;

namespace MaturitaFree.Common.AppSettings;

public record ViewConfig
{
    public ViewConfig() { }

    public ViewConfig(IConfiguration configuration) : this()
    {
        if (configuration is null)
        {
            throw new ArgumentNullException(nameof(configuration));
        }

        configuration.GetSection("View").Bind(this);
    }

    /// <summary>
    /// How often (in seconds) the UI auto-refreshes. Set to 0 to disable.
    /// </summary>
    public int AutoRefreshIntervalSeconds { get; set; } = 30;
}