using Microsoft.EntityFrameworkCore.Migrations;

namespace HealthCareApp.Data.Migrations
{
    public partial class CreateSupplierSchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_ContactDetails_CustomerContactDetailsId",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Location_CustomerLocationId",
                table: "Customers");

            migrationBuilder.RenameColumn(
                name: "CustomerLocationId",
                table: "Customers",
                newName: "LocationId");

            migrationBuilder.RenameColumn(
                name: "CustomerContactDetailsId",
                table: "Customers",
                newName: "ContactDetailsId");

            migrationBuilder.RenameIndex(
                name: "IX_Customers_CustomerLocationId",
                table: "Customers",
                newName: "IX_Customers_LocationId");

            migrationBuilder.RenameIndex(
                name: "IX_Customers_CustomerContactDetailsId",
                table: "Customers",
                newName: "IX_Customers_ContactDetailsId");

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "Customers",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "BOOLEAN");

            migrationBuilder.AlterColumn<bool>(
                name: "TwoFactorEnabled",
                table: "AspNetUsers",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "BOOLEAN");

            migrationBuilder.AlterColumn<bool>(
                name: "LockoutEnabled",
                table: "AspNetUsers",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "BOOLEAN");

            migrationBuilder.AlterColumn<bool>(
                name: "EmailConfirmed",
                table: "AspNetUsers",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "BOOLEAN");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_ContactDetails_ContactDetailsId",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Location_LocationId",
                table: "Customers");

            migrationBuilder.RenameColumn(
                name: "LocationId",
                table: "Customers",
                newName: "CustomerLocationId");

            migrationBuilder.RenameColumn(
                name: "ContactDetailsId",
                table: "Customers",
                newName: "CustomerContactDetailsId");

            migrationBuilder.RenameIndex(
                name: "IX_Customers_LocationId",
                table: "Customers",
                newName: "IX_Customers_CustomerLocationId");

            migrationBuilder.RenameIndex(
                name: "IX_Customers_ContactDetailsId",
                table: "Customers",
                newName: "IX_Customers_CustomerContactDetailsId");

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "Customers",
                type: "BOOLEAN",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<bool>(
                name: "TwoFactorEnabled",
                table: "AspNetUsers",
                type: "BOOLEAN",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<bool>(
                name: "LockoutEnabled",
                table: "AspNetUsers",
                type: "BOOLEAN",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<bool>(
                name: "EmailConfirmed",
                table: "AspNetUsers",
                type: "BOOLEAN",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "INTEGER");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_ContactDetails_CustomerContactDetailsId",
                table: "Customers",
                column: "CustomerContactDetailsId",
                principalTable: "ContactDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Location_CustomerLocationId",
                table: "Customers",
                column: "CustomerLocationId",
                principalTable: "Location",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
