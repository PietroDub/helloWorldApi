using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace helloWorldApi.Migrations
{
    /// <inheritdoc />
    public partial class Quizzes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sales_appcontacts_CourseId",
                table: "Sales");

            migrationBuilder.DropForeignKey(
                name: "FK_Sales_users_AppUserId",
                table: "Sales");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Sales",
                table: "Sales");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Question",
                table: "Question");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Appontacts",
                table: "Appontacts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_appcontacts",
                table: "appcontacts");

            migrationBuilder.RenameTable(
                name: "Sales",
                newName: "sales");

            migrationBuilder.RenameTable(
                name: "Question",
                newName: "quizzes");

            migrationBuilder.RenameTable(
                name: "Appontacts",
                newName: "contacts");

            migrationBuilder.RenameTable(
                name: "appcontacts",
                newName: "courses");

            migrationBuilder.RenameIndex(
                name: "IX_Sales_CourseId",
                table: "sales",
                newName: "IX_sales_CourseId");

            migrationBuilder.RenameIndex(
                name: "IX_Sales_AppUserId",
                table: "sales",
                newName: "IX_sales_AppUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_sales",
                table: "sales",
                column: "SaleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_quizzes",
                table: "quizzes",
                column: "QuizId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_contacts",
                table: "contacts",
                column: "AppcontactId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_courses",
                table: "courses",
                column: "CourseId");

            migrationBuilder.AddForeignKey(
                name: "FK_sales_courses_CourseId",
                table: "sales",
                column: "CourseId",
                principalTable: "courses",
                principalColumn: "CourseId");

            migrationBuilder.AddForeignKey(
                name: "FK_sales_users_AppUserId",
                table: "sales",
                column: "AppUserId",
                principalTable: "users",
                principalColumn: "AppuserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_sales_courses_CourseId",
                table: "sales");

            migrationBuilder.DropForeignKey(
                name: "FK_sales_users_AppUserId",
                table: "sales");

            migrationBuilder.DropPrimaryKey(
                name: "PK_sales",
                table: "sales");

            migrationBuilder.DropPrimaryKey(
                name: "PK_quizzes",
                table: "quizzes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_courses",
                table: "courses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_contacts",
                table: "contacts");

            migrationBuilder.RenameTable(
                name: "sales",
                newName: "Sales");

            migrationBuilder.RenameTable(
                name: "quizzes",
                newName: "Question");

            migrationBuilder.RenameTable(
                name: "courses",
                newName: "appcontacts");

            migrationBuilder.RenameTable(
                name: "contacts",
                newName: "Appontacts");

            migrationBuilder.RenameIndex(
                name: "IX_sales_CourseId",
                table: "Sales",
                newName: "IX_Sales_CourseId");

            migrationBuilder.RenameIndex(
                name: "IX_sales_AppUserId",
                table: "Sales",
                newName: "IX_Sales_AppUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Sales",
                table: "Sales",
                column: "SaleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Question",
                table: "Question",
                column: "QuizId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_appcontacts",
                table: "appcontacts",
                column: "CourseId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Appontacts",
                table: "Appontacts",
                column: "AppcontactId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sales_appcontacts_CourseId",
                table: "Sales",
                column: "CourseId",
                principalTable: "appcontacts",
                principalColumn: "CourseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sales_users_AppUserId",
                table: "Sales",
                column: "AppUserId",
                principalTable: "users",
                principalColumn: "AppuserId");
        }
    }
}
