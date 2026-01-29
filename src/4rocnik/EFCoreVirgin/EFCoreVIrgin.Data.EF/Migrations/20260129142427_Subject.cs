using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCoreVIrgin.Data.EF.Migrations
{
    /// <inheritdoc />
    public partial class Subject : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StudentEntityId",
                table: "Student",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SubjectEntityId",
                table: "Student",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Subject",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subject", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Student_StudentEntityId",
                table: "Student",
                column: "StudentEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Student_SubjectEntityId",
                table: "Student",
                column: "SubjectEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Student_Student_StudentEntityId",
                table: "Student",
                column: "StudentEntityId",
                principalTable: "Student",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Student_Subject_SubjectEntityId",
                table: "Student",
                column: "SubjectEntityId",
                principalTable: "Subject",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Student_Student_StudentEntityId",
                table: "Student");

            migrationBuilder.DropForeignKey(
                name: "FK_Student_Subject_SubjectEntityId",
                table: "Student");

            migrationBuilder.DropTable(
                name: "Subject");

            migrationBuilder.DropIndex(
                name: "IX_Student_StudentEntityId",
                table: "Student");

            migrationBuilder.DropIndex(
                name: "IX_Student_SubjectEntityId",
                table: "Student");

            migrationBuilder.DropColumn(
                name: "StudentEntityId",
                table: "Student");

            migrationBuilder.DropColumn(
                name: "SubjectEntityId",
                table: "Student");
        }
    }
}
