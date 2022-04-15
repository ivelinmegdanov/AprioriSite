using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AprioriSite.Infrasructure.Migrations
{
    public partial class DeletedItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Promocode",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "CustomPicture",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "Upvotes",
                table: "Items");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Promocode",
                table: "Transactions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CustomPicture",
                table: "Items",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Upvotes",
                table: "Items",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
