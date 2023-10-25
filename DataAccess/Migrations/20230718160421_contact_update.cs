using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class contact_update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Contacts");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Contacts",
                newName: "Title2");

            migrationBuilder.RenameColumn(
                name: "Message",
                table: "Contacts",
                newName: "Title");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Title2",
                table: "Contacts",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Contacts",
                newName: "Message");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Contacts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
