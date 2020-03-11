using System.Threading.Tasks;

namespace CognitiveMinion.Api.Services
{
    public interface IProcessingClient
    {
        Task CreateActionPlan(string user, string message);

        Task ExecuteActionPlan(string message);
    }
}
