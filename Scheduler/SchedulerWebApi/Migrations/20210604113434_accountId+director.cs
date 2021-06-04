using Microsoft.EntityFrameworkCore.Migrations;

namespace SchedulerWebApi.Migrations
{
    public partial class accountIddirector : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AccountId",
                table: "Director",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AccountId",
                table: "Director");
        }
    }
}
