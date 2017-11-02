using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Dialysis.WebAdmin.Migrations
{
    public partial class ModifyPatientAndContact : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Password",
                table: "P_Patient");

            migrationBuilder.DropColumn(
                name: "PatientPhone",
                table: "P_Patient");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "P_Contact",
                maxLength: 32,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Password",
                table: "P_Contact");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "P_Patient",
                maxLength: 32,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PatientPhone",
                table: "P_Patient",
                maxLength: 11,
                nullable: false,
                defaultValue: "");
        }
    }
}
