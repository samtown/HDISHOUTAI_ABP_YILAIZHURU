using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Dialysis.WebAdmin.Migrations
{
    public partial class ModifyDialysis : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "OuterId",
                table: "C_Message",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 60,
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DialysisRecordId",
                table: "P_Dialysis",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<long>(
                name: "HospitalId",
                table: "P_Dialysis",
                nullable: false,
                defaultValue: 0L);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DialysisRecordId",
                table: "P_Dialysis");

            migrationBuilder.DropColumn(
                name: "HospitalId",
                table: "P_Dialysis");

            migrationBuilder.AlterColumn<string>(
                name: "OuterId",
                table: "C_Message",
                maxLength: 60,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50,
                oldNullable: true);
        }
    }
}
