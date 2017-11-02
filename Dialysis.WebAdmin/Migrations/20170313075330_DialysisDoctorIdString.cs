using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Dialysis.WebAdmin.Migrations
{
    public partial class DialysisDoctorIdString : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "DialysisDoctorId",
                table: "D_Doctor",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "DialysisDoctorId",
                table: "D_Doctor",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 128);
        }
    }
}
