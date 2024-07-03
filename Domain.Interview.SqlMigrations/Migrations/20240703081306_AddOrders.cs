using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Domain.Interview.SqlMigrations.Migrations
{
    /// <inheritdoc />
    public partial class AddOrders : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "Timestamp",
                schema: "interview",
                table: "Order",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2024, 7, 3, 8, 13, 5, 679, DateTimeKind.Unspecified).AddTicks(6515), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldDefaultValue: new DateTimeOffset(new DateTime(2024, 7, 2, 16, 41, 55, 644, DateTimeKind.Unspecified).AddTicks(534), new TimeSpan(0, 0, 0, 0, 0)));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "Timestamp",
                schema: "interview",
                table: "Order",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2024, 7, 2, 16, 41, 55, 644, DateTimeKind.Unspecified).AddTicks(534), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldDefaultValue: new DateTimeOffset(new DateTime(2024, 7, 3, 8, 13, 5, 679, DateTimeKind.Unspecified).AddTicks(6515), new TimeSpan(0, 0, 0, 0, 0)));
        }
    }
}
