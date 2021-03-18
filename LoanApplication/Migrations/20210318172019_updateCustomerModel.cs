using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LoanApplication.Migrations
{
    public partial class updateCustomerModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LoanInfos_Customers_CustomerId",
                table: "LoanInfos");

            migrationBuilder.AlterColumn<Guid>(
                name: "CustomerId",
                table: "LoanInfos",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_LoanInfos_Customers_CustomerId",
                table: "LoanInfos",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LoanInfos_Customers_CustomerId",
                table: "LoanInfos");

            migrationBuilder.AlterColumn<Guid>(
                name: "CustomerId",
                table: "LoanInfos",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_LoanInfos_Customers_CustomerId",
                table: "LoanInfos",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
