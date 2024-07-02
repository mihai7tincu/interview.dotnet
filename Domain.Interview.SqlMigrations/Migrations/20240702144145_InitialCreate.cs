using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Domain.Interview.SqlMigrations.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "interview");

            migrationBuilder.CreateTable(
                name: "Pizza",
                schema: "interview",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    CrustSize = table.Column<byte>(type: "tinyint", nullable: false),
                    CrustType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pizza", x => x.Id);
                });

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

            migrationBuilder.CreateTable(
                name: "PizzaTopping",
                schema: "interview",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PizzaId = table.Column<long>(type: "bigint", nullable: false),
                    ToppingId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PizzaTopping", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PizzaTopping_Pizza_PizzaId",
                        column: x => x.PizzaId,
                        principalSchema: "interview",
                        principalTable: "Pizza",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PizzaTopping_Topping_ToppingId",
                        column: x => x.ToppingId,
                        principalSchema: "interview",
                        principalTable: "Topping",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "interview",
                table: "Pizza",
                columns: new[] { "Id", "CrustSize", "CrustType", "Name" },
                values: new object[,]
                {
                    { 1L, (byte)28, 1, "Pepperoni" },
                    { 2L, (byte)32, 2, "Funghi" },
                    { 3L, (byte)40, 3, "Margherita" }
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
                    { 6L, "Mozzarella" },
                    { 7L, "Chorizo" },
                    { 8L, "Jalapeno" }
                });

            migrationBuilder.InsertData(
                schema: "interview",
                table: "PizzaTopping",
                columns: new[] { "Id", "PizzaId", "ToppingId" },
                values: new object[,]
                {
                    { 1L, 1L, 1L },
                    { 2L, 1L, 2L },
                    { 3L, 2L, 1L },
                    { 4L, 2L, 2L },
                    { 5L, 2L, 3L },
                    { 6L, 3L, 4L },
                    { 7L, 3L, 5L },
                    { 8L, 3L, 6L }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pizza_Name",
                schema: "interview",
                table: "Pizza",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PizzaTopping_PizzaId",
                schema: "interview",
                table: "PizzaTopping",
                column: "PizzaId");

            migrationBuilder.CreateIndex(
                name: "IX_PizzaTopping_ToppingId",
                schema: "interview",
                table: "PizzaTopping",
                column: "ToppingId");

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
                name: "PizzaTopping",
                schema: "interview");

            migrationBuilder.DropTable(
                name: "Pizza",
                schema: "interview");

            migrationBuilder.DropTable(
                name: "Topping",
                schema: "interview");
        }
    }
}
