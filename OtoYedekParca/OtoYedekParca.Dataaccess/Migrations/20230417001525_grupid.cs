using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OtoYedekParca.Dataaccess.Migrations
{
    public partial class grupid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GrupId",
                table: "Urunler",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GrupId",
                table: "Urunler");
        }
    }
}
