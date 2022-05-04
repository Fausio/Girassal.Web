using Microsoft.EntityFrameworkCore.Migrations;

namespace Girassal.Web.Data.Migrations
{
    public partial class code : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "User",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "SimpleEntity",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "Invoice",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "Clothing",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "Client",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Code",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "SimpleEntity");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "Invoice");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "Clothing");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "Client");
        }
    }
}
