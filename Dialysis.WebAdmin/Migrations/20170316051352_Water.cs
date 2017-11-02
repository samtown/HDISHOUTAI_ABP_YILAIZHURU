using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Dialysis.WebAdmin.Migrations
{
    public partial class Water : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CupMAC",
                table: "P_Patient",
                maxLength: 64,
                nullable: true);

            migrationBuilder.CreateTable(
                name: "P_Water",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false),
                    AddTime = table.Column<DateTime>(nullable: false),
                    DrinkTime = table.Column<DateTime>(nullable: false),
                    DrinkVolume = table.Column<int>(nullable: false),
                    PatientId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_P_Water", x => x.Id);
                    table.ForeignKey(
                        name: "FK_P_Water_P_Patient_PatientId",
                        column: x => x.PatientId,
                        principalTable: "P_Patient",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_P_Water_PatientId",
                table: "P_Water",
                column: "PatientId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "P_Water");

            migrationBuilder.DropColumn(
                name: "CupMAC",
                table: "P_Patient");
        }
    }
}
