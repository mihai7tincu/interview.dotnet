using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Interview.Data.Customers.Configurations
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable(name: nameof(Customer), schema: InterviewDbContext.Schema);
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name).HasMaxLength(128).IsRequired();
            builder.Property(x => x.Phone).HasMaxLength(32).IsRequired();
            builder.Property(x => x.Address).HasMaxLength(128).IsRequired();

            builder.HasMany(x => x.Orders).WithOne(x => x.Customer).HasForeignKey(x => x.CustomerId);

            builder.HasIndex(x => x.Phone).IsUnique();
        }
    }
}
