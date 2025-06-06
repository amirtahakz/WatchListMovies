using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WatchListMovies.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RemoveMovieKayYoutubeTrailersAndAddVideos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MovieKeyYoutubeTrailers_MovieDetails_MovieDetailId",
                schema: "movie",
                table: "MovieKeyYoutubeTrailers");

            migrationBuilder.DropIndex(
                name: "IX_MovieKeyYoutubeTrailers_ApiModelId",
                schema: "movie",
                table: "MovieKeyYoutubeTrailers");

            migrationBuilder.DropIndex(
                name: "IX_MovieKeyYoutubeTrailers_MovieDetailId",
                schema: "movie",
                table: "MovieKeyYoutubeTrailers");

            migrationBuilder.DropColumn(
                name: "MovieDetailId",
                schema: "movie",
                table: "MovieKeyYoutubeTrailers");

            migrationBuilder.RenameTable(
                name: "MovieKeyYoutubeTrailers",
                schema: "movie",
                newName: "MovieKeyYoutubeTrailers");

            migrationBuilder.AlterColumn<string>(
                name: "ApiModelId",
                table: "MovieKeyYoutubeTrailers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Videos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ContentApiId = table.Column<long>(type: "bigint", nullable: true),
                    ApiModelId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Iso6391 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Iso31661 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Key = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Site = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Size = table.Column<long>(type: "bigint", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Official = table.Column<bool>(type: "bit", nullable: true),
                    PublishedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    VideoMediaType = table.Column<int>(type: "int", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Videos", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Videos_ApiModelId",
                table: "Videos",
                column: "ApiModelId",
                unique: true,
                filter: "[ApiModelId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Videos_Name",
                table: "Videos",
                column: "Name");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Videos");

            migrationBuilder.RenameTable(
                name: "MovieKeyYoutubeTrailers",
                newName: "MovieKeyYoutubeTrailers",
                newSchema: "movie");

            migrationBuilder.AlterColumn<string>(
                name: "ApiModelId",
                schema: "movie",
                table: "MovieKeyYoutubeTrailers",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "MovieDetailId",
                schema: "movie",
                table: "MovieKeyYoutubeTrailers",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_MovieKeyYoutubeTrailers_ApiModelId",
                schema: "movie",
                table: "MovieKeyYoutubeTrailers",
                column: "ApiModelId",
                unique: true,
                filter: "[ApiModelId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_MovieKeyYoutubeTrailers_MovieDetailId",
                schema: "movie",
                table: "MovieKeyYoutubeTrailers",
                column: "MovieDetailId");

            migrationBuilder.AddForeignKey(
                name: "FK_MovieKeyYoutubeTrailers_MovieDetails_MovieDetailId",
                schema: "movie",
                table: "MovieKeyYoutubeTrailers",
                column: "MovieDetailId",
                principalSchema: "movie",
                principalTable: "MovieDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
