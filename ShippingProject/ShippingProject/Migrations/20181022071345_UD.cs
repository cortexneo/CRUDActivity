using Microsoft.EntityFrameworkCore.Migrations;

namespace ShippingProject.EFCore.Infra.Migrations
{
    public partial class UD : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Age",
                table: "Person");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "Person",
                nullable: false,
                defaultValue: 0);
        }
    }
}
