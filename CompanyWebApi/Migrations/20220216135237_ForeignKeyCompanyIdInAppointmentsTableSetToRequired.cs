﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CompanyWebApi.Migrations
{
    public partial class ForeignKeyCompanyIdInAppointmentsTableSetToRequired : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Companies_CompanyId",
                table: "Appointments");

            migrationBuilder.AlterColumn<int>(
                name: "CompanyId",
                table: "Appointments",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Companies_CompanyId",
                table: "Appointments",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Companies_CompanyId",
                table: "Appointments");

            migrationBuilder.AlterColumn<int>(
                name: "CompanyId",
                table: "Appointments",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Companies_CompanyId",
                table: "Appointments",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id");
        }
    }
}