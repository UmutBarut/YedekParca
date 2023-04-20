using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OtoYedekParca.Dataaccess.Migrations
{
    public partial class deletelongtipid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Siralama",
                table: "Tipler",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<int>(
                name: "TipId",
                table: "Tipler",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
                .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "Siralama",
                table: "Tipler",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<long>(
                name: "TipId",
                table: "Tipler",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
                .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);
        }
    }
}
