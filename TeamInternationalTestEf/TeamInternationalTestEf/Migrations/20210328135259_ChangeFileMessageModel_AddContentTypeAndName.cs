using Microsoft.EntityFrameworkCore.Migrations;

namespace TeamInternationalTestEf.Migrations
{
    public partial class ChangeFileMessageModel_AddContentTypeAndName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ContentType",
                table: "FileMessages",
                type: "nvarchar(80)",
                maxLength: 80,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "FileMessages",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContentType",
                table: "FileMessages");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "FileMessages");
        }
    }
}
