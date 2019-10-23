using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Raven.Client.Documents;
using Raven.Client.Documents.Linq;

namespace CognitiveMinion.Storage.RavenDB
{
    public class RavenDbStore : IMinionRequestStore
    {
        private readonly IDocumentStore _store;
        private readonly ILogger _logger;

        public RavenDbStore(IDocumentStore store, ILoggerFactory loggerFactory)
        {
            _store = store;
            _logger = loggerFactory.CreateLogger<RavenDbStore>();
        }

        /// <inheritdoc />
        public async Task<string> StoreRequest(MinionRequest request, CancellationToken ct)
        {
            try
            {
                using (var session = _store.OpenAsyncSession())
                {
                    await session.StoreAsync(request, ct);
                    await session.SaveChangesAsync(ct);
                }

                return request.Id;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error storing request");
                throw;
            }
        }

        /// <inheritdoc />
        public async Task<MinionRequest> GetRequest(string id, CancellationToken ct)
        {
            try
            {
                using (var session = _store.OpenAsyncSession())
                {
                    var request = await session.LoadAsync<MinionRequest>(id, ct);
                    if (request == null)
                        throw new KeyNotFoundException($"Request {id} was not found");

                    return request;
                }
            }
            catch (KeyNotFoundException)
            {
                throw;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving request");
                throw;
            }
        }

        /// <inheritdoc />
        public async Task<IList<MinionRequest>> GetRequests(int skip, int take, CancellationToken ct)
        {
            try
            {
                using (var session = _store.OpenAsyncSession())
                {
                    var requests = await session.Query<MinionRequest>().OrderByDescending(t => t.Id).Skip(skip).Take(take).ToListAsync(ct);
                    
                    return requests;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving requests");
                throw;
            }
        }
    }
}
