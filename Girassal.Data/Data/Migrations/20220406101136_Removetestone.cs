using Microsoft.EntityFrameworkCore.Migrations;

namespace Girassal.Web.Data.Migrations
{
    public partial class Removetestone : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "Client");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "Client",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
