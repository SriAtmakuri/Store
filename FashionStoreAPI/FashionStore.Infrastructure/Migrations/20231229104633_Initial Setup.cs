using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FashionStore.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialSetup : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    CountryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CountryCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CurrencyCode = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.CountryId);
                });

            migrationBuilder.CreateTable(
                name: "CurrencyExchangeRates",
                columns: table => new
                {
                    CurrencyExchangeRateId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExchangeRate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CurrencyCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ValidFromDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ValidToDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CurrencyExchangeRates", x => x.CurrencyExchangeRateId);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "CountryId", "CountryCode", "CurrencyCode", "Name" },
                values: new object[,]
                {
                    { 1, "USA", "USD", "United States of America" },
                    { 2, "DEU", "EUR", "Deutschland" },
                    { 3, "AUS", "AUD", "Australia" }
                });

            migrationBuilder.InsertData(
                table: "CurrencyExchangeRates",
                columns: new[] { "CurrencyExchangeRateId", "CurrencyCode", "ExchangeRate", "ValidFromDate", "ValidToDate" },
                values: new object[,]
                {
                    { 1, "USD", 1.24m, new DateTime(2023, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 2, "EUR", 1.14m, new DateTime(2023, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 3, "AUD", 1.92m, new DateTime(2023, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 4, "USD", 1.29m, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, "EUR", 1.16m, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "Description", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "Mens t-shirt, size medium", "T-shirt", 19.99m },
                    { 2, "Womens jeans, size small", "Jeans", 45.99m },
                    { 3, "Summer hat, one size", "Hat", 10.99m },
                    { 4, "Unisex winter jacket, size large", "Coat", 80.99m },
                    { 5, "Womens fashion footwear, size 37", "Trainers", 55.99m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropTable(
                name: "CurrencyExchangeRates");

            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
