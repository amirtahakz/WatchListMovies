using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WatchListMovies.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RemoveMovieYoutubeKeys : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MovieKeyYoutubeTrailers");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MovieKeyYoutubeTrailers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ApiModelId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Iso31661 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Iso6391 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Key = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Official = table.Column<bool>(type: "bit", nullable: true),
                    ParrentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PublishedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Site = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Size = table.Column<long>(type: "bigint", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieKeyYoutubeTrailers", x => x.Id);
                });
        }
    }
}
