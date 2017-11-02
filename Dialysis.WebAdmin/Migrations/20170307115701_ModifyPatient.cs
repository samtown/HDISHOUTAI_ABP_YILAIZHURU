using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Dialysis.WebAdmin.Migrations
{
    public partial class ModifyPatient : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "BatchNumber",
                table: "C_PatientEdu",
                maxLength: 60,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 50);

            migrationBuilder.AddColumn<int>(
                name: "DialysisPatientId",
                table: "P_Patient",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DialysisPatientId",
                table: "P_Patient");

            migrationBuilder.AlterColumn<string>(
                name: "BatchNumber",
                table: "C_PatientEdu",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 60);
        }
    }
}
