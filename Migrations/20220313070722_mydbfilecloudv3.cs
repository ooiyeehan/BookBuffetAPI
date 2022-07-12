using Microsoft.EntityFrameworkCore.Migrations;

namespace BookBuffetWeb2.Migrations
{
    public partial class mydbfilecloudv3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "users",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "users");
        }
    }
}
