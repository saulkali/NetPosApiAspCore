using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PyPosApi.Migrations
{
    /// <inheritdoc />
    public partial class agregandoRestoSchemesDataBase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "UserSchemes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "UserSchemes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "CodePostal",
                table: "UserSchemes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "RFC",
                table: "UserSchemes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "UserRolSchemes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "Status",
                table: "UserRolSchemes",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "UserSchemes");

            migrationBuilder.DropColumn(
                name: "City",
                table: "UserSchemes");

            migrationBuilder.DropColumn(
                name: "CodePostal",
                table: "UserSchemes");

            migrationBuilder.DropColumn(
                name: "RFC",
                table: "UserSchemes");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "UserRolSchemes");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "UserRolSchemes");
        }
    }
}
