﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace SchedulerWebApi.Migrations
{
    public partial class centerId_user : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CenterId",
                table: "User",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CenterId",
                table: "User");
        }
    }
}