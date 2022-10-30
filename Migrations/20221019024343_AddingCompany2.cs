using Microsoft.EntityFrameworkCore.Migrations;

namespace Mobi__Shop.Migrations
{
    public partial class AddingCompany2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CategoryCompany_Company_CompaniesID",
                table: "CategoryCompany");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Company",
                table: "Company");

            migrationBuilder.RenameTable(
                name: "Company",
                newName: "Companies");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Companies",
                table: "Companies",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryCompany_Companies_CompaniesID",
                table: "CategoryCompany",
                column: "CompaniesID",
                principalTable: "Companies",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CategoryCompany_Companies_CompaniesID",
                table: "CategoryCompany");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Companies",
                table: "Companies");

            migrationBuilder.RenameTable(
                name: "Companies",
                newName: "Company");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Company",
                table: "Company",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryCompany_Company_CompaniesID",
                table: "CategoryCompany",
                column: "CompaniesID",
                principalTable: "Company",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
