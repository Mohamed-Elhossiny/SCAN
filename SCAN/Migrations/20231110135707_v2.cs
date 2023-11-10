using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SCAN.Migrations
{
    /// <inheritdoc />
    public partial class v2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Reference",
                table: "Patients",
                newName: "ReferenceName");

            migrationBuilder.AddColumn<int>(
                name: "ReferenceID",
                table: "Patients",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReferenceID",
                table: "Patients");

            migrationBuilder.RenameColumn(
                name: "ReferenceName",
                table: "Patients",
                newName: "Reference");
        }
    }
}
