using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WatchListMovies.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddSeasonAndEpisode : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Episodes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TvApiId = table.Column<long>(type: "bigint", nullable: true),
                    SeasonApiId = table.Column<long>(type: "bigint", nullable: true),
                    ApiModelId = table.Column<long>(type: "bigint", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Overview = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VoteAverage = table.Column<float>(type: "real", nullable: true),
                    VoteCount = table.Column<long>(type: "bigint", nullable: true),
                    AirDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EpisodeNumber = table.Column<long>(type: "bigint", nullable: true),
                    EpisodeType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SeasonNumber = table.Column<long>(type: "bigint", nullable: true),
                    StillPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Episodes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Seasons",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ApiModelId = table.Column<long>(type: "bigint", nullable: true),
                    TvApiId = table.Column<long>(type: "bigint", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Overview = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EpisodeCount = table.Column<long>(type: "bigint", nullable: true),
                    SeasonNumber = table.Column<long>(type: "bigint", nullable: true),
                    AirDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PosterPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VoteAverage = table.Column<float>(type: "real", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seasons", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Episodes_ApiModelId",
                table: "Episodes",
                column: "ApiModelId",
                unique: true,
                filter: "[ApiModelId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Episodes_Name",
                table: "Episodes",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_Seasons_ApiModelId",
                table: "Seasons",
                column: "ApiModelId",
                unique: true,
                filter: "[ApiModelId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Seasons_Name",
                table: "Seasons",
                column: "Name");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Episodes");

            migrationBuilder.DropTable(
                name: "Seasons");
        }
    }
}
