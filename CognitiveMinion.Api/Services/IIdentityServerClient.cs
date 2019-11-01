using System.Threading.Tasks;

namespace CognitiveMinion.Api.Services
{
    /// <summary>
    /// 
    /// </summary>
    public interface IIdentityServerClient
    {
        /// <summary>
        /// Get a new token using client_credentials
        /// </summary>
        /// <returns></returns>
        Task<(string AccessToken, int ExpiresIn)> RequestClientCredentialsTokenAsync();
    }
}
