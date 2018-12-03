using System;
using System.Threading;
using System.Threading.Tasks;

namespace CognitiveMinion
{
    public interface IMinionRequestStore
    {
        Task StoreRequest(MinionRequest request, CancellationToken ct);

        Task<MinionRequest> GetRequest(string id, CancellationToken ct);
    }
}
