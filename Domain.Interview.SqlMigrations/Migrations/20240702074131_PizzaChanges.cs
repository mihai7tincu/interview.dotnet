using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Domain.Interview.SqlMigrations.Migrations
{
    /// <inheritdoc />
    public partial class PizzaChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Toppings",
                schema: "interview",
                table: "Pizza");

            migrationBuilder.InsertData(
                schema: "interview",
                table: "Pizza",
                columns: new[] { "Id", "CrustSize", "CrustType", "Name" },
                values: new object[,]
                {
                    { 1L, (byte)28, "Thin", "Pepperoni" },
                    { 2L, (byte)32, "Normal", "Funghi" },
                    { 3L, (byte)40, "Thick", "Margherita" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "interview",
                table: "Pizza",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                schema: "interview",
                table: "Pizza",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                schema: "interview",
                table: "Pizza",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.AddColumn<string>(
                name: "Toppings",
                schema: "interview",
                table: "Pizza",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
