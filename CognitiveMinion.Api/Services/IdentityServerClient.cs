using IdentityModel.Client;
using Microsoft.Extensions.Logging;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace CognitiveMinion.Api.Services
{
    /// <inheritdoc />
    public class IdentityServerClient : IIdentityServerClient
    {
        private readonly HttpClient _httpClient;
        private readonly ClientCredentialsTokenRequest _tokenRequest;
        private readonly ILogger<IdentityServerClient> _logger;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="httpClient"></param>
        /// <param name="tokenRequest"></param>
        /// <param name="logger"></param>
        public IdentityServerClient(HttpClient httpClient, ClientCredentialsTokenRequest tokenRequest, ILogger<IdentityServerClient> logger)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
            _tokenRequest = tokenRequest ?? throw new ArgumentNullException(nameof(tokenRequest));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <inheritdoc />
        public async Task<(string, int)> RequestClientCredentialsTokenAsync()
        {
            // request the access token token
            var tokenResponse = await _httpClient.RequestClientCredentialsTokenAsync(_tokenRequest);
            if (tokenResponse.IsError)
            {
                _logger.LogError(tokenResponse.Error);
                throw new HttpRequestException("Something went wrong while requesting the access token");
            }
            return (tokenResponse.AccessToken, tokenResponse.ExpiresIn);
        }
    }
}
