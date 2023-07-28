using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VireshSirTask.Migrations
{
    /// <inheritdoc />
    public partial class shivamkhantwal1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Course",
                table: "Students",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Course",
                table: "Students");
        }
    }
}
