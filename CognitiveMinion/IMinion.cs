using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CognitiveMinion
{
    public interface IMinion
    {
        /// <summary>
        /// Send a request to the minion
        /// </summary>
        /// <param name="request">The text of the request</param>
        /// <param name="timeout">Maximum amount of time to wait for the request to be confirmed or cancelled before it's abandoned</param>
        /// <returns>The unique approval key for confirming or cancelling the request</returns>
        Task<MinionRequest> IssueRequest(string request, TimeSpan? timeout);

        /// <summary>
        /// Update the text of the request in case to help it better understand the request in case it was mis-identified or it couldn't figure out what was asked.
        /// The request replaces the old request and generates a new request id and secret, and logs the text of the original request as possible training data for the model.
        /// </summary>
        /// <param name="requestId">Original request id</param>
        /// <param name="clarificationStatement">A better/clear re-statement of the request</param>
        /// <param name="secret">Secret key associated with the request</param>
        /// <param name="timeout">Maximum amount of time to wait for the request to be confirmed or cancelled before it's abandoned</param>
        /// <returns>The unique approval key for confirming or cancelling the request</returns>
        /// <exception cref="KeyNotFoundException">Original request was not found</exception>
        Task<MinionRequest> ClarifyRequest(string requestId, string clarificationStatement, string secret, TimeSpan? timeout);

        /// <summary>
        /// Cancel the request
        /// </summary>
        /// <param name="requestId">Minion request id</param>
        /// <param name="secret">Secret key associated with the request</param>
        /// <exception cref="KeyNotFoundException">Original request was not found</exception>
        /// <exception cref="UnauthorizedAccessException">Invalid secret</exception>
        Task CancelRequest(string requestId, string secret);

        /// <summary>
        /// Confirm and execute requested action
        /// </summary>
        /// <param name="requestId">Minion request id</param>
        /// <param name="secret">Secret key associated with the request</param>
        /// <exception cref="KeyNotFoundException">Original request was not found</exception>
        /// <exception cref="UnauthorizedAccessException">Invalid secret</exception>
        /// <returns></returns>
        Task ApproveRequest(string requestId, string secret);
    }
}
