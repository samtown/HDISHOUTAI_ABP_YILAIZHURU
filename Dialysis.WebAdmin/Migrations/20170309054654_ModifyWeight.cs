using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Dialysis.WebAdmin.Migrations
{
    public partial class ModifyWeight : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DialysisWeightId",
                table: "P_Weight",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "HospitalId",
                table: "P_Weight",
                nullable: false,
                defaultValue: 0L);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DialysisWeightId",
                table: "P_Weight");

            migrationBuilder.DropColumn(
                name: "HospitalId",
                table: "P_Weight");
        }
    }
}
