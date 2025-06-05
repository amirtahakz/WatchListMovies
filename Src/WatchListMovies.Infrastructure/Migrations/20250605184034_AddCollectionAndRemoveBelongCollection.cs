using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WatchListMovies.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddCollectionAndRemoveBelongCollection : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BelongsToCollections",
                schema: "movie");

            migrationBuilder.EnsureSchema(
                name: "collection");

            migrationBuilder.AddColumn<long>(
                name: "CollectionApiId",
                schema: "movie",
                table: "MovieDetails",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Collections",
                schema: "collection",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ParrentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ApiModelId = table.Column<long>(type: "bigint", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    PosterPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BackdropPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Collections", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CollectionDetails",
                schema: "collection",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ParrentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ApiModelId = table.Column<long>(type: "bigint", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Overview = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PosterPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BackdropPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CollectionDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CollectionDetails_Collections_Id",
                        column: x => x.Id,
                        principalSchema: "collection",
                        principalTable: "Collections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CollectionDetails_ApiModelId",
                schema: "collection",
                table: "CollectionDetails",
                column: "ApiModelId",
                unique: true,
                filter: "[ApiModelId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Collections_ApiModelId",
                schema: "collection",
                table: "Collections",
                column: "ApiModelId",
                unique: true,
                filter: "[ApiModelId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Collections_Name",
                schema: "collection",
                table: "Collections",
                column: "Name");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CollectionDetails",
                schema: "collection");

            migrationBuilder.DropTable(
                name: "Collections",
                schema: "collection");

            migrationBuilder.DropColumn(
                name: "CollectionApiId",
                schema: "movie",
                table: "MovieDetails");

            migrationBuilder.CreateTable(
                name: "BelongsToCollections",
                schema: "movie",
                columns: table => new
                {
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ParrentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ApiModelId = table.Column<long>(type: "bigint", nullable: true),
                    BackdropPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PosterPath = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BelongsToCollections", x => new { x.CreationDate, x.ParrentId, x.Name });
                    table.ForeignKey(
                        name: "FK_BelongsToCollections_MovieDetails_ParrentId",
                        column: x => x.ParrentId,
                        principalSchema: "movie",
                        principalTable: "MovieDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BelongsToCollections_ParrentId",
                schema: "movie",
                table: "BelongsToCollections",
                column: "ParrentId",
                unique: true);
        }
    }
}
