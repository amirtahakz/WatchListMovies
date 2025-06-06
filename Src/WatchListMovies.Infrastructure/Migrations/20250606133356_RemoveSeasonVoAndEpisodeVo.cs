using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WatchListMovies.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RemoveSeasonVoAndEpisodeVo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EpisodeToAirs",
                schema: "tv");

            migrationBuilder.DropTable(
                name: "Seasons",
                schema: "tv");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EpisodeToAirs",
                schema: "tv",
                columns: table => new
                {
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ParrentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AirDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ApiModelId = table.Column<long>(type: "bigint", nullable: true),
                    EpisodeAirType = table.Column<int>(type: "int", nullable: false),
                    EpisodeNumber = table.Column<long>(type: "bigint", nullable: true),
                    EpisodeType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Overview = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SeasonNumber = table.Column<long>(type: "bigint", nullable: true),
                    StillPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VoteAverage = table.Column<float>(type: "real", nullable: true),
                    VoteCount = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EpisodeToAirs", x => new { x.CreationDate, x.ParrentId, x.Name });
                    table.ForeignKey(
                        name: "FK_EpisodeToAirs_TvDetails_ParrentId",
                        column: x => x.ParrentId,
                        principalSchema: "tv",
                        principalTable: "TvDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Seasons",
                schema: "tv",
                columns: table => new
                {
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ParrentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AirDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ApiModelId = table.Column<long>(type: "bigint", nullable: true),
                    EpisodeCount = table.Column<long>(type: "bigint", nullable: true),
                    Overview = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PosterPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SeasonNumber = table.Column<long>(type: "bigint", nullable: true),
                    VoteAverage = table.Column<float>(type: "real", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seasons", x => new { x.CreationDate, x.ParrentId, x.Name });
                    table.ForeignKey(
                        name: "FK_Seasons_TvDetails_ParrentId",
                        column: x => x.ParrentId,
                        principalSchema: "tv",
                        principalTable: "TvDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EpisodeToAirs_ParrentId",
                schema: "tv",
                table: "EpisodeToAirs",
                column: "ParrentId");

            migrationBuilder.CreateIndex(
                name: "IX_Seasons_ParrentId",
                schema: "tv",
                table: "Seasons",
                column: "ParrentId");
        }
    }
}
