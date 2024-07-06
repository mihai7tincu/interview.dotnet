
using Domain.Interview;
using Domain.Interview.configs;
using Domain.Interview.Services;
using MassTransit;
using Microservice.Interview.configs.MassTransit;
using Microsoft.EntityFrameworkCore;

namespace Microservice.Interview
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<InterviewDbContext>(o =>
            {
                o.UseSqlServer(builder.Configuration.GetConnectionString("InterviewDbContext"),
                    b => b.MigrationsAssembly("Domain.Interview.SqlMigrations"));
            });

            builder.Services.AddDomainServices();
            builder.Services.AddAutoMapper(typeof(Program));

            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.Development.json")
                .Build();

            builder.Services.AddMassTransit(config =>
            {
                config.SetKebabCaseEndpointNameFormatter();
                config.SetInMemorySagaRepositoryProvider();

                var assembly = typeof(OrderConsumer).Assembly;
                config.AddConsumers(assembly);
                config.AddSagaStateMachines(assembly);
                config.AddSagas(assembly);
                config.AddActivities(assembly);

                config.UsingRabbitMq((context, conf) => { 
                    conf.Host(
                        host: "localhost",
                        virtualHost: "/", cfg => {
                            cfg.Username("guest");
                            cfg.Password("guest");
                        });

                    conf.ConfigureEndpoints(context);
                });
            });

            builder.Services.AddScoped<IMassTransitBusService, MassTransitBusService>();

            builder.Services.AddCors(options =>
            {
                options.AddPolicy(name: "angular", policy => {
                    policy.WithOrigins("http://localhost:4200");
                    policy.AllowAnyHeader();
                    policy.AllowAnyMethod();
                });
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();

            app.MapControllers();

            app.UseCors("angular");

            app.Run();
        }
    }
}
