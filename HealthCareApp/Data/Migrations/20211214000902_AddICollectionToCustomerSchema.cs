using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HealthCareApp.Data.Migrations
{
    public partial class AddICollectionToCustomerSchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_ContactDetails_ContactDetailsId",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Location_LocationId",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Customers_ContactDetailsId",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Customers_LocationId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "ContactDetailsId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "LocationId",
                table: "Customers");

            migrationBuilder.AddColumn<Guid>(
                name: "CustomerId",
                table: "Location",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CustomerId",
                table: "ContactDetails",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Location_CustomerId",
                table: "Location",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_ContactDetails_CustomerId",
                table: "ContactDetails",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_ContactDetails_Customers_CustomerId",
                table: "ContactDetails",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Location_Customers_CustomerId",
                table: "Location",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContactDetails_Customers_CustomerId",
                table: "ContactDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_Location_Customers_CustomerId",
                table: "Location");

            migrationBuilder.DropIndex(
                name: "IX_Location_CustomerId",
                table: "Location");

            migrationBuilder.DropIndex(
                name: "IX_ContactDetails_CustomerId",
                table: "ContactDetails");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "Location");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "ContactDetails");

            migrationBuilder.AddColumn<Guid>(
                name: "ContactDetailsId",
                table: "Customers",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "LocationId",
                table: "Customers",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Customers_ContactDetailsId",
                table: "Customers",
                column: "ContactDetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_LocationId",
                table: "Customers",
                column: "LocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_ContactDetails_ContactDetailsId",
                table: "Customers",
                column: "ContactDetailsId",
                principalTable: "ContactDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Location_LocationId",
                table: "Customers",
                column: "LocationId",
                principalTable: "Location",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
