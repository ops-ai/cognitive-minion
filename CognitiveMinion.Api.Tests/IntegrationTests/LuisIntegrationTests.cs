using System;
using System.Threading.Tasks;
using CognitiveMinion.LanguageUnderstanding.LuisAI;
using Microsoft.Extensions.Options;
using Xunit;

namespace CognitiveMinion.Api.Tests
{
    public class LuisIntegrationTests
    {
        [Fact]
        public async Task TestBasicIntentDetection()
        {
            var luis = new LuisAIService(Options.Create<LuisAiSettings>(new LuisAiSettings { AppId = Guid.Parse(""), Region = "", Slot = "", SubscriptionKey = "" }));
            var result = await luis.PredictIntent("please whitelist 10.10.10.10 for me");



        }
    }
}
