using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Dialysis.WebAdmin.Migrations
{
    public partial class DeleteUnnecessaryFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "P_Contact");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "P_Contact");

            migrationBuilder.DropColumn(
                name: "CreatedUserId",
                table: "P_Contact");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "P_Contact");

            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                table: "P_Contact");

            migrationBuilder.DropColumn(
                name: "ModifiedUserId",
                table: "P_Contact");

            migrationBuilder.DropColumn(
                name: "ContactPerson",
                table: "P_Patient");

            migrationBuilder.DropColumn(
                name: "ContactPhone",
                table: "P_Patient");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "P_Contact",
                maxLength: 32,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "P_Contact",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedUserId",
                table: "P_Contact",
                maxLength: 32,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "P_Contact",
                maxLength: 32,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOn",
                table: "P_Contact",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedUserId",
                table: "P_Contact",
                maxLength: 32,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContactPerson",
                table: "P_Patient",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContactPhone",
                table: "P_Patient",
                maxLength: 16,
                nullable: false,
                defaultValue: "");
        }
    }
}
