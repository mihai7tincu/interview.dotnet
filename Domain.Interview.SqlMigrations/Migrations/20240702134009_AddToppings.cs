using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Domain.Interview.SqlMigrations.Migrations
{
    /// <inheritdoc />
    public partial class AddToppings : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Topping",
                schema: "interview",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Topping", x => x.Id);
                });

            migrationBuilder.InsertData(
                schema: "interview",
                table: "Topping",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1L, "Cheese" },
                    { 2L, "Pepperoni" },
                    { 3L, "Mushrooms" },
                    { 4L, "Tomato" },
                    { 5L, "Basil" },
                    { 6L, "Mozzarella" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Topping_Name",
                schema: "interview",
                table: "Topping",
                column: "Name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Topping",
                schema: "interview");
        }
    }
}
