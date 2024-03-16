using CSharpFunctionalExtensions;
using Microsoft.AspNetCore.Mvc;
using Producer.RabbitMQ;
using Producer.Utils;
using ProducerLogic.LogMessages;
using ProducerLogic.Utils;
using RabbitMQ;
using Producer.Dto;
using System.Text.Json;

namespace Producer.Controllers
{
    [Route("api/[controller]")]
    public class RabbitMQController : BaseController
    {
        private readonly RPCClient _rpcClient;
        private readonly LogMessageRepository _logMessageRepository;
        private readonly EventTypeRepository _eventTypeRepository;

        public RabbitMQController(
            UnitOfWork unitOfWork, 
            RPCClient rpcClient,
            LogMessageRepository logMessageRepository,
            EventTypeRepository eventTypeRepository)
            : base(unitOfWork)
        {
            _rpcClient = rpcClient;
            _logMessageRepository = logMessageRepository;
            _eventTypeRepository = eventTypeRepository;
        }

        [HttpGet("{id:int}")]
        public IActionResult GetLogMessage(int id)
        {
            Maybe<LogMessage> logMessageOrNothing = _logMessageRepository.GetById(id);
            if (logMessageOrNothing.HasNoValue)
                return NotFound($"Сообщения с Id = {id} не существует!");

            var dto = new LogMessageDto()
            {
                Id = logMessageOrNothing.Value.Id,
                ExternalId = logMessageOrNothing.Value.ExternalId.ToString(),
                Status = logMessageOrNothing.Value.Status.Name,
                EventType = logMessageOrNothing.Value.EventType.Name,
                Content = logMessageOrNothing.Value.Content,
                ErrorMessage = logMessageOrNothing.Value.ErrorMessage.HasValue ? logMessageOrNothing.Value.ErrorMessage.Value : null
            };

            return Ok(dto);
        }

        [HttpPost("event")]
        public IActionResult PublishEvent(PublishEventDto item)
        {
            Maybe<EventType> eventTypeOrNothing = _eventTypeRepository.GetByName(item.EventType);
            if (eventTypeOrNothing.HasNoValue)
                return NotFound($"Событие типа {item.EventType} не обрабатывается!");

            Guid externalId = Guid.NewGuid();
            string content = JsonSerializer.Serialize(item.Content);

            LogMessage logMessage = new LogMessage(externalId, LogMessageStatus.InProgress, eventTypeOrNothing.Value, content, Maybe.None);
            _logMessageRepository.Add(logMessage);

            _rpcClient.SendRPCRequest(externalId, eventTypeOrNothing.Value.Name, content);

            return Ok("Событие опубликовано!");
        }
    }
}
