using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using OrderProcessor.Interfaces;
using OrderProcessor.Services;
using System.Text.Encodings.Web;
using System.Text.Json;

namespace OrderProcessor.DependencyInjection
{
    public static class ServiceRegistration
    {
        public static void ConfigureServices(HostBuilderContext context, IServiceCollection services)
        {
            services.AddSingleton(new JsonSerializerOptions
            {
                WriteIndented = true,
                Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
            });

            services.AddSingleton<IOrderSaver, OrderSaver>();
            services.AddSingleton<IOrderParser, OrderParser>();
            services.AddSingleton<FileProcessingService>();
            services.AddLogging(configure => configure.AddConsole());
        }
    }
}