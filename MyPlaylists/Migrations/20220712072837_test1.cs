using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyPlaylists.Migrations
{
    public partial class test1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_TagsPlaylists",
                table: "TagsPlaylists");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PlaylistsSongs",
                table: "PlaylistsSongs");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "TagsPlaylists",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AlterColumn<int>(
                name: "PlaylistSongId",
                table: "PlaylistsSongs",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_TagsPlaylists",
                table: "TagsPlaylists",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PlaylistsSongs",
                table: "PlaylistsSongs",
                column: "PlaylistSongId");

            migrationBuilder.CreateIndex(
                name: "IX_TagsPlaylists_TagId",
                table: "TagsPlaylists",
                column: "TagId");

            migrationBuilder.CreateIndex(
                name: "IX_PlaylistsSongs_PlaylistId",
                table: "PlaylistsSongs",
                column: "PlaylistId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_TagsPlaylists",
                table: "TagsPlaylists");

            migrationBuilder.DropIndex(
                name: "IX_TagsPlaylists_TagId",
                table: "TagsPlaylists");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PlaylistsSongs",
                table: "PlaylistsSongs");

            migrationBuilder.DropIndex(
                name: "IX_PlaylistsSongs_PlaylistId",
                table: "PlaylistsSongs");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "TagsPlaylists",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AlterColumn<int>(
                name: "PlaylistSongId",
                table: "PlaylistsSongs",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_TagsPlaylists",
                table: "TagsPlaylists",
                columns: new[] { "TagId", "PlaylistId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_PlaylistsSongs",
                table: "PlaylistsSongs",
                columns: new[] { "PlaylistId", "SongId" });
        }
    }
}
