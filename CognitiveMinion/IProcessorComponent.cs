using System.Threading.Tasks;

namespace CognitiveMinion
{
    public interface IProcessorComponent
    {
        //Find channel / person to seek permission from, and description of action that would be taken if this is approved
        Task<string> DescribeActionPlan(MinionRequest request); // TODO: allow workers to describe models that intents map to

        //Execute with params
        Task ExecuteActionPlan(MinionRequest request);
    }
}
