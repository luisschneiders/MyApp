using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyApp.Migrations
{
    public partial class UpdateModelTrackingInventoryMop : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PickupTime",
                table: "HcaTrackingInvetoryMop");

            migrationBuilder.RenameColumn(
                name: "ReturnTime",
                table: "HcaTrackingInvetoryMop",
                newName: "ScanTime");

            migrationBuilder.AddColumn<int>(
                name: "EntryType",
                table: "HcaTrackingInvetoryMop",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EntryType",
                table: "HcaTrackingInvetoryMop");

            migrationBuilder.RenameColumn(
                name: "ScanTime",
                table: "HcaTrackingInvetoryMop",
                newName: "ReturnTime");

            migrationBuilder.AddColumn<DateTime>(
                name: "PickupTime",
                table: "HcaTrackingInvetoryMop",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
