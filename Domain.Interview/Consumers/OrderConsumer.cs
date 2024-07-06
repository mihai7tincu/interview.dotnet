using Domain.Interview.Contracts.Orders;
using MassTransit;
using Microsoft.Extensions.Logging;

namespace Domain.Interview.Services
{
    public class OrderConsumer : IConsumer<IOrderContract>
    {
        private readonly ILogger<OrderConsumer> _logger;

        public OrderConsumer(
            ILogger<OrderConsumer> logger)
        {
            _logger = logger;
        }

        public Task Consume(ConsumeContext<IOrderContract> context)
        {
            _logger.LogInformation($"Consumed <IOrder>: {{ CustomerId: {context.Message.CustomerId}, PizzaIds: {string.Join(' ', context.Message.PizzaIds.ToArray())} }}");
            return Task.CompletedTask;
        }
    }
}
