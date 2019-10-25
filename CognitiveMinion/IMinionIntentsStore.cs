using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CognitiveMinion
{
    public interface IMinionIntentsStore
    {
        /// <summary>
        /// Register a new intent
        /// </summary>
        /// <param name="name">Intent name</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<string> CreateIntent(string name, CancellationToken ct);

        /// <summary>
        /// Get a intent by name
        /// </summary>
        /// <param name="name">Intent name</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<Intent> GetIntent(string name, CancellationToken ct);

        /// <summary>
        /// Returns a list of intents
        /// </summary>
        /// <param name="skip">Requests to skip</param>
        /// <param name="take">Number of requests to retrieve</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<IList<Intent>> GetIntents(int skip, int take, CancellationToken ct);
    }
}
