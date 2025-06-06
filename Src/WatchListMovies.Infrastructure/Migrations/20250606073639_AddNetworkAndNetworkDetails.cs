using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WatchListMovies.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddNetworkAndNetworkDetails : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Networks_TvDetails_ParrentId",
                schema: "tv",
                table: "Networks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Networks",
                schema: "tv",
                table: "Networks");

            migrationBuilder.DropIndex(
                name: "IX_Networks_ParrentId",
                schema: "tv",
                table: "Networks");

            migrationBuilder.EnsureSchema(
                name: "network");

            migrationBuilder.RenameTable(
                name: "Networks",
                schema: "tv",
                newName: "Networks",
                newSchema: "network");

            migrationBuilder.RenameColumn(
                name: "ParrentId",
                schema: "network",
                table: "Networks",
                newName: "Id");

            migrationBuilder.AddColumn<string>(
                name: "NetworkIds",
                schema: "tv",
                table: "TvDetails",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "network",
                table: "Networks",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Networks",
                schema: "network",
                table: "Networks",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "NetworkDetails",
                schema: "network",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Headquarters = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Homepage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApiModelId = table.Column<long>(type: "bigint", nullable: true),
                    LogoPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OriginCountry = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ParrentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NetworkDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NetworkDetails_Networks_Id",
                        column: x => x.Id,
                        principalSchema: "network",
                        principalTable: "Networks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Networks_ApiModelId",
                schema: "network",
                table: "Networks",
                column: "ApiModelId",
                unique: true,
                filter: "[ApiModelId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Networks_Name",
                schema: "network",
                table: "Networks",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_NetworkDetails_ApiModelId",
                schema: "network",
                table: "NetworkDetails",
                column: "ApiModelId",
                unique: true,
                filter: "[ApiModelId] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NetworkDetails",
                schema: "network");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Networks",
                schema: "network",
                table: "Networks");

            migrationBuilder.DropIndex(
                name: "IX_Networks_ApiModelId",
                schema: "network",
                table: "Networks");

            migrationBuilder.DropIndex(
                name: "IX_Networks_Name",
                schema: "network",
                table: "Networks");

            migrationBuilder.DropColumn(
                name: "NetworkIds",
                schema: "tv",
                table: "TvDetails");

            migrationBuilder.RenameTable(
                name: "Networks",
                schema: "network",
                newName: "Networks",
                newSchema: "tv");

            migrationBuilder.RenameColumn(
                name: "Id",
                schema: "tv",
                table: "Networks",
                newName: "ParrentId");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "tv",
                table: "Networks",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Networks",
                schema: "tv",
                table: "Networks",
                columns: new[] { "CreationDate", "ParrentId", "Name" });

            migrationBuilder.CreateIndex(
                name: "IX_Networks_ParrentId",
                schema: "tv",
                table: "Networks",
                column: "ParrentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Networks_TvDetails_ParrentId",
                schema: "tv",
                table: "Networks",
                column: "ParrentId",
                principalSchema: "tv",
                principalTable: "TvDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
