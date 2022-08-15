using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HealthCareApp.Migrations
{
    public partial class AddFieldShiftTypeOnModelLabelMop : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ShiftType",
                table: "HcaLabelMop",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ShiftType",
                table: "HcaLabelMop");
        }
    }
}
