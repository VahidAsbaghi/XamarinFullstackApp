using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Zave.Torbat.Siman.Server.Migrations
{
    public partial class addTrucktodb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DrivingLicenseDate",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HealthCardDate",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LoadingCardNumber",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NegativePoints",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "SmartCardDate",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Trucks",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    InsuranceDate = table.Column<string>(nullable: true),
                    TechnicalVisitDate = table.Column<string>(nullable: true),
                    NegativePoints = table.Column<int>(nullable: false),
                    PositionSetDate = table.Column<string>(nullable: true),
                    PositionNumber = table.Column<int>(nullable: false),
                    PermittedLoadCount = table.Column<int>(nullable: false),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trucks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Trucks_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Trucks_UserId",
                table: "Trucks",
                column: "UserId",
                unique: true,
                filter: "[UserId] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Trucks");

            migrationBuilder.DropColumn(
                name: "DrivingLicenseDate",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "HealthCardDate",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LoadingCardNumber",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "NegativePoints",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "SmartCardDate",
                table: "AspNetUsers");
        }
    }
}
