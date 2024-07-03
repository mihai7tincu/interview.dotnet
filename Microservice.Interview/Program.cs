
using Domain.Interview;
using Domain.Interview.configs;
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

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
