using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShareStory.Migrations
{
    /// <inheritdoc />
    public partial class addTest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Like_AspNetUsers_LikedUserId",
                table: "Like");

            migrationBuilder.DropForeignKey(
                name: "FK_Like_Stories_LikedStoryId",
                table: "Like");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Like",
                table: "Like");

            migrationBuilder.RenameTable(
                name: "Like",
                newName: "Likes");

            migrationBuilder.RenameIndex(
                name: "IX_Like_LikedUserId",
                table: "Likes",
                newName: "IX_Likes_LikedUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Like_LikedStoryId",
                table: "Likes",
                newName: "IX_Likes_LikedStoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Likes",
                table: "Likes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Likes_AspNetUsers_LikedUserId",
                table: "Likes",
                column: "LikedUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Likes_Stories_LikedStoryId",
                table: "Likes",
                column: "LikedStoryId",
                principalTable: "Stories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Likes_AspNetUsers_LikedUserId",
                table: "Likes");

            migrationBuilder.DropForeignKey(
                name: "FK_Likes_Stories_LikedStoryId",
                table: "Likes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Likes",
                table: "Likes");

            migrationBuilder.RenameTable(
                name: "Likes",
                newName: "Like");

            migrationBuilder.RenameIndex(
                name: "IX_Likes_LikedUserId",
                table: "Like",
                newName: "IX_Like_LikedUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Likes_LikedStoryId",
                table: "Like",
                newName: "IX_Like_LikedStoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Like",
                table: "Like",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Like_AspNetUsers_LikedUserId",
                table: "Like",
                column: "LikedUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Like_Stories_LikedStoryId",
                table: "Like",
                column: "LikedStoryId",
                principalTable: "Stories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
