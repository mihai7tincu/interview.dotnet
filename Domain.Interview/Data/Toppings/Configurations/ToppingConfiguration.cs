using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Interview.Data.Toppings.Configurations
{
    public class ToppingConfiguration : IEntityTypeConfiguration<Topping>
    {
        public void Configure(EntityTypeBuilder<Topping> builder)
        {
            builder.ToTable(name: nameof(Topping), schema: InterviewDbContext.Schema);
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name).HasMaxLength(32).IsRequired();

            builder.HasMany(x => x.PizzaToppings).WithOne(x => x.Topping).HasForeignKey(x => x.ToppingId);

            builder.HasIndex(x => x.Name).IsUnique();

            builder.HasData(Seed.Data.GetToppings());
        }
    }
}
