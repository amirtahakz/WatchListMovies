using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WatchListMovies.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RemoveCompanyAndLanguageAndCountruVoOfTvDetailsAndMovieDetails : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductionCompanies",
                schema: "movie");

            migrationBuilder.DropTable(
                name: "ProductionCompanies",
                schema: "tv");

            migrationBuilder.DropTable(
                name: "ProductionCountries",
                schema: "movie");

            migrationBuilder.DropTable(
                name: "ProductionCountries",
                schema: "tv");

            migrationBuilder.DropTable(
                name: "SpokenLanguages",
                schema: "movie");

            migrationBuilder.DropTable(
                name: "SpokenLanguages",
                schema: "tv");

            migrationBuilder.AddColumn<string>(
                name: "CompanyIds",
                schema: "tv",
                table: "TvDetails",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CountryIds",
                schema: "tv",
                table: "TvDetails",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LanguageIds",
                schema: "tv",
                table: "TvDetails",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CompanyIds",
                schema: "movie",
                table: "MovieDetails",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CountryIds",
                schema: "movie",
                table: "MovieDetails",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LanguageIds",
                schema: "movie",
                table: "MovieDetails",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CompanyIds",
                schema: "tv",
                table: "TvDetails");

            migrationBuilder.DropColumn(
                name: "CountryIds",
                schema: "tv",
                table: "TvDetails");

            migrationBuilder.DropColumn(
                name: "LanguageIds",
                schema: "tv",
                table: "TvDetails");

            migrationBuilder.DropColumn(
                name: "CompanyIds",
                schema: "movie",
                table: "MovieDetails");

            migrationBuilder.DropColumn(
                name: "CountryIds",
                schema: "movie",
                table: "MovieDetails");

            migrationBuilder.DropColumn(
                name: "LanguageIds",
                schema: "movie",
                table: "MovieDetails");

            migrationBuilder.CreateTable(
                name: "ProductionCompanies",
                schema: "movie",
                columns: table => new
                {
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ParrentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ApiModelId = table.Column<long>(type: "bigint", nullable: true),
                    LogoPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OriginCountry = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductionCompanies", x => new { x.CreationDate, x.ParrentId, x.Name });
                    table.ForeignKey(
                        name: "FK_ProductionCompanies_MovieDetails_ParrentId",
                        column: x => x.ParrentId,
                        principalSchema: "movie",
                        principalTable: "MovieDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductionCompanies",
                schema: "tv",
                columns: table => new
                {
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ParrentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ApiModelId = table.Column<long>(type: "bigint", nullable: true),
                    LogoPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OriginCountry = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductionCompanies", x => new { x.CreationDate, x.ParrentId, x.Name });
                    table.ForeignKey(
                        name: "FK_ProductionCompanies_TvDetails_ParrentId",
                        column: x => x.ParrentId,
                        principalSchema: "tv",
                        principalTable: "TvDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductionCountries",
                schema: "movie",
                columns: table => new
                {
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ParrentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Iso31661 = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductionCountries", x => new { x.CreationDate, x.ParrentId, x.Name });
                    table.ForeignKey(
                        name: "FK_ProductionCountries_MovieDetails_ParrentId",
                        column: x => x.ParrentId,
                        principalSchema: "movie",
                        principalTable: "MovieDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductionCountries",
                schema: "tv",
                columns: table => new
                {
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ParrentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Iso31661 = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductionCountries", x => new { x.CreationDate, x.ParrentId, x.Name });
                    table.ForeignKey(
                        name: "FK_ProductionCountries_TvDetails_ParrentId",
                        column: x => x.ParrentId,
                        principalSchema: "tv",
                        principalTable: "TvDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SpokenLanguages",
                schema: "movie",
                columns: table => new
                {
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ParrentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EnglishName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Iso6391 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpokenLanguages", x => new { x.CreationDate, x.ParrentId, x.EnglishName });
                    table.ForeignKey(
                        name: "FK_SpokenLanguages_MovieDetails_ParrentId",
                        column: x => x.ParrentId,
                        principalSchema: "movie",
                        principalTable: "MovieDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SpokenLanguages",
                schema: "tv",
                columns: table => new
                {
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ParrentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EnglishName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Iso6391 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpokenLanguages", x => new { x.CreationDate, x.ParrentId, x.EnglishName });
                    table.ForeignKey(
                        name: "FK_SpokenLanguages_TvDetails_ParrentId",
                        column: x => x.ParrentId,
                        principalSchema: "tv",
                        principalTable: "TvDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductionCompanies_ParrentId",
                schema: "movie",
                table: "ProductionCompanies",
                column: "ParrentId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductionCompanies_ParrentId",
                schema: "tv",
                table: "ProductionCompanies",
                column: "ParrentId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductionCountries_ParrentId",
                schema: "movie",
                table: "ProductionCountries",
                column: "ParrentId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductionCountries_ParrentId",
                schema: "tv",
                table: "ProductionCountries",
                column: "ParrentId");

            migrationBuilder.CreateIndex(
                name: "IX_SpokenLanguages_ParrentId",
                schema: "movie",
                table: "SpokenLanguages",
                column: "ParrentId");

            migrationBuilder.CreateIndex(
                name: "IX_SpokenLanguages_ParrentId",
                schema: "tv",
                table: "SpokenLanguages",
                column: "ParrentId");
        }
    }
}
