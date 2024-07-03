using Domain.Interview.Data.Orders;
using Domain.Interview.Data.Pizzas;
using Microsoft.EntityFrameworkCore;

namespace Domain.Interview
{
    public partial class InterviewDbContext : DbContext
    {
        public const string Schema = "interview";

        public InterviewDbContext(DbContextOptions<InterviewDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema(Schema);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(InterviewDbContext).Assembly);
        }

        public DbSet<Pizza> Pizzas { get; set; } = default!;
        public DbSet<PizzaTopping> PizzaToppings { get; set; } = default!;
        public DbSet<Order> Orders { get; set; } = default!;
    }
}
