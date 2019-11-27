using Microsoft.EntityFrameworkCore.Migrations;

namespace RepositoryLayer.Migrations
{
    public partial class dataMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NotesType",
                table: "notesUser");

            migrationBuilder.AddColumn<bool>(
                name: "IsArchive",
                table: "notesUser",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPin",
                table: "notesUser",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsTrash",
                table: "notesUser",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsArchive",
                table: "notesUser");

            migrationBuilder.DropColumn(
                name: "IsPin",
                table: "notesUser");

            migrationBuilder.DropColumn(
                name: "IsTrash",
                table: "notesUser");

            migrationBuilder.AddColumn<int>(
                name: "NotesType",
                table: "notesUser",
                nullable: false,
                defaultValue: 0);
        }
    }
}
