using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Flight.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Flights",
                columns: table => new
                {
                    FlightNumber = table.Column<string>(type: "TEXT", maxLength: 10, nullable: false),
                    FromCity = table.Column<string>(type: "TEXT", nullable: false),
                    ToCity = table.Column<string>(type: "TEXT", nullable: false),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Price = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flights", x => x.FlightNumber);
                });

            migrationBuilder.InsertData(
                table: "Flights",
                columns: new[] { "FlightNumber", "Date", "FromCity", "Price", "ToCity" },
                values: new object[,]
                {
                    { "CA9087", new DateTime(2026, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hong Kong", 900m, "San Francisco" },
                    { "QA1078", new DateTime(2026, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dubai", 590m, "London" },
                    { "UA3321", new DateTime(2026, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Chicago", 235m, "New York" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Flights");
        }
    }
}
