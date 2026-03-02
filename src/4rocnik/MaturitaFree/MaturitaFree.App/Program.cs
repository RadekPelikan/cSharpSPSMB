using MaturitaFree.App.Controls;
using MaturitaFree.App.Forms;
using MaturitaFree.App.Infrastructure;
using MaturitaFree.Data.EF.Extensions;
using Microsoft.Extensions.DependencyInjection;

namespace MaturitaFree.App;

static class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        var services = new ServiceCollection();
        ConfigureServices(services);

        var provider = services.BuildServiceProvider();

        // Initialise the singleton wrapper so any component can resolve services
        ServiceLocator.Initialize(provider);

        provider.MigrateDatabase();

        ApplicationConfiguration.Initialize();
        Application.Run(ServiceLocator.Instance.GetService<MainForm>());
    }

    private static void ConfigureServices(IServiceCollection services)
    {
        // Data layer — SQLite + repositories
        services.AddDataLayer();

        // WinForms views — transient so each resolution gets a fresh instance
        services.AddTransient<MainForm>();
        services.AddTransient<BookListControl>();
    }
}
