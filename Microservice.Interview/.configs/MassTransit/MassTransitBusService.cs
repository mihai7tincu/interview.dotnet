using MassTransit;

namespace Microservice.Interview.configs.MassTransit
{
    public interface IMassTransitBusService
    {
        Task Publish(object message);
    }

    public class MassTransitBusService : IMassTransitBusService
    {
        private readonly IPublishEndpoint _publishEndpoint;
        private readonly ILogger<MassTransitBusService> _logger;

        public MassTransitBusService(
            IPublishEndpoint publishEndpoint,
            ILogger<MassTransitBusService> logger)
        {
            _logger = logger;
            _publishEndpoint = publishEndpoint;
        }

        public async Task Publish(object message)
        {
            _logger.LogInformation($"Published {message}");
            await _publishEndpoint.Publish(message);
        }
    }
}
