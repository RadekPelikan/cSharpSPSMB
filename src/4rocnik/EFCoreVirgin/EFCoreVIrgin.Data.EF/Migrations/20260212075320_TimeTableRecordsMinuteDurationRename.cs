using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCoreVIrgin.Data.EF.Migrations
{
    /// <inheritdoc />
    public partial class TimeTableRecordsMinuteDurationRename : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MInuteDuration",
                table: "TimeTableRecord",
                newName: "MinuteDuration");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MinuteDuration",
                table: "TimeTableRecord",
                newName: "MInuteDuration");
        }
    }
}
