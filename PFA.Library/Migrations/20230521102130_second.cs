using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PFA.Library.Migrations
{
    /// <inheritdoc />
    public partial class second : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExamEtudiant_Exams_ExamId",
                table: "ExamEtudiant");

            migrationBuilder.DropForeignKey(
                name: "FK_ExamEtudiant_Salles_SalleId",
                table: "ExamEtudiant");

            migrationBuilder.DropForeignKey(
                name: "FK_ExamEtudiant_Utilisateurs_EtudiantId",
                table: "ExamEtudiant");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ExamEtudiant",
                table: "ExamEtudiant");

            migrationBuilder.DropColumn(
                name: "MyProperty",
                table: "Matieres");

            migrationBuilder.RenameTable(
                name: "ExamEtudiant",
                newName: "ExamEtudiants");

            migrationBuilder.RenameIndex(
                name: "IX_ExamEtudiant_SalleId",
                table: "ExamEtudiants",
                newName: "IX_ExamEtudiants_SalleId");

            migrationBuilder.RenameIndex(
                name: "IX_ExamEtudiant_ExamId",
                table: "ExamEtudiants",
                newName: "IX_ExamEtudiants_ExamId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ExamEtudiants",
                table: "ExamEtudiants",
                columns: new[] { "EtudiantId", "ExamId" });

            migrationBuilder.CreateTable(
                name: "ExamSurveillants",
                columns: table => new
                {
                    SurveillantId = table.Column<int>(type: "int", nullable: false),
                    ExamId = table.Column<int>(type: "int", nullable: false),
                    SalleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExamSurveillants", x => new { x.SurveillantId, x.ExamId });
                    table.ForeignKey(
                        name: "FK_ExamSurveillants_Exams_ExamId",
                        column: x => x.ExamId,
                        principalTable: "Exams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExamSurveillants_Salles_SalleId",
                        column: x => x.SalleId,
                        principalTable: "Salles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExamSurveillants_Utilisateurs_SurveillantId",
                        column: x => x.SurveillantId,
                        principalTable: "Utilisateurs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExamSurveillants_ExamId",
                table: "ExamSurveillants",
                column: "ExamId");

            migrationBuilder.CreateIndex(
                name: "IX_ExamSurveillants_SalleId",
                table: "ExamSurveillants",
                column: "SalleId");

            migrationBuilder.AddForeignKey(
                name: "FK_ExamEtudiants_Exams_ExamId",
                table: "ExamEtudiants",
                column: "ExamId",
                principalTable: "Exams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ExamEtudiants_Salles_SalleId",
                table: "ExamEtudiants",
                column: "SalleId",
                principalTable: "Salles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ExamEtudiants_Utilisateurs_EtudiantId",
                table: "ExamEtudiants",
                column: "EtudiantId",
                principalTable: "Utilisateurs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExamEtudiants_Exams_ExamId",
                table: "ExamEtudiants");

            migrationBuilder.DropForeignKey(
                name: "FK_ExamEtudiants_Salles_SalleId",
                table: "ExamEtudiants");

            migrationBuilder.DropForeignKey(
                name: "FK_ExamEtudiants_Utilisateurs_EtudiantId",
                table: "ExamEtudiants");

            migrationBuilder.DropTable(
                name: "ExamSurveillants");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ExamEtudiants",
                table: "ExamEtudiants");

            migrationBuilder.RenameTable(
                name: "ExamEtudiants",
                newName: "ExamEtudiant");

            migrationBuilder.RenameIndex(
                name: "IX_ExamEtudiants_SalleId",
                table: "ExamEtudiant",
                newName: "IX_ExamEtudiant_SalleId");

            migrationBuilder.RenameIndex(
                name: "IX_ExamEtudiants_ExamId",
                table: "ExamEtudiant",
                newName: "IX_ExamEtudiant_ExamId");

            migrationBuilder.AddColumn<int>(
                name: "MyProperty",
                table: "Matieres",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ExamEtudiant",
                table: "ExamEtudiant",
                columns: new[] { "EtudiantId", "ExamId" });

            migrationBuilder.AddForeignKey(
                name: "FK_ExamEtudiant_Exams_ExamId",
                table: "ExamEtudiant",
                column: "ExamId",
                principalTable: "Exams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ExamEtudiant_Salles_SalleId",
                table: "ExamEtudiant",
                column: "SalleId",
                principalTable: "Salles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ExamEtudiant_Utilisateurs_EtudiantId",
                table: "ExamEtudiant",
                column: "EtudiantId",
                principalTable: "Utilisateurs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
