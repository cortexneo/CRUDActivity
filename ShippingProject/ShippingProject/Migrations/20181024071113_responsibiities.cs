using Microsoft.EntityFrameworkCore.Migrations;

namespace ShippingProject.EFCore.Infra.Migrations
{
    public partial class responsibiities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "isActive",
                table: "Responsibility",
                nullable: false,
                oldClrType: typeof(string));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "isActive",
                table: "Responsibility",
                nullable: false,
                oldClrType: typeof(bool));
        }
    }
}
