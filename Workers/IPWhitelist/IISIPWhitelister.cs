using CognitiveMinion;
using System;
using System.Threading.Tasks;

namespace IPWhitelist
{
    public class IISIPWhitelister : IProcessorComponent
    {
        /// <inheritdoc />
        public async Task<string> Describe(MinionRequest request) => throw new NotImplementedException();

        /// <inheritdoc />
        public async Task Execute(MinionRequest request) => throw new NotImplementedException();
    }
}
