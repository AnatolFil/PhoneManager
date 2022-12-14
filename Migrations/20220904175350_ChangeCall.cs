using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PhoneManager.Migrations
{
    public partial class ChangeCall : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_PhoneNumbers_PhoneNumberId",
                table: "Contacts");

            migrationBuilder.AlterColumn<Guid>(
                name: "PhoneNumberId",
                table: "Contacts",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_Contacts_PhoneNumbers_PhoneNumberId",
                table: "Contacts",
                column: "PhoneNumberId",
                principalTable: "PhoneNumbers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_PhoneNumbers_PhoneNumberId",
                table: "Contacts");

            migrationBuilder.AlterColumn<Guid>(
                name: "PhoneNumberId",
                table: "Contacts",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Contacts_PhoneNumbers_PhoneNumberId",
                table: "Contacts",
                column: "PhoneNumberId",
                principalTable: "PhoneNumbers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
