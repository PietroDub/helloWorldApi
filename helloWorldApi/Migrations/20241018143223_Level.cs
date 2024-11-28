using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace helloWorldApi.Migrations
{
    /// <inheritdoc />
    public partial class Level : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NickName",
                table: "users");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "users");

            migrationBuilder.AddColumn<int>(
                name: "Level",
                table: "users",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Level",
                table: "users");

            migrationBuilder.AddColumn<string>(
                name: "NickName",
                table: "users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
