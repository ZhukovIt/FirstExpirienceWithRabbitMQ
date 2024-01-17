using CSharpFunctionalExtensions;
using Microsoft.AspNetCore.Mvc;
using Producer.RabbitMQ;
using RabbitMQ;

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
        public IActionResult SendMessage([FromBody] string message)
        {
            Result<Message> messageResult = Message.Create(message);
            if (messageResult.IsFailure)
                return BadRequest(messageResult.Error);

            _rabbitMQService.SendMessage(message);

            return Ok("Сообщение отправлено!");
        }
    }
}
