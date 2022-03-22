using Microsoft.EntityFrameworkCore.Migrations;

namespace Zave.Torbat.Siman.Model.Migrations
{
    public partial class AddTruckFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "PhoneNumberConfirmed",
                table: "T_Truck",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhoneNumberConfirmed",
                table: "T_Truck");
        }
    }
}
