using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Dialysis.WebAdmin.Migrations
{
    public partial class BloodSugar : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "P_BloodSugar",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false),
                    AddTime = table.Column<DateTime>(nullable: false),
                    PatientId = table.Column<long>(nullable: false),
                    Value = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_P_BloodSugar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_P_BloodSugar_P_Patient_PatientId",
                        column: x => x.PatientId,
                        principalTable: "P_Patient",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_P_BloodSugar_PatientId",
                table: "P_BloodSugar",
                column: "PatientId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "P_BloodSugar");
        }
    }
}
