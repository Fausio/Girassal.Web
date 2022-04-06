using Microsoft.EntityFrameworkCore.Migrations;

namespace Girassal.Web.Data.Migrations
{
    public partial class statuscodes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "statusCode",
                table: "SimpleEntity",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "statusCode",
                table: "SimpleEntity");
        }
    }
}
