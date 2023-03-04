using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class slug : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Slug",
                table: "Blogs",
                nullable: true);

            migrationBuilder.Sql("UPDATE Blogs SET Slug = REPLACE(LOWER(Title), ' ', '-')");

            migrationBuilder.AlterColumn<string>(
                name: "Slug",
                table: "Blogs",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
