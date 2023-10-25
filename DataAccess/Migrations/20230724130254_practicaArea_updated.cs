using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class practicaArea_updated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Practices",
                newName: "Title2");

            migrationBuilder.AddColumn<string>(
                name: "BackgroundImage",
                table: "Practices",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LogoImage",
                table: "Practices",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Practices",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Paragraph1",
                table: "Practices",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Paragraph2",
                table: "Practices",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Title1",
                table: "Practices",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BackgroundImage",
                table: "Practices");

            migrationBuilder.DropColumn(
                name: "LogoImage",
                table: "Practices");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Practices");

            migrationBuilder.DropColumn(
                name: "Paragraph1",
                table: "Practices");

            migrationBuilder.DropColumn(
                name: "Paragraph2",
                table: "Practices");

            migrationBuilder.DropColumn(
                name: "Title1",
                table: "Practices");

            migrationBuilder.RenameColumn(
                name: "Title2",
                table: "Practices",
                newName: "Title");
        }
    }
}
