using Domain.Interview.Business.Orders.Consumers;
using Domain.Interview.configs.MassTransit;
using Domain.Interview.configs.RabbitMQ;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Domain.Interview.configs
{
    public static class DomainServiceExtensions
    {
        private static readonly Assembly _currentAssembly = typeof(DomainServiceExtensions).Assembly;

        public static IServiceCollection AddDomainServices(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(_currentAssembly));
            services.AddAutoMapper(_currentAssembly);

            services.AddSingleton<IRabbitMqService, RabbitMqService>();
            services.AddSingleton<IConsumerService, ConsumerService>();
            services.AddHostedService<ConsumerHostedService>();

            return services;
        }
    }
}
