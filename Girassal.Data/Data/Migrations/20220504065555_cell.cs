using Microsoft.EntityFrameworkCore.Migrations;

namespace Girassal.Web.Data.Migrations
{
    public partial class cell : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Cell",
                table: "Client",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cell",
                table: "Client");
        }
    }
}
