using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OtoYedekParca.Dataaccess.Migrations
{
    public partial class csupdates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ModelId",
                table: "Tipler");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ModelId",
                table: "Tipler",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
