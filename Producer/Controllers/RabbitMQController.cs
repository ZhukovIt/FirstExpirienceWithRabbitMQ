using Microsoft.AspNetCore.Mvc;
using Producer.RabbitMQ;
using RabbitMQ;

namespace Producer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RabbitMQController : ControllerBase
    {
        private readonly IRabbitMQService _rabbitMQService;

        public RabbitMQController(IRabbitMQService rabbitMQService)
        {
            _rabbitMQService = rabbitMQService;
        }

        [Route("[action]/{message}")]
        [HttpGet]
        public IActionResult SendMessage(string message)
        {
            _rabbitMQService.SendMessage(message);

            return Ok("Сообщение отправлено!");
        }
    }
}
