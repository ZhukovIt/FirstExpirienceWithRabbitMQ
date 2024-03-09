using CSharpFunctionalExtensions;
using Microsoft.AspNetCore.Mvc;
using Producer.RabbitMQ;
using RabbitMQ;
using System.Text.Json;

namespace Producer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RabbitMQController : ControllerBase
    {
        private readonly RabbitMQService _rabbitMQService;

        public RabbitMQController(RabbitMQService rabbitMQService)
        {
            _rabbitMQService = rabbitMQService;
        }

        [Route("send")]
        [HttpPost]
        public IActionResult SendMessage([FromBody] object message)
        {
            string content = JsonSerializer.Serialize(message);

            string resultMessage = _rabbitMQService.SendMessage(content);

            return Ok(resultMessage);
        }
    }
}
