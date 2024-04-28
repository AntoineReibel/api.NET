using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace apindien2.Migrations
{
    /// <inheritdoc />
    public partial class seed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Villa");

            migrationBuilder.InsertData(
                table: "Villa",
                columns: new[] { "Id", "CreatedAt", "Name", "Occupancy", "Surface", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 3, 30, 18, 49, 46, 413, DateTimeKind.Local).AddTicks(2531), "Villa 1", 4, 100, new DateTime(2024, 3, 30, 18, 49, 46, 413, DateTimeKind.Local).AddTicks(2659) },
                    { 2, new DateTime(2024, 3, 30, 18, 49, 46, 413, DateTimeKind.Local).AddTicks(2663), "Villa 2", 6, 200, new DateTime(2024, 3, 30, 18, 49, 46, 413, DateTimeKind.Local).AddTicks(2664) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Villa",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Villa",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Villa",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }
    }
}
