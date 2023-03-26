using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class Mig_CommentAnswer2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CommentAnswers_Comments_CommentId",
                table: "CommentAnswers");

            migrationBuilder.AddForeignKey(
                name: "FK_CommentAnswers_Comments_CommentId",
                table: "CommentAnswers",
                column: "CommentId",
                principalTable: "Comments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CommentAnswers_Comments_CommentId",
                table: "CommentAnswers");

            migrationBuilder.AddForeignKey(
                name: "FK_CommentAnswers_Comments_CommentId",
                table: "CommentAnswers",
                column: "CommentId",
                principalTable: "Comments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
