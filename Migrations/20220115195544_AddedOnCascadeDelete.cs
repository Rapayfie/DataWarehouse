using Microsoft.EntityFrameworkCore.Migrations;

namespace DataWarehouse.Migrations
{
    public partial class AddedOnCascadeDelete : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DiseaseHospitalHistories_Diseases_DiseaseId",
                table: "DiseaseHospitalHistories");

            migrationBuilder.DropForeignKey(
                name: "FK_Diseases_Patients_PatientId",
                table: "Diseases");

            migrationBuilder.AddForeignKey(
                name: "FK_DiseaseHospitalHistories_Diseases_DiseaseId",
                table: "DiseaseHospitalHistories",
                column: "DiseaseId",
                principalTable: "Diseases",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Diseases_Patients_PatientId",
                table: "Diseases",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DiseaseHospitalHistories_Diseases_DiseaseId",
                table: "DiseaseHospitalHistories");

            migrationBuilder.DropForeignKey(
                name: "FK_Diseases_Patients_PatientId",
                table: "Diseases");

            migrationBuilder.AddForeignKey(
                name: "FK_DiseaseHospitalHistories_Diseases_DiseaseId",
                table: "DiseaseHospitalHistories",
                column: "DiseaseId",
                principalTable: "Diseases",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Diseases_Patients_PatientId",
                table: "Diseases",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
