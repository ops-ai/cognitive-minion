using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using CognitiveMinion.UserServices.Email;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NLog;

namespace CognitiveMinion.UserServices
{
    public class Program
    {
        private static readonly ILogger Logger = LogManager.GetCurrentClassLogger();

        private static async Task Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()

                .BuildServiceProvider();

            Logger.Info("Application started...");

            var isService = !(Debugger.IsAttached || args.Contains("--console"));

            var builder = new HostBuilder()
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddHostedService<EmailProcessor>();
                });

            if (isService)
            {
                Logger.Info("Application run as service");
                await builder.RunAsServiceAsync();
            }
            else
            {
                Logger.Info("Application run as console application");
                await builder.RunConsoleAsync();
            }
        }
    }
}
