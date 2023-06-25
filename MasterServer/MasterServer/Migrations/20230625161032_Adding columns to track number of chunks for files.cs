using Microsoft.EntityFrameworkCore.Migrations;

namespace MasterServer.Migrations
{
    public partial class Addingcolumnstotracknumberofchunksforfiles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NumberOfChunks",
                table: "Files",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ChunkNumber",
                table: "Chunks",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumberOfChunks",
                table: "Files");

            migrationBuilder.DropColumn(
                name: "ChunkNumber",
                table: "Chunks");
        }
    }
}
