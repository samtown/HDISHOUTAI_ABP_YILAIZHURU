using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Dialysis.WebAdmin.Migrations
{
    public partial class PatientContact : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "P_Contact",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false),
                    AddTime = table.Column<DateTime>(nullable: false),
                    Address1 = table.Column<string>(maxLength: 64, nullable: true),
                    Address2 = table.Column<string>(maxLength: 64, nullable: true),
                    Area = table.Column<string>(maxLength: 8, nullable: true),
                    City = table.Column<string>(maxLength: 8, nullable: true),
                    ContatctName = table.Column<string>(maxLength: 50, nullable: true),
                    Country = table.Column<string>(maxLength: 8, nullable: true),
                    CreatedBy = table.Column<string>(maxLength: 32, nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: true),
                    CreatedUserId = table.Column<string>(maxLength: 32, nullable: true),
                    DialysisContactId = table.Column<int>(nullable: false),
                    Email = table.Column<string>(maxLength: 64, nullable: true),
                    HospitalId = table.Column<long>(nullable: false),
                    MobilePhone = table.Column<string>(maxLength: 16, nullable: true),
                    ModifiedBy = table.Column<string>(maxLength: 32, nullable: true),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    ModifiedUserId = table.Column<string>(maxLength: 32, nullable: true),
                    PatientId = table.Column<long>(nullable: false),
                    PostCode = table.Column<string>(maxLength: 8, nullable: true),
                    Province = table.Column<string>(maxLength: 8, nullable: true),
                    Relationship = table.Column<string>(maxLength: 20, nullable: true),
                    Telephone = table.Column<string>(maxLength: 16, nullable: true),
                    UpdateTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_P_Contact", x => x.Id);
                    table.ForeignKey(
                        name: "FK_P_Contact_P_Patient_PatientId",
                        column: x => x.PatientId,
                        principalTable: "P_Patient",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_P_Contact_PatientId",
                table: "P_Contact",
                column: "PatientId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "P_Contact");
        }
    }
}
