using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EquipTrack.Migrations
{
    /// <inheritdoc />
    public partial class AddRecyclingRecord : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RecyclingRecords",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AssetId = table.Column<int>(type: "INTEGER", nullable: false),
                    DisposedOn = table.Column<DateTime>(type: "TEXT", nullable: false),
                    WipeMethod = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    DisposalMethod = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Notes = table.Column<string>(type: "TEXT", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecyclingRecords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RecyclingRecords_Assets_AssetId",
                        column: x => x.AssetId,
                        principalTable: "Assets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RecyclingRecords_AssetId",
                table: "RecyclingRecords",
                column: "AssetId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RecyclingRecords");
        }
    }
}
