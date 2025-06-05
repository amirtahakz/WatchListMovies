using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WatchListMovies.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddCountryAndLanguage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ContentImage",
                table: "ContentImage");

            migrationBuilder.RenameTable(
                name: "ContentImage",
                newName: "ContentImages");

            migrationBuilder.RenameIndex(
                name: "IX_ContentImage_ContentImageType",
                table: "ContentImages",
                newName: "IX_ContentImages_ContentImageType");

            migrationBuilder.RenameIndex(
                name: "IX_ContentImage_ContentApiModelId",
                table: "ContentImages",
                newName: "IX_ContentImages_ContentApiModelId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ContentImages",
                table: "ContentImages",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Iso31661 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EnglishName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NativeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Languages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Iso6391 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EnglishName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Languages", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropTable(
                name: "Languages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ContentImages",
                table: "ContentImages");

            migrationBuilder.RenameTable(
                name: "ContentImages",
                newName: "ContentImage");

            migrationBuilder.RenameIndex(
                name: "IX_ContentImages_ContentImageType",
                table: "ContentImage",
                newName: "IX_ContentImage_ContentImageType");

            migrationBuilder.RenameIndex(
                name: "IX_ContentImages_ContentApiModelId",
                table: "ContentImage",
                newName: "IX_ContentImage_ContentApiModelId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ContentImage",
                table: "ContentImage",
                column: "Id");
        }
    }
}
