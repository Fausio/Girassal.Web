using Microsoft.EntityFrameworkCore.Migrations;

namespace Girassal.Web.Data.Migrations
{
    public partial class clothingsList : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Invoice_Clothing_ClothingsId",
                table: "Invoice");

          

          

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "Invoice",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "InvoiceId",
                table: "Clothing",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Clothing",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateIndex(
                name: "IX_Clothing_InvoiceId",
                table: "Clothing",
                column: "InvoiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Clothing_Invoice_InvoiceId",
                table: "Clothing",
                column: "InvoiceId",
                principalTable: "Invoice",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clothing_Invoice_InvoiceId",
                table: "Clothing");

            migrationBuilder.DropIndex(
                name: "IX_Clothing_InvoiceId",
                table: "Clothing");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "Invoice");

            migrationBuilder.DropColumn(
                name: "InvoiceId",
                table: "Clothing");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Clothing");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "User",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.CreateIndex(
                name: "IX_Invoice_ClothingsId",
                table: "Invoice",
                column: "ClothingsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Invoice_Clothing_ClothingsId",
                table: "Invoice",
                column: "ClothingsId",
                principalTable: "Clothing",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_User_AspNetUsers_Id",
                table: "User",
                column: "Id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
