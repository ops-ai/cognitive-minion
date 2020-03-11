using CognitiveMinion.Api.Services;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace CognitiveMinion.Api.Hubs
{
    public class ProcessingHub : Hub<IProcessorComponent>
    {
        private readonly ILogger<ProcessingHub> _logger;

        public ProcessingHub(ILogger<ProcessingHub> logger)
        {
            _logger = logger;
        }

        public async Task<string> DescribeActionPlan(MinionRequest request)
        {
            try
            {
                var response = await Clients.Group(request.IntentName).DescribeActionPlan(request);

                return response;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error describing action plan");
                throw;
            }
        }

        public Task ThrowException()
        {
            throw new HubException("This error will be sent to the client!");
        }
    }
}
