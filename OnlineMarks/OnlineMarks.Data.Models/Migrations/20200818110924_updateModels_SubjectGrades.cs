using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineMarks.Data.Models.Migrations
{
    public partial class updateModels_SubjectGrades : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Grade_Grades_SubjectGradeId",
                table: "Grade");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Grades",
                table: "Grades");

            migrationBuilder.RenameTable(
                name: "Grades",
                newName: "SubjectGrades");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SubjectGrades",
                table: "SubjectGrades",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Grade_SubjectGrades_SubjectGradeId",
                table: "Grade",
                column: "SubjectGradeId",
                principalTable: "SubjectGrades",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Grade_SubjectGrades_SubjectGradeId",
                table: "Grade");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SubjectGrades",
                table: "SubjectGrades");

            migrationBuilder.RenameTable(
                name: "SubjectGrades",
                newName: "Grades");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Grades",
                table: "Grades",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Grade_Grades_SubjectGradeId",
                table: "Grade",
                column: "SubjectGradeId",
                principalTable: "Grades",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
