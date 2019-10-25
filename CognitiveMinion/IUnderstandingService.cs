using System.Threading.Tasks;

namespace CognitiveMinion
{
    public interface IUnderstandingService
    {
        Task<PredictionResult> PredictIntent(string query);
    }
}
