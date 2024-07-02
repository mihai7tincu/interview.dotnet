using Domain.Interview.Data.Pizzas;
using Microsoft.EntityFrameworkCore;

namespace Domain.Interview
{
    public partial class InterviewDbContext : DbContext
    {
        public const string Schema = "interview";
        //public static string ProviderName => "Npgsql.EntityFrameworkCore.PostgreSQL";

        public InterviewDbContext(DbContextOptions<InterviewDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema(Schema);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(InterviewDbContext).Assembly);
        }

        public DbSet<Pizza> Pizzas { get; set; } = default!;
    }
}
