using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Zave.Torbat.Siman.Model.Migrations
{
    public partial class addCustomIdentity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AccessFailedCount",
                table: "T_Truck");

            migrationBuilder.DropColumn(
                name: "ConcurrencyStamp",
                table: "T_Truck");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "T_Truck");

            migrationBuilder.DropColumn(
                name: "EmailConfirmed",
                table: "T_Truck");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "T_Truck");

            migrationBuilder.DropColumn(
                name: "LockoutEnabled",
                table: "T_Truck");

            migrationBuilder.DropColumn(
                name: "LockoutEnd",
                table: "T_Truck");

            migrationBuilder.DropColumn(
                name: "NormalizedEmail",
                table: "T_Truck");

            migrationBuilder.DropColumn(
                name: "NormalizedUserName",
                table: "T_Truck");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "T_Truck");

            migrationBuilder.DropColumn(
                name: "PhoneNumberConfirmed",
                table: "T_Truck");

            migrationBuilder.DropColumn(
                name: "SecurityStamp",
                table: "T_Truck");

            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "T_Truck",
                newName: "Token");

            migrationBuilder.RenameColumn(
                name: "TwoFactorEnabled",
                table: "T_Truck",
                newName: "IsLoggedIn");

            //migrationBuilder.CreateTable(
            //    name: "IdentityUserLogin<string>",
            //    columns: table => new
            //    {
            //        UserId = table.Column<string>(nullable: false),
            //        LoginProvider = table.Column<string>(nullable: true),
            //        ProviderKey = table.Column<string>(nullable: true),
            //        ProviderDisplayName = table.Column<string>(nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_IdentityUserLogin<string>", x => x.UserId);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "IdentityUserRole<string>",
            //    columns: table => new
            //    {
            //        UserId = table.Column<string>(nullable: false),
            //        RoleId = table.Column<string>(nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_IdentityUserRole<string>", x => x.UserId);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "IdentityUserToken<string>",
            //    columns: table => new
            //    {
            //        UserId = table.Column<string>(nullable: false),
            //        LoginProvider = table.Column<string>(nullable: true),
            //        Name = table.Column<string>(nullable: true),
            //        Value = table.Column<string>(nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_IdentityUserToken<string>", x => x.UserId);
            //    });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropTable(
            //    name: "IdentityUserLogin<string>");

            //migrationBuilder.DropTable(
            //    name: "IdentityUserRole<string>");

            //migrationBuilder.DropTable(
            //    name: "IdentityUserToken<string>");

            migrationBuilder.RenameColumn(
                name: "Token",
                table: "T_Truck",
                newName: "UserName");

            migrationBuilder.RenameColumn(
                name: "IsLoggedIn",
                table: "T_Truck",
                newName: "TwoFactorEnabled");

            migrationBuilder.AddColumn<int>(
                name: "AccessFailedCount",
                table: "T_Truck",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ConcurrencyStamp",
                table: "T_Truck",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "T_Truck",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "EmailConfirmed",
                table: "T_Truck",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Id",
                table: "T_Truck",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "LockoutEnabled",
                table: "T_Truck",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "LockoutEnd",
                table: "T_Truck",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NormalizedEmail",
                table: "T_Truck",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NormalizedUserName",
                table: "T_Truck",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "T_Truck",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "PhoneNumberConfirmed",
                table: "T_Truck",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "SecurityStamp",
                table: "T_Truck",
                nullable: true);
        }
    }
}
