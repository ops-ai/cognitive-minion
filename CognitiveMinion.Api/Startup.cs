using CognitiveMinion.Api.Hubs;
using CognitiveMinion.Api.Services;
using CognitiveMinion.LanguageUnderstanding.LuisAI;
using Elastic.Apm.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Polly;
using System;

namespace CognitiveMinion.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration) => Configuration = configuration;

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddOptions<LuisAiSettings>("LuisAI");

            services.AddControllers();


            services.AddHttpClient<IIdentityServerClient, IdentityServerClient>(client =>
            {
                client.BaseAddress = new Uri(Configuration["SSOAuthorityUrl"]);
                client.DefaultRequestHeaders.Add("Accept", "application/json");
            }).AddTransientHttpErrorPolicy(builder => builder.WaitAndRetryAsync(new[]
            {
                TimeSpan.FromSeconds(1),
                TimeSpan.FromSeconds(2),
                TimeSpan.FromSeconds(3)
            }));
            services.AddMemoryCache();

            services.AddTransient<ProtectedApiBearerTokenHandler>();
            services.AddHttpClient("LuisAI", client => { /*client.BaseAddress = new Uri(Configuration["LuisAIUrl"]);*/ });
            services.AddHttpClient("JsnLogger");

            services.AddSignalR();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseElasticApm(Configuration);

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHub<ProcessingHub>("/processing");
            });
        }
    }
}
