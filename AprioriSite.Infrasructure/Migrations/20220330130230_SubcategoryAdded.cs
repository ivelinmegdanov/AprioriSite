using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AprioriSite.Infrasructure.Migrations
{
    public partial class SubcategoryAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Subcategory",
                table: "Items",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Subcategory",
                table: "Items");
        }
    }
}
