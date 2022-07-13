using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyPlaylists.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "PlaylistsSongs",
                newName: "PlaylistSongId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PlaylistSongId",
                table: "PlaylistsSongs",
                newName: "Id");
        }
    }
}
