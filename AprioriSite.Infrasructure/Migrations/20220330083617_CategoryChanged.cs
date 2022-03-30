using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AprioriSite.Infrasructure.Migrations
{
    public partial class CategoryChanged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_Categories_CaregoryId",
                table: "Items");

            migrationBuilder.DropIndex(
                name: "IX_Items_CaregoryId",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "CaregoryId",
                table: "Items");

            migrationBuilder.AddColumn<Guid>(
                name: "CategoryId",
                table: "Items",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Categoty",
                table: "Items",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Items_CategoryId",
                table: "Items",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Categories_CategoryId",
                table: "Items",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_Categories_CategoryId",
                table: "Items");

            migrationBuilder.DropIndex(
                name: "IX_Items_CategoryId",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "Categoty",
                table: "Items");

            migrationBuilder.AddColumn<Guid>(
                name: "CaregoryId",
                table: "Items",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Items_CaregoryId",
                table: "Items",
                column: "CaregoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Categories_CaregoryId",
                table: "Items",
                column: "CaregoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
