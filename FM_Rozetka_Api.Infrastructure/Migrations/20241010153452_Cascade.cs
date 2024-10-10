using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FM_Rozetka_Api.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Cascade : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Видаляємо існуючий зовнішній ключ перед створенням нового
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Shops_ShopId",
                table: "Products");

            // Додаємо новий зовнішній ключ з каскадним видаленням
            migrationBuilder.AddForeignKey(
                name: "FK_Products_Shops_ShopId",
                table: "Products",
                column: "ShopId",
                principalTable: "Shops",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            // Видаляємо існуючий зовнішній ключ перед створенням нового
            migrationBuilder.DropForeignKey(
                name: "FK_Shops_Companies_CompanyId",
                table: "Shops");

            // Додаємо новий зовнішній ключ з каскадним видаленням
            migrationBuilder.AddForeignKey(
                name: "FK_Shops_Companies_CompanyId",
                table: "Shops",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Відновлюємо первісні зовнішні ключі з обмеженням
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Shops_ShopId",
                table: "Products");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Shops_ShopId",
                table: "Products",
                column: "ShopId",
                principalTable: "Shops",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.DropForeignKey(
                name: "FK_Shops_Companies_CompanyId",
                table: "Shops");

            migrationBuilder.AddForeignKey(
                name: "FK_Shops_Companies_CompanyId",
                table: "Shops",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
