using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using CognitiveMinion.Storage.RavenDB;
using CognitiveMinion.UserServices.Email;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NLog;
using Raven.Client;
using Raven.Client.Documents;
using ILogger = NLog.ILogger;

namespace CognitiveMinion.UserServices
{
    public class Program
    {
        private static async Task Main(string[] args)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            IConfigurationRoot configuration = builder.Build();

            var services = new ServiceCollection();

            services.AddSingleton(typeof(IDocumentStore), new DocumentStore
            {
                Urls = new[] { configuration["Raven:Url"] },
                Database = configuration["Raven:Database"],
                Certificate = configuration.GetSection("Raven:EncryptionEnabled").Get<bool>() ? new X509Certificate2(configuration["Raven:CertFile"], configuration["Raven:CertPassword"]) : null
            }.Initialize());

            services.AddSingleton<IMinionRequestStore, RavenDbStore>();


            var serviceProvider = services.BuildServiceProvider();

            var logger = serviceProvider.GetService<ILoggerFactory>()
                .CreateLogger<Program>();

            logger.LogInformation("Application started...");

            var isService = !(Debugger.IsAttached || args.Contains("--console"));

            var serviceBuilder = new HostBuilder()
                .ConfigureServices((hostContext, serviceCollection) =>
                {
                    serviceCollection.AddHostedService<EmailProcessor>();
                });

            if (isService)
            {
                logger.LogInformation("Application run as service");
                await serviceBuilder.RunAsServiceAsync();
            }
            else
            {
                logger.LogInformation("Application run as console application");
                await serviceBuilder.RunConsoleAsync();
            }
        }
    }
}
