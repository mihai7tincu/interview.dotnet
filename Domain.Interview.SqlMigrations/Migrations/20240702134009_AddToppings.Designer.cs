﻿// <auto-generated />
using Domain.Interview;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Domain.Interview.SqlMigrations.Migrations
{
    [DbContext(typeof(InterviewDbContext))]
    [Migration("20240702134009_AddToppings")]
    partial class AddToppings
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("interview")
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Domain.Interview.Data.Pizzas.Pizza", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<byte>("CrustSize")
                        .HasColumnType("tinyint");

                    b.Property<string>("CrustType")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("nvarchar(8)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Pizza", "interview");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            CrustSize = (byte)28,
                            CrustType = "Thin",
                            Name = "Pepperoni"
                        },
                        new
                        {
                            Id = 2L,
                            CrustSize = (byte)32,
                            CrustType = "Normal",
                            Name = "Funghi"
                        },
                        new
                        {
                            Id = 3L,
                            CrustSize = (byte)40,
                            CrustType = "Thick",
                            Name = "Margherita"
                        });
                });

            modelBuilder.Entity("Domain.Interview.Data.Toppings.Topping", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("nvarchar(32)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Topping", "interview");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Name = "Cheese"
                        },
                        new
                        {
                            Id = 2L,
                            Name = "Pepperoni"
                        },
                        new
                        {
                            Id = 3L,
                            Name = "Mushrooms"
                        },
                        new
                        {
                            Id = 4L,
                            Name = "Tomato"
                        },
                        new
                        {
                            Id = 5L,
                            Name = "Basil"
                        },
                        new
                        {
                            Id = 6L,
                            Name = "Mozzarella"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
