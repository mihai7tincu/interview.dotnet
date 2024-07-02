using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Interview.Data.Pizzas.Configurations
{
    public class PizzaToppingConfiguration : IEntityTypeConfiguration<PizzaTopping>
    {
        public void Configure(EntityTypeBuilder<PizzaTopping> builder)
        {
            builder.ToTable(name: nameof(PizzaTopping), schema: InterviewDbContext.Schema);
            builder.HasKey(x => x.Id);

            builder.Property(x => x.PizzaId).IsRequired();
            builder.Property(x => x.ToppingId).IsRequired();

            builder.HasData(Seed.Data.GetPizzaToppings());
        }
    }
}
