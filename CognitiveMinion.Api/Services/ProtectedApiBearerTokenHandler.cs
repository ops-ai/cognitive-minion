using IdentityModel.Client;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace CognitiveMinion.Api.Services
{
    /// <summary>
    /// Http handler which adds a new JWT client_credentials token to the request
    /// </summary>
    public class ProtectedApiBearerTokenHandler : DelegatingHandler
    {
        private readonly IIdentityServerClient _identityServerClient;
        private readonly IMemoryCache _memoryCache;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="identityServerClient"></param>
        /// <param name="memoryCache"></param>
        public ProtectedApiBearerTokenHandler(IIdentityServerClient identityServerClient, IMemoryCache memoryCache)
        {
            _identityServerClient = identityServerClient ?? throw new ArgumentNullException(nameof(identityServerClient));
            _memoryCache = memoryCache;
        }

        /// <summary>
        /// Called right before sending the request
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            if (!_memoryCache.TryGetValue("AuthToken", out string accessToken))
            {
                // request the access token
                var (AccessToken, ExpiresIn) = await _identityServerClient.RequestClientCredentialsTokenAsync();
                accessToken = AccessToken;
                _memoryCache.Set("AuthToken", accessToken, TimeSpan.FromSeconds(ExpiresIn - 60));
            }

            // set the bearer token to the outgoing request
            request.SetBearerToken(accessToken);

            // Proceed calling the inner handler, that will actually send the request
            // to our protected api
            return await base.SendAsync(request, cancellationToken);
        }
    }
}
