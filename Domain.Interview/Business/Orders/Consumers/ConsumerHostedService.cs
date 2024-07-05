using Domain.Interview.configs.RabbitMQ;
using Microsoft.Extensions.Hosting;

namespace Domain.Interview.Business.Orders.Consumers
{
    public class ConsumerHostedService : BackgroundService //
    {
        private readonly IConsumerService _consumerService;

        public ConsumerHostedService(IConsumerService consumerService)
        {
            _consumerService = consumerService;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await _consumerService.ReadMessgaes();
        }
    }
}
