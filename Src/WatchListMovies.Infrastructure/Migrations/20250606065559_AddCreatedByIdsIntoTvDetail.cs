using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WatchListMovies.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddCreatedByIdsIntoTvDetail : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CreatedBys",
                schema: "tv");

            migrationBuilder.AddColumn<string>(
                name: "CreatedByIds",
                schema: "tv",
                table: "TvDetails",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedByIds",
                schema: "tv",
                table: "TvDetails");

            migrationBuilder.CreateTable(
                name: "CreatedBys",
                schema: "tv",
                columns: table => new
                {
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ParrentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ApiModelId = table.Column<long>(type: "bigint", nullable: true),
                    Gender = table.Column<int>(type: "int", nullable: true),
                    OriginalName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProfilePath = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreatedBys", x => new { x.CreationDate, x.ParrentId, x.Name });
                    table.ForeignKey(
                        name: "FK_CreatedBys_TvDetails_ParrentId",
                        column: x => x.ParrentId,
                        principalSchema: "tv",
                        principalTable: "TvDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CreatedBys_ParrentId",
                schema: "tv",
                table: "CreatedBys",
                column: "ParrentId");
        }
    }
}
