using CognitiveMinion;
using System;
using System.Threading.Tasks;

namespace IPWhitelist
{
    public class IISIPWhitelister : IProcessorComponent
    {
        /// <inheritdoc />
        public async Task<string> DescribeActionPlan(MinionRequest request) => throw new NotImplementedException();

        /// <inheritdoc />
        public async Task ExecuteActionPlan(MinionRequest request) => throw new NotImplementedException();
    }
}
