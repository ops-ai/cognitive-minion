using CognitiveMinion.Api.Tests.Fakes;
using CognitiveMinion.LanguageUnderstanding.LuisAI;
using Divergic.Logging.Xunit;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Moq;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace CognitiveMinion.Api.Tests
{
    public class LuisIntegrationTests : IClassFixture<CognitiveMinionWebApplicationFactory<Startup>>
    {
        protected readonly ILoggerFactory _loggerFactory;
        private readonly ITestOutputHelper _output;

        public IConfigurationRoot Configuration { get; set; }
        private readonly HttpClient _client;
        private readonly Mock<HttpMessageHandler> _luisAiHttpHandler;

        public LuisIntegrationTests(CognitiveMinionWebApplicationFactory<Startup> factory, ITestOutputHelper output)
        {
            _output = output;
            _loggerFactory = LogFactory.Create(output);

            Configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", false, true)
                .AddJsonFile("appsettings.local.json", true, true)
                .AddJsonFile("appsettings.test.json", true)
                .AddEnvironmentVariables()
                .Build();

            var mockHttpFactory = new Mock<IHttpClientFactory>();

            _luisAiHttpHandler = new Mock<HttpMessageHandler>();

            _client = factory.WithWebHostBuilder(builder =>
            {
                builder.ConfigureServices(t =>
                {
                    t.AddHttpClient("LuisAI", client => { client.BaseAddress = new Uri(Configuration["IdPManagerApiUrl"]); }).ConfigureHttpMessageHandlerBuilder(s => s.PrimaryHandler = _luisAiHttpHandler.Object);
                })
                .ConfigureTestServices(services =>
                {
                    services.AddMvc(opt =>
                    {
                        opt.Filters.Add(new AllowAnonymousFilter());
                        opt.Filters.Add(new FakeUserFilter());
                    });
                })
                .ConfigureLogging(t =>
                {

                });
            }).CreateClient();
        }


        [Fact]
        public async Task TestBasicIntentDetection()
        {
            var mockHttpFactory = new Mock<IHttpClientFactory>();
            var luis = new LuisAIService(Options.Create<LuisAiSettings>(new LuisAiSettings { AppId = Guid.Parse(""), Region = "", Slot = "", SubscriptionKey = "" }), mockHttpFactory.Object);
            var result = await luis.PredictIntent("please whitelist 10.10.10.10 for me");



        }
    }
}
