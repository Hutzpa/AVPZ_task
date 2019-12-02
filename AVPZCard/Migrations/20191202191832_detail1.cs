using Microsoft.EntityFrameworkCore.Migrations;

namespace AVPZCard.Migrations
{
    public partial class detail1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DetailNumber",
                table: "Posts",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Manufacturer",
                table: "Posts",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DetailNumber",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "Manufacturer",
                table: "Posts");
        }
    }
}
