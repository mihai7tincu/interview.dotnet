using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Interview.Data.Orders.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable(name: nameof(Order), schema: InterviewDbContext.Schema);
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Timestamp).IsRequired().HasDefaultValue(DateTimeOffset.UtcNow);
            builder.Property(x => x.CustomerId).IsRequired();

            builder.HasMany(x => x.OrderPizzas).WithOne(x => x.Order).HasForeignKey(x => x.OrderId);
        }
    }
}
