using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineMarks.Data.Models.Migrations
{
    public partial class updateModels_Users : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppUsers_AppUsers_ParentId",
                table: "AppUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Subjects_AppUsers_ProfessorId",
                table: "Subjects");

            migrationBuilder.DropForeignKey(
                name: "FK_Subjects_AppUsers_StudentId",
                table: "Subjects");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AppUsers",
                table: "AppUsers");

            migrationBuilder.RenameTable(
                name: "AppUsers",
                newName: "Users");

            migrationBuilder.RenameIndex(
                name: "IX_AppUsers_ParentId",
                table: "Users",
                newName: "IX_Users_ParentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Subjects_Users_ProfessorId",
                table: "Subjects",
                column: "ProfessorId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Subjects_Users_StudentId",
                table: "Subjects",
                column: "StudentId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Users_ParentId",
                table: "Users",
                column: "ParentId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Subjects_Users_ProfessorId",
                table: "Subjects");

            migrationBuilder.DropForeignKey(
                name: "FK_Subjects_Users_StudentId",
                table: "Subjects");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Users_ParentId",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "AppUsers");

            migrationBuilder.RenameIndex(
                name: "IX_Users_ParentId",
                table: "AppUsers",
                newName: "IX_AppUsers_ParentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AppUsers",
                table: "AppUsers",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AppUsers_AppUsers_ParentId",
                table: "AppUsers",
                column: "ParentId",
                principalTable: "AppUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Subjects_AppUsers_ProfessorId",
                table: "Subjects",
                column: "ProfessorId",
                principalTable: "AppUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Subjects_AppUsers_StudentId",
                table: "Subjects",
                column: "StudentId",
                principalTable: "AppUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
