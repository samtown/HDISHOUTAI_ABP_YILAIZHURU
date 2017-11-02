using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Dialysis.WebAdmin.Migrations
{
    public partial class ModifyBloodPressure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DialysisBloodPressureId",
                table: "P_BloodPressure",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "HospitalId",
                table: "P_BloodPressure",
                nullable: false,
                defaultValue: 0L);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DialysisBloodPressureId",
                table: "P_BloodPressure");

            migrationBuilder.DropColumn(
                name: "HospitalId",
                table: "P_BloodPressure");
        }
    }
}
