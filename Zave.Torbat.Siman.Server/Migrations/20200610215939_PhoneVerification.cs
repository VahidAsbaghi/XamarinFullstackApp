using Microsoft.EntityFrameworkCore.Migrations;

namespace Zave.Torbat.Siman.Server.Migrations
{
    public partial class PhoneVerification : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MobileImei",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhoneVerificationToken",
                table: "AspNetUsers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MobileImei",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "PhoneVerificationToken",
                table: "AspNetUsers");
        }
    }
}
