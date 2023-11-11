using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SCAN.Migrations
{
    /// <inheritdoc />
    public partial class v3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CheckTpye",
                table: "Patients",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CheckTpyeID",
                table: "Patients",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CheckTpye",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "CheckTpyeID",
                table: "Patients");
        }
    }
}
