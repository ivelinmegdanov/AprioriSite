using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AprioriSite.Infrasructure.Migrations
{
    public partial class UpvotesAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Upvotes",
                table: "Items",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Upvotes",
                table: "Items");
        }
    }
}
