using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MediLabo.Patients.Migrations
{
    /// <inheritdoc />
    public partial class AjouteContraintesAdresseTelephone : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddCheckConstraint(
                name: "CK_Patients_Adresse",
                table: "Patients",
                sql: "[Adresse] IS NULL OR LEN([Adresse]) > 0");

            migrationBuilder.AddCheckConstraint(
                name: "CK_Patients_Telephone",
                table: "Patients",
                sql: "[Telephone] IS NULL OR LEN([Telephone]) > 0");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "CK_Patients_Adresse",
                table: "Patients");

            migrationBuilder.DropCheckConstraint(
                name: "CK_Patients_Telephone",
                table: "Patients");
        }
    }
}
