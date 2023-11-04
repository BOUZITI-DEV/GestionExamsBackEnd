using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PFA.Library.Migrations
{
    /// <inheritdoc />
    public partial class isPresentAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsPresent",
                table: "ExamEtudiants",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsPresent",
                table: "ExamEtudiants");
        }
    }
}
