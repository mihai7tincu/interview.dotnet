using Microsoft.Extensions.Options;
using RabbitMQ.Client;

namespace Domain.Interview.configs.RabbitMQ
{
    public interface IRabbitMqService
    {
        IConnection CreateChannel();
    }

    public class RabbitMqService : IRabbitMqService
    {
        private readonly RabbitMqConfiguration _configuration;
        public RabbitMqService(IOptions<RabbitMqConfiguration> options)
        {
            _configuration = options.Value;
        }
        public IConnection CreateChannel()
        {
            //builder.Services.Configure<RabbitMQSetting>(config.GetSection("RabbitMQ"));

            ConnectionFactory connection = new ConnectionFactory()
            {
                UserName = "guest", //_configuration.Username,
                Password = "guest", //_configuration.Password,
                HostName = "localhost" //_configuration.HostName
            };
            connection.DispatchConsumersAsync = true;
            var channel = connection.CreateConnection();
            return channel;
        }
    }
}
