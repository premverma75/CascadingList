using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CascadingList.Migrations
{
    /// <inheritdoc />
    public partial class AddNewProperty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Registers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Registers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Createdby",
                table: "Registers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "Isactive",
                table: "Registers",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Mobile",
                table: "Registers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "Registers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Updatedby",
                table: "Registers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Logins",
                type: "bit",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "Registers");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Registers");

            migrationBuilder.DropColumn(
                name: "Createdby",
                table: "Registers");

            migrationBuilder.DropColumn(
                name: "Isactive",
                table: "Registers");

            migrationBuilder.DropColumn(
                name: "Mobile",
                table: "Registers");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "Registers");

            migrationBuilder.DropColumn(
                name: "Updatedby",
                table: "Registers");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Logins");
        }
    }
}
