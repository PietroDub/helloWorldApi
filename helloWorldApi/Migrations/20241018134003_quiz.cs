using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace helloWorldApi.Migrations
{
    /// <inheritdoc />
    public partial class quiz : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Level",
                table: "users");

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}
