﻿// <auto-generated />
using System;
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
    [Migration("20240703081306_AddOrders")]
    partial class AddOrders
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

            modelBuilder.Entity("Domain.Interview.Data.Customers.Customer", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("nvarchar(32)");

                    b.HasKey("Id");

                    b.HasIndex("Phone")
                        .IsUnique();

                    b.ToTable("Customer", "interview");
                });

            modelBuilder.Entity("Domain.Interview.Data.Orders.Order", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<long>("CustomerId")
                        .HasColumnType("bigint");

                    b.Property<DateTimeOffset>("Timestamp")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetimeoffset")
                        .HasDefaultValue(new DateTimeOffset(new DateTime(2024, 7, 3, 8, 13, 5, 679, DateTimeKind.Unspecified).AddTicks(6515), new TimeSpan(0, 0, 0, 0, 0)));

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("Order", "interview");
                });

            modelBuilder.Entity("Domain.Interview.Data.Orders.OrderPizza", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<long>("OrderId")
                        .HasColumnType("bigint");

                    b.Property<long>("PizzaId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("PizzaId");

                    b.ToTable("OrderPizza", "interview");
                });

            modelBuilder.Entity("Domain.Interview.Data.Pizzas.Pizza", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<byte>("CrustSize")
                        .HasColumnType("tinyint");

                    b.Property<int>("CrustType")
                        .HasColumnType("int");

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
                            CrustType = 1,
                            Name = "Pepperoni"
                        },
                        new
                        {
                            Id = 2L,
                            CrustSize = (byte)32,
                            CrustType = 2,
                            Name = "Funghi"
                        },
                        new
                        {
                            Id = 3L,
                            CrustSize = (byte)40,
                            CrustType = 3,
                            Name = "Margherita"
                        });
                });

            modelBuilder.Entity("Domain.Interview.Data.Pizzas.PizzaTopping", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<long>("PizzaId")
                        .HasColumnType("bigint");

                    b.Property<long>("ToppingId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("PizzaId");

                    b.HasIndex("ToppingId");

                    b.ToTable("PizzaTopping", "interview");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            PizzaId = 1L,
                            ToppingId = 1L
                        },
                        new
                        {
                            Id = 2L,
                            PizzaId = 1L,
                            ToppingId = 2L
                        },
                        new
                        {
                            Id = 3L,
                            PizzaId = 2L,
                            ToppingId = 1L
                        },
                        new
                        {
                            Id = 4L,
                            PizzaId = 2L,
                            ToppingId = 2L
                        },
                        new
                        {
                            Id = 5L,
                            PizzaId = 2L,
                            ToppingId = 3L
                        },
                        new
                        {
                            Id = 6L,
                            PizzaId = 3L,
                            ToppingId = 4L
                        },
                        new
                        {
                            Id = 7L,
                            PizzaId = 3L,
                            ToppingId = 5L
                        },
                        new
                        {
                            Id = 8L,
                            PizzaId = 3L,
                            ToppingId = 6L
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
                        },
                        new
                        {
                            Id = 7L,
                            Name = "Chorizo"
                        },
                        new
                        {
                            Id = 8L,
                            Name = "Jalapeno"
                        });
                });

            modelBuilder.Entity("Domain.Interview.Data.Orders.Order", b =>
                {
                    b.HasOne("Domain.Interview.Data.Customers.Customer", "Customer")
                        .WithMany("Orders")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("Domain.Interview.Data.Orders.OrderPizza", b =>
                {
                    b.HasOne("Domain.Interview.Data.Orders.Order", "Order")
                        .WithMany("OrderPizzas")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Interview.Data.Pizzas.Pizza", "Pizza")
                        .WithMany("OrderPizzas")
                        .HasForeignKey("PizzaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Pizza");
                });

            modelBuilder.Entity("Domain.Interview.Data.Pizzas.PizzaTopping", b =>
                {
                    b.HasOne("Domain.Interview.Data.Pizzas.Pizza", "Pizza")
                        .WithMany("PizzaToppings")
                        .HasForeignKey("PizzaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Interview.Data.Toppings.Topping", "Topping")
                        .WithMany("PizzaToppings")
                        .HasForeignKey("ToppingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pizza");

                    b.Navigation("Topping");
                });

            modelBuilder.Entity("Domain.Interview.Data.Customers.Customer", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("Domain.Interview.Data.Orders.Order", b =>
                {
                    b.Navigation("OrderPizzas");
                });

            modelBuilder.Entity("Domain.Interview.Data.Pizzas.Pizza", b =>
                {
                    b.Navigation("OrderPizzas");

                    b.Navigation("PizzaToppings");
                });

            modelBuilder.Entity("Domain.Interview.Data.Toppings.Topping", b =>
                {
                    b.Navigation("PizzaToppings");
                });
#pragma warning restore 612, 618
        }
    }
}
