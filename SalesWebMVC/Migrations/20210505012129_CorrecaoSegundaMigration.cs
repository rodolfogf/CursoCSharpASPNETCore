using Microsoft.EntityFrameworkCore.Migrations;

namespace SalesWebMVC.Migrations
{
    public partial class CorrecaoSegundaMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Salary",
                table: "Seller",
                newName: "BaseSalary");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BaseSalary",
                table: "Seller",
                newName: "Salary");
        }
    }
}
