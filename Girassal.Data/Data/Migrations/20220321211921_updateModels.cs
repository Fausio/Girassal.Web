using Microsoft.EntityFrameworkCore.Migrations;

namespace Girassal.Web.Data.Migrations
{
    public partial class updateModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clothing_Invoice_InvoiceId",
                table: "Clothing");

            migrationBuilder.DropIndex(
                name: "IX_Clothing_InvoiceId",
                table: "Clothing");

            migrationBuilder.DropColumn(
                name: "InvoiceId",
                table: "Clothing");

            migrationBuilder.AddColumn<int>(
                name: "ClothingsId",
                table: "Invoice",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetUserTokens",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserTokens",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                table: "AspNetUserLogins",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserLogins",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Invoice_Clothing_ClothingsId",
                table: "Invoice");

            migrationBuilder.DropIndex(
                name: "IX_Invoice_ClothingsId",
                table: "Invoice");

            migrationBuilder.DropColumn(
                name: "ClothingsId",
                table: "Invoice");

            migrationBuilder.AddColumn<int>(
                name: "InvoiceId",
                table: "Clothing",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetUserTokens",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserTokens",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                table: "AspNetUserLogins",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserLogins",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

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
    }
}
