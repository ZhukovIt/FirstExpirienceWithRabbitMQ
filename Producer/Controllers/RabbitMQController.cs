using CSharpFunctionalExtensions;
using Microsoft.AspNetCore.Mvc;
using Producer.RabbitMQ;
using Producer.Utils;
using ProducerLogic.LogMessages;
using ProducerLogic.Utils;
using RabbitMQ;
using System.Text.Json;

namespace Producer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RabbitMQController : BaseController
    {
        private readonly RPCClient _rpcClient;
        private readonly LogMessageRepository _logMessageRepository;

        public RabbitMQController(
            UnitOfWork unitOfWork, 
            RPCClient rpcClient,
            LogMessageRepository logMessageRepository)
            : base(unitOfWork)
        {
            _rpcClient = rpcClient;
            _logMessageRepository = logMessageRepository;
        }

        [HttpGet("{id:int}")]
        public IActionResult GetLogMessage(int id)
        {
            LogMessage logMessage = _logMessageRepository.GetById(id);
            return Ok();
        }

        [HttpPost("log-message")]
        public IActionResult CreateLogMessage()
        {
            return Ok();
        }

        [HttpPost("send")]
        public async Task<IActionResult> SendMessage([FromBody] object message)
        {
            string content = JsonSerializer.Serialize(message);

            string resultMessage = await _rpcClient
                .SendRPCRequestAsync(content)
                .ConfigureAwait(false);

            RabbitMQEnvelope envelope = JsonSerializer.Deserialize<RabbitMQEnvelope>(resultMessage);




            return Ok(envelope);
        }
    }
}
