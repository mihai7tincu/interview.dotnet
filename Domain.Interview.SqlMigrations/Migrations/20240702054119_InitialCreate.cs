using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

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
                    CrustType = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    Toppings = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pizza", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pizza_Name",
                schema: "interview",
                table: "Pizza",
                column: "Name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pizza",
                schema: "interview");
        }
    }
}
