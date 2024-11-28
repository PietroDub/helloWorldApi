using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace helloWorldApi.Migrations
{
    /// <inheritdoc />
    public partial class quizs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Question",
                columns: table => new
                {
                    QuizId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Question = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Answear = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CourseId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CourseName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AppuserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Level = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Question", x => x.QuizId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Question");
        }
    }
}
