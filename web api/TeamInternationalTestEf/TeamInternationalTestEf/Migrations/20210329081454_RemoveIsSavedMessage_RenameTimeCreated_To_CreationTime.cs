using Microsoft.EntityFrameworkCore.Migrations;

namespace TeamInternationalTestEf.Migrations
{
    public partial class RemoveIsSavedMessage_RenameTimeCreated_To_CreationTime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsSavedMessage",
                table: "TextMessages");

            migrationBuilder.DropColumn(
                name: "IsSavedMessage",
                table: "FileMessages");

            migrationBuilder.RenameColumn(
                name: "TimeCreated",
                table: "TextMessages",
                newName: "CreationTime");

            migrationBuilder.RenameColumn(
                name: "TimeCreated",
                table: "FileMessages",
                newName: "CreationTime");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CreationTime",
                table: "TextMessages",
                newName: "TimeCreated");

            migrationBuilder.RenameColumn(
                name: "CreationTime",
                table: "FileMessages",
                newName: "TimeCreated");

            migrationBuilder.AddColumn<bool>(
                name: "IsSavedMessage",
                table: "TextMessages",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsSavedMessage",
                table: "FileMessages",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
