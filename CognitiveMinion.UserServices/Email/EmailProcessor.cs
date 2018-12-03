using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace CognitiveMinion.UserServices.Email
{
    public class EmailProcessor : IHostedService, IDisposable
    {
        bool _disposed;

        private bool _notStopped;
        private readonly ILogger _logger;

        public EmailProcessor(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<EmailProcessor>();
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            try
            {

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error reading from POP3 mailbox");
            }

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            //TODO: Cleanup when the service is stopped
            return Task.CompletedTask;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed) return;

            //TODO: Cleanup when the service is disposed

            _disposed = true;
        }
    }
}
