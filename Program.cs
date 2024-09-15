using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OrderProcessor.DependencyInjection;
using OrderProcessor.Services;

var host = Host.CreateDefaultBuilder(args)
    .ConfigureAppConfiguration((context, config) =>
    {
        config.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
    })
    .ConfigureServices((context, services) =>
    {
        ServiceRegistration.ConfigureServices(context, services);
        services.AddSingleton<FileProcessor>();
        services.AddSingleton<FileProcessingService>();
    })
    .Build();

await host.Services.GetRequiredService<FileProcessingService>().ProcessFilesAsync();