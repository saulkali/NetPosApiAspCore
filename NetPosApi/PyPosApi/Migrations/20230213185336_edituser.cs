using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PyPosApi.Migrations
{
    /// <inheritdoc />
    public partial class edituser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserSchemes_UserRolSchemes_UserRolSchemeId",
                table: "UserSchemes");

            migrationBuilder.RenameColumn(
                name: "UserRolSchemeId",
                table: "UserSchemes",
                newName: "IdUserRolScheme");

            migrationBuilder.RenameIndex(
                name: "IX_UserSchemes_UserRolSchemeId",
                table: "UserSchemes",
                newName: "IX_UserSchemes_IdUserRolScheme");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "UserSchemes",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "UserSchemes",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "UserSchemes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_UserSchemes_UserRolSchemes_IdUserRolScheme",
                table: "UserSchemes",
                column: "IdUserRolScheme",
                principalTable: "UserRolSchemes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserSchemes_UserRolSchemes_IdUserRolScheme",
                table: "UserSchemes");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "UserSchemes");

            migrationBuilder.RenameColumn(
                name: "IdUserRolScheme",
                table: "UserSchemes",
                newName: "UserRolSchemeId");

            migrationBuilder.RenameIndex(
                name: "IX_UserSchemes_IdUserRolScheme",
                table: "UserSchemes",
                newName: "IX_UserSchemes_UserRolSchemeId");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "UserSchemes",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "UserSchemes",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30);

            migrationBuilder.AddForeignKey(
                name: "FK_UserSchemes_UserRolSchemes_UserRolSchemeId",
                table: "UserSchemes",
                column: "UserRolSchemeId",
                principalTable: "UserRolSchemes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
