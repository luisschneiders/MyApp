using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HealthCareApp.Data.Migrations
{
    public partial class AddCollectionEmployeeSchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_ContactDetails_ContactDetailsId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Location_LocationId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_ContactDetailsId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_LocationId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "ContactDetailsId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "LocationId",
                table: "Employees");

            migrationBuilder.AddColumn<Guid>(
                name: "EmployeeId",
                table: "Location",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "EmployeeId",
                table: "ContactDetails",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Location_EmployeeId",
                table: "Location",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_ContactDetails_EmployeeId",
                table: "ContactDetails",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_ContactDetails_Employees_EmployeeId",
                table: "ContactDetails",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Location_Employees_EmployeeId",
                table: "Location",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContactDetails_Employees_EmployeeId",
                table: "ContactDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_Location_Employees_EmployeeId",
                table: "Location");

            migrationBuilder.DropIndex(
                name: "IX_Location_EmployeeId",
                table: "Location");

            migrationBuilder.DropIndex(
                name: "IX_ContactDetails_EmployeeId",
                table: "ContactDetails");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "Location");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "ContactDetails");

            migrationBuilder.AddColumn<Guid>(
                name: "ContactDetailsId",
                table: "Employees",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "LocationId",
                table: "Employees",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_ContactDetailsId",
                table: "Employees",
                column: "ContactDetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_LocationId",
                table: "Employees",
                column: "LocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_ContactDetails_ContactDetailsId",
                table: "Employees",
                column: "ContactDetailsId",
                principalTable: "ContactDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Location_LocationId",
                table: "Employees",
                column: "LocationId",
                principalTable: "Location",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
