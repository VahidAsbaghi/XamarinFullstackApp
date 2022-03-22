using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Zave.Torbat.Siman.Model.Migrations
{
    public partial class addIndentityUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "PasswordHash",
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
                name: "PhoneVerificationToken",
                table: "T_Truck",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SecurityStamp",
                table: "T_Truck",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "TwoFactorEnabled",
                table: "T_Truck",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "T_Truck",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
                name: "PasswordHash",
                table: "T_Truck");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "T_Truck");

            migrationBuilder.DropColumn(
                name: "PhoneNumberConfirmed",
                table: "T_Truck");

            migrationBuilder.DropColumn(
                name: "PhoneVerificationToken",
                table: "T_Truck");

            migrationBuilder.DropColumn(
                name: "SecurityStamp",
                table: "T_Truck");

            migrationBuilder.DropColumn(
                name: "TwoFactorEnabled",
                table: "T_Truck");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "T_Truck");
        }
    }
}
