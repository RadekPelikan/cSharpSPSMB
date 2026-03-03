using MaturitaFree.App.Controls;
using MaturitaFree.App.Forms;
using MaturitaFree.App.Infrastructure;
using MaturitaFree.Common.AppSettings;
using MaturitaFree.Data.EF.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MaturitaFree.App;

using Forms;

static class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(AppContext.BaseDirectory)
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: false)
            .Build();

        var services = new ServiceCollection();
        ConfigureServices(services, configuration);

        var provider = services.BuildServiceProvider();

        // Initialise the singleton wrapper so any component can resolve services
        ServiceLocator.Initialize(provider);

        provider.MigrateDatabase();

        ApplicationConfiguration.Initialize();
        Application.Run(ServiceLocator.Instance.GetService<MainForm>());
    }

    private static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
    {
        var dbConfig = new DatabaseConfig(configuration);
        var viewConfig = new ViewConfig(configuration);

        // Data layer — SQLite + repositories; DatabaseConfig is registered as singleton inside
        services.AddDataLayer(dbConfig);
        services.AddSingleton(viewConfig);

        // WinForms views — transient so each resolution gets a fresh instance
        services.AddTransient<MainForm>();
        services.AddTransient<BookListControl>();
        services.AddTransient<BookEditControl>();
        services.AddTransient<PersonListControl>();
        services.AddTransient<PersonEditControl>();

        // Dialog forms
        services.AddTransient<BookEditForm>();
        services.AddTransient<PersonEditForm>();
        services.AddTransient<BookChapterEditForm>();
        services.AddTransient<BookParagraphEditForm>();
        services.AddTransient<PersonWorkingOnBookEditForm>();
    }
}