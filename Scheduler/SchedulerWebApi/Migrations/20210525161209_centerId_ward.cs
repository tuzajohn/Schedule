using Microsoft.EntityFrameworkCore.Migrations;

namespace SchedulerWebApi.Migrations
{
    public partial class centerId_ward : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CenterId",
                table: "Wards",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CenterId",
                table: "Wards");
        }
    }
}
