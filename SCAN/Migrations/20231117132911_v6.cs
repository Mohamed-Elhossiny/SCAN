using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SCAN.Migrations
{
    /// <inheritdoc />
    public partial class v6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Scan_ID",
                table: "Patients",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Patients_Scan_ID",
                table: "Patients",
                column: "Scan_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_Scans_Scan_ID",
                table: "Patients",
                column: "Scan_ID",
                principalTable: "Scans",
                principalColumn: "ScanID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Patients_Scans_Scan_ID",
                table: "Patients");

            migrationBuilder.DropIndex(
                name: "IX_Patients_Scan_ID",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "Scan_ID",
                table: "Patients");
        }
    }
}
