using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineMarks.Data.Models.Migrations
{
    public partial class Messages_added : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Users_ParentId",
                table: "Messages");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Users_ProfessorId",
                table: "Messages");

            migrationBuilder.DropIndex(
                name: "IX_Messages_ParentId",
                table: "Messages");

            migrationBuilder.DropIndex(
                name: "IX_Messages_ProfessorId",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "ParentId",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "ProfessorId",
                table: "Messages");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "ParentId",
                table: "Messages",
                type: "varbinary(16)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "ProfessorId",
                table: "Messages",
                type: "varbinary(16)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Messages_ParentId",
                table: "Messages",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_ProfessorId",
                table: "Messages",
                column: "ProfessorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Users_ParentId",
                table: "Messages",
                column: "ParentId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Users_ProfessorId",
                table: "Messages",
                column: "ProfessorId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
