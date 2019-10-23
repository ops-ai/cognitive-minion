using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CognitiveMinion
{
    public interface IMinionRequestStore
    {
        /// <summary>
        /// Store a new request
        /// </summary>
        /// <param name="request">Request details</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<string> StoreRequest(MinionRequest request, CancellationToken ct);

        /// <summary>
        /// Get a request by id
        /// </summary>
        /// <param name="id">Requets id</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<MinionRequest> GetRequest(string id, CancellationToken ct);

        /// <summary>
        /// Returns a list of requests
        /// </summary>
        /// <param name="skip">Requests to skip</param>
        /// <param name="take">Number of requests to retrieve</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<IList<MinionRequest>> GetRequests(int skip, int take, CancellationToken ct);
    }
}
