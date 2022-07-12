using Microsoft.EntityFrameworkCore.Migrations;

namespace BookBuffetWeb2.Migrations
{
    public partial class mydbfilecloudv5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_reservations",
                table: "reservations");

            migrationBuilder.RenameTable(
                name: "reservations",
                newName: "rentRequests");

            migrationBuilder.AlterColumn<string>(
                name: "requesterId",
                table: "rentRequests",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "receiverId",
                table: "rentRequests",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_rentRequests",
                table: "rentRequests",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_rentRequests",
                table: "rentRequests");

            migrationBuilder.RenameTable(
                name: "rentRequests",
                newName: "reservations");

            migrationBuilder.AlterColumn<int>(
                name: "requesterId",
                table: "reservations",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "receiverId",
                table: "reservations",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_reservations",
                table: "reservations",
                column: "Id");
        }
    }
}
