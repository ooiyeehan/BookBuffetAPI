using Microsoft.EntityFrameworkCore.Migrations;

namespace BookBuffetWeb2.Migrations
{
    public partial class mydbfilecloudv4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "users",
                newName: "userid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "userid",
                table: "users",
                newName: "UserId");
        }
    }
}
