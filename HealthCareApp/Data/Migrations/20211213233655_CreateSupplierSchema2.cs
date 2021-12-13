using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HealthCareApp.Data.Migrations
{
    public partial class CreateSupplierSchema2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "SupplierId",
                table: "Location",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "SupplierId",
                table: "ContactDetails",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Suppliers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    SupplierName = table.Column<string>(type: "TEXT", nullable: true),
                    SupplierABN = table.Column<string>(type: "TEXT", nullable: true),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false),
                    InsertedBy = table.Column<Guid>(type: "TEXT", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suppliers", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Location_SupplierId",
                table: "Location",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_ContactDetails_SupplierId",
                table: "ContactDetails",
                column: "SupplierId");

            migrationBuilder.AddForeignKey(
                name: "FK_ContactDetails_Suppliers_SupplierId",
                table: "ContactDetails",
                column: "SupplierId",
                principalTable: "Suppliers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Location_Suppliers_SupplierId",
                table: "Location",
                column: "SupplierId",
                principalTable: "Suppliers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContactDetails_Suppliers_SupplierId",
                table: "ContactDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_Location_Suppliers_SupplierId",
                table: "Location");

            migrationBuilder.DropTable(
                name: "Suppliers");

            migrationBuilder.DropIndex(
                name: "IX_Location_SupplierId",
                table: "Location");

            migrationBuilder.DropIndex(
                name: "IX_ContactDetails_SupplierId",
                table: "ContactDetails");

            migrationBuilder.DropColumn(
                name: "SupplierId",
                table: "Location");

            migrationBuilder.DropColumn(
                name: "SupplierId",
                table: "ContactDetails");
        }
    }
}
