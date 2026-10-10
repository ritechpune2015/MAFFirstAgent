using Microsoft.Agents.AI;
using Microsoft.Extensions.AI;
using OllamaSharp;

namespace MAFFirstAgent.Agents
{
    public class CustomerSupportAgentFactory
    {
        public static AIAgent Create(string endpoint, string modelName)
        {
            var httpClient = new HttpClient
            {
                BaseAddress = new Uri(endpoint),
                Timeout = TimeSpan.FromMinutes(5)
            };

            var ollamaClient = new OllamaApiClient(httpClient, modelName);

            AIAgent agent = ollamaClient.AsAIAgent(
                name: "CustomerSupportAgent",
                instructions: """
                You are a professional customer support assistant.
                Answer questions clearly and accurately.
                """);

            return agent;
        }
    }

}

