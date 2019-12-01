using Microsoft.EntityFrameworkCore.Migrations;

namespace AVPZCard.Migrations
{
    public partial class Update1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Categories_CategoryId_Category",
                table: "Posts");

            migrationBuilder.DropIndex(
                name: "IX_Posts_CategoryId_Category",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "CategoryId_Category",
                table: "Posts");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Posts",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Posts_CategoryId",
                table: "Posts",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Categories_CategoryId",
                table: "Posts",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id_Category",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Categories_CategoryId",
                table: "Posts");

            migrationBuilder.DropIndex(
                name: "IX_Posts_CategoryId",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Posts");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId_Category",
                table: "Posts",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Posts_CategoryId_Category",
                table: "Posts",
                column: "CategoryId_Category");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Categories_CategoryId_Category",
                table: "Posts",
                column: "CategoryId_Category",
                principalTable: "Categories",
                principalColumn: "Id_Category",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
