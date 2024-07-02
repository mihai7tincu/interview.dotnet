using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interview.Data.Pizzas.Configurations
{
    public class PizzaConfiguration : IEntityTypeConfiguration<Pizza>
    {
        public void Configure(EntityTypeBuilder<Pizza> builder)
        {
            builder.ToTable(name: nameof(Pizza), schema: InterviewDbContext.Schema);
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name).HasMaxLength(64).IsRequired();
            builder.Property(x => x.CrustSize).IsRequired();
            builder.Property(x => x.CrustType).HasMaxLength(8).IsRequired(); ;

            builder.HasIndex(p => p.Name).IsUnique();
        }
    }
}
