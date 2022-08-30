using System.Data;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyApp.Migrations
{
    public partial class MakeFieldBarcodeUniqueForModelLabelMop : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddUniqueConstraint("Barcode", "HcaLabelMop", "Barcode");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
