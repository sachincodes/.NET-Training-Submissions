using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EntityTaskDB.Migrations
{
    public partial class Third : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Age",
                table: "students");

            migrationBuilder.DropColumn(
                name: "City",
                table: "students");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "students",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "students",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
