using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace daw.Migrations
{
    public partial class initialMigrate5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Wishlist_WishlistId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_WishlistId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "WishlistId",
                table: "Products");

            migrationBuilder.AddColumn<int>(
                name: "ProductsId",
                table: "Wishlist",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Wishlist_ProductsId",
                table: "Wishlist",
                column: "ProductsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Wishlist_Products_ProductsId",
                table: "Wishlist",
                column: "ProductsId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Wishlist_Products_ProductsId",
                table: "Wishlist");

            migrationBuilder.DropIndex(
                name: "IX_Wishlist_ProductsId",
                table: "Wishlist");

            migrationBuilder.DropColumn(
                name: "ProductsId",
                table: "Wishlist");

            migrationBuilder.AddColumn<int>(
                name: "WishlistId",
                table: "Products",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_WishlistId",
                table: "Products",
                column: "WishlistId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Wishlist_WishlistId",
                table: "Products",
                column: "WishlistId",
                principalTable: "Wishlist",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
