using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RepositoryLayer.Migrations
{
    public partial class collabaration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_CollaborateUser",
                table: "CollaborateUser");

            migrationBuilder.AlterColumn<string>(
                name: "CollaborateById",
                table: "CollaborateUser",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "CollaborateUser",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_CollaborateUser",
                table: "CollaborateUser",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_CollaborateUser",
                table: "CollaborateUser");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "CollaborateUser");

            migrationBuilder.AlterColumn<string>(
                name: "CollaborateById",
                table: "CollaborateUser",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_CollaborateUser",
                table: "CollaborateUser",
                column: "CollaborateById");
        }
    }
}
