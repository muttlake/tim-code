using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace WeatherApp.DB.Migrations
{
    public partial class WeatherAppMig7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TempFahr",
                table: "Posts",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "WeatherJson",
                table: "Posts",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WeatherType",
                table: "Posts",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ZipCode",
                table: "Posts",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TempFahr",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "WeatherJson",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "WeatherType",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "ZipCode",
                table: "Posts");
        }
    }
}
