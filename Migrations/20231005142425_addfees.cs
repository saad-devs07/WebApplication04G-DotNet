using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication04G.Migrations
{
    /// <inheritdoc />
    public partial class addfees : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Feeses",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SMonth = table.Column<int>(type: "int", nullable: false),
                    FAmount = table.Column<int>(type: "int", nullable: false),
                    SDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StudentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feeses", x => x.id);
                    table.ForeignKey(
                        name: "FK_Feeses_Student_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Student",
                        principalColumn: "StudentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Feeses_StudentId",
                table: "Feeses",
                column: "StudentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Feeses");
        }
    }
}
