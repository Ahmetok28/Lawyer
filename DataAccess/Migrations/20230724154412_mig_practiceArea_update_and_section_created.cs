using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class mig_practiceArea_update_and_section_created : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Paragraph1",
                table: "Practices");

            migrationBuilder.DropColumn(
                name: "Paragraph2",
                table: "Practices");

            migrationBuilder.DropColumn(
                name: "Title1",
                table: "Practices");

            migrationBuilder.DropColumn(
                name: "Title2",
                table: "Practices");

            migrationBuilder.CreateTable(
                name: "Section",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Paragraphs = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PracticeAreaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Section", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Section_Practices_PracticeAreaId",
                        column: x => x.PracticeAreaId,
                        principalTable: "Practices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Section_PracticeAreaId",
                table: "Section",
                column: "PracticeAreaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Section");

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

            migrationBuilder.AddColumn<string>(
                name: "Title2",
                table: "Practices",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
