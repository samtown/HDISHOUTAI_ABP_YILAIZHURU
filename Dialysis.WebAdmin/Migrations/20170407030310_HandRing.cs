using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Dialysis.WebAdmin.Migrations
{
    public partial class HandRing : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "P_HandRing",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    Distance = table.Column<int>(nullable: false),
                    Energy = table.Column<decimal>(nullable: false),
                    PatientId = table.Column<long>(nullable: false),
                    SleepTime = table.Column<int>(nullable: false),
                    Steps = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_P_HandRing", x => x.Id);
                    table.ForeignKey(
                        name: "FK_P_HandRing_P_Patient_PatientId",
                        column: x => x.PatientId,
                        principalTable: "P_Patient",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_P_HandRing_PatientId",
                table: "P_HandRing",
                column: "PatientId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "P_HandRing");
        }
    }
}
