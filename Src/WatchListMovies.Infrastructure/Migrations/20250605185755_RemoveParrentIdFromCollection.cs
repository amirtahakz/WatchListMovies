using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WatchListMovies.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RemoveParrentIdFromCollection : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ParrentId",
                schema: "collection",
                table: "Collections");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ParrentId",
                schema: "collection",
                table: "Collections",
                type: "uniqueidentifier",
                nullable: true);
        }
    }
}
