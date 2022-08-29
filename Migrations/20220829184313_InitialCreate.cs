using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PhoneManager.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Calls_Contacts_CallerId",
                table: "Calls");

            migrationBuilder.DropForeignKey(
                name: "FK_Calls_Contacts_SubscriberId",
                table: "Calls");

            migrationBuilder.AlterColumn<Guid>(
                name: "SubscriberId",
                table: "Calls",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "CallerId",
                table: "Calls",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_Calls_Contacts_CallerId",
                table: "Calls",
                column: "CallerId",
                principalTable: "Contacts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Calls_Contacts_SubscriberId",
                table: "Calls",
                column: "SubscriberId",
                principalTable: "Contacts",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Calls_Contacts_CallerId",
                table: "Calls");

            migrationBuilder.DropForeignKey(
                name: "FK_Calls_Contacts_SubscriberId",
                table: "Calls");

            migrationBuilder.AlterColumn<Guid>(
                name: "SubscriberId",
                table: "Calls",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "CallerId",
                table: "Calls",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Calls_Contacts_CallerId",
                table: "Calls",
                column: "CallerId",
                principalTable: "Contacts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Calls_Contacts_SubscriberId",
                table: "Calls",
                column: "SubscriberId",
                principalTable: "Contacts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
