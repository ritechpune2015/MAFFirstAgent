using Microsoft.Agents.AI;

namespace MAFFirstAgent.Services
{
    public class AgentService
    {
        private readonly AIAgent _agent;

        public AgentService(AIAgent agent)
        {
            _agent = agent;
        }

        public async Task<string> ChatAsync(
            string message,
            CancellationToken cancellationToken = default)
        {
            var response = await _agent.RunAsync(
                message,
                cancellationToken: cancellationToken);

            return response.ToString();
        }
    }

}
