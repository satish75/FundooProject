using Microsoft.EntityFrameworkCore.Migrations;

namespace RepositoryLayer.Migrations
{
    public partial class collaborate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CollaborateUser",
                columns: table => new
                {
                    CollaborateById = table.Column<string>(nullable: false),
                    UserID = table.Column<string>(nullable: true),
                    NotesID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CollaborateUser", x => x.CollaborateById);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CollaborateUser");
        }
    }
}
