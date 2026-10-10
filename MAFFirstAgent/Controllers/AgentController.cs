using MAFFirstAgent.Models;
using MAFFirstAgent.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MAFFirstAgent.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgentController : ControllerBase
    {
        private readonly AgentService _agentService;

        public AgentController(AgentService agentService)
        {
            _agentService = agentService;
        }

        [HttpPost("chat")]
        public async Task<ActionResult<ChatResponse>> Chat([FromBody] ChatRequest request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrWhiteSpace(request.Message))
            {
                return BadRequest(new
                {
                    message = "Message is required."
                });
            }

            var answer = await _agentService.ChatAsync(request.Message,
                cancellationToken);

            return Ok(new ChatResponse
            {
                Message = answer
            });
        }

    }
}

