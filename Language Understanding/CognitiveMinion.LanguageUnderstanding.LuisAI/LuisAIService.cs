using System.Threading.Tasks;
using Microsoft.Azure.CognitiveServices.Language.LUIS.Runtime;
using Microsoft.Azure.CognitiveServices.Language.LUIS.Runtime.Models;
using Microsoft.Extensions.Options;

namespace CognitiveMinion.LanguageUnderstanding.LuisAI
{
    public class LuisAIService : IUnderstandingService
    {
        private readonly LuisAiSettings _luisSettings;

        public LuisAIService(IOptions<LuisAiSettings> luisSettings)
        {
            _luisSettings = luisSettings.Value;
        }

        public async Task<PredictionResult> PredictIntent(string query)
        {
            var luisClient = new LUISRuntimeClient(new ApiKeyServiceClientCredentials(_luisSettings.SubscriptionKey), new System.Net.Http.DelegatingHandler[] { });
            luisClient.Endpoint = $"https://{_luisSettings.Region}.api.cognitive.microsoft.com";

            var slot = await luisClient.Prediction.GetSlotPredictionAsync(_luisSettings.AppId, _luisSettings.Slot, new PredictionRequest(query), true, false, true);
            var result = new PredictionResult { IntentName = slot.Prediction.TopIntent, IntentParameters = slot.Prediction.Entities, Score = slot.Prediction.Intents[slot.Prediction.TopIntent].Score };

            return result;
        }


    }
}
