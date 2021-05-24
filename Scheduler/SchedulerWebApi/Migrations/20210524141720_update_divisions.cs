using Microsoft.EntityFrameworkCore.Migrations;

namespace SchedulerWebApi.Migrations
{
    public partial class update_divisions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "HealthFacilityId",
                table: "Division",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HealthFacilityId",
                table: "Division");
        }
    }
}
