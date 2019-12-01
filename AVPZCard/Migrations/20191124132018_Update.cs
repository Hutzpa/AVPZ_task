using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AVPZCard.Migrations
{
    public partial class Update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Category",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "Created",
                table: "Posts");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId_Category",
                table: "Posts",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsAble",
                table: "Posts",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Posts",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id_Category = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(nullable: true),
                    CategoryDescription = table.Column<string>(nullable: true),
                    Photo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id_Category);
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Categories_CategoryId_Category",
                table: "Posts");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Posts_CategoryId_Category",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "CategoryId_Category",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "IsAble",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Posts");

            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "Posts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "Posts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
