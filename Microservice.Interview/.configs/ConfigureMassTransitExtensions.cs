using Domain.Interview.configs;
using MassTransit;
using MassTransit.ExtensionsDependencyInjectionIntegration;
using Microservice.Interview.configs.MassTransit;
using System.Reflection;

namespace Microservice.Interview.configs
{
    public static class ConfigureMassTransitExtensions
    {
        private const string MassTransitSection = "MassTransit";
        private static string CurrentMicroservice => typeof(ConfigureMassTransitExtensions).Assembly.GetName().Name ?? "Interview";
        private static Assembly InterviewDomain => typeof(DomainServiceExtensions).Assembly;

        public static IServiceCollection AddMassTransitConfigurations(this IServiceCollection services, IConfiguration configuration)
        {
            var massTransitOptions = configuration.GetSection(MassTransitSection).Get<MassTransitOptions>();
            void AddOptions(MassTransitOptions options)
            {
                options.Microservice = CurrentMicroservice;
                options.Host = massTransitOptions.Host;
                options.Password = massTransitOptions.Password;
                options.Port = massTransitOptions.Port;
                options.User = massTransitOptions.User;
                options.VirtualHost = massTransitOptions.VirtualHost;
            }

            void AddServiceConfigurations(IServiceCollectionBusConfigurator serviceCollection)
            {
                serviceCollection.AddDomainInterview();
            }

            void AddFactoryConfigurations(IBusRegistrationContext context, IRabbitMqBusFactoryConfigurator rabbit)
            {
                rabbit.Host(massTransitOptions.Host, (ushort)massTransitOptions.Port, massTransitOptions.VirtualHost, _ =>
                {
                    _.Username(massTransitOptions.User);
                    _.Password(massTransitOptions.Password);
                });

                rabbit.UseRetry(r => r.Immediate(3));

                rabbit.ReceiveEndpoint("Domain.Interview", registerConfig =>
                {
                    registerConfig.ConfigureDomainInterview(context);
                });
            }

            return services;

            //return services.AddMassTransitServices<ConfigureApiBusHostedService>(AddOptions, AddServiceConfigurations, AddFactoryConfigurations, new Assembly[]
            //{
            //    InterviewDomain
            //});
        }
    }
}
