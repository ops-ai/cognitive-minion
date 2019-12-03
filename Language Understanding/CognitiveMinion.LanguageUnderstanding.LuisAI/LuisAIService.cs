using CognitiveMinion.LanguageUnderstanding.LuisAI.Models;
using Microsoft.Extensions.Options;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace CognitiveMinion.LanguageUnderstanding.LuisAI
{
    public class LuisAIService : IUnderstandingService
    {
        private readonly LuisAiSettings _luisSettings;
        private readonly IHttpClientFactory _httpClientFactory;

        public LuisAIService(IOptions<LuisAiSettings> luisSettings, IHttpClientFactory httpClientFactory)
        {
            _luisSettings = luisSettings.Value;
            _httpClientFactory = httpClientFactory;
        }

        public async Task<PredictionResult> PredictIntent(string query)
        {
            var client = _httpClientFactory.CreateClient("LuisAI");

            var queryString = HttpUtility.ParseQueryString(string.Empty);

            // The request header contains your subscription key
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", _luisSettings.SubscriptionKey);

            // The "q" parameter contains the utterance to send to LUIS
            queryString["q"] = query;

            // These optional request parameters are set to their default values
            queryString["timezoneOffset"] = "0";
            queryString["verbose"] = "false";
            queryString["spellCheck"] = "false";
            queryString["staging"] = (_luisSettings.Slot == "Staging").ToString().ToLower();

            var endpointUri = $"https://{_luisSettings.Region}.api.cognitive.microsoft.com/luis/v2.0/apps/{_luisSettings.AppId}?{queryString}";
            var response = await client.GetAsync(endpointUri);

            var predictionResult = await response.Content.ReadAsAsync<PredictionResponse>();

            var result = new PredictionResult { IntentName = predictionResult.TopScoringIntent.Intent, IntentParameters = predictionResult.CompositeEntities.ToDictionary(t => t.ParentType, t => t.Value), Score = predictionResult.TopScoringIntent.Score };

            return result;
        }
    }
}
