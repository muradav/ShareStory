using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShareStory.Migrations
{
    /// <inheritdoc />
    public partial class addLikeEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Like",
                table: "Stories",
                newName: "LikeCount");

            migrationBuilder.CreateTable(
                name: "Like",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LikedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Liked = table.Column<bool>(type: "bit", nullable: false),
                    LikedUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LikedStoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Like", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Like_AspNetUsers_LikedUserId",
                        column: x => x.LikedUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Like_Stories_LikedStoryId",
                        column: x => x.LikedStoryId,
                        principalTable: "Stories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Like_LikedStoryId",
                table: "Like",
                column: "LikedStoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Like_LikedUserId",
                table: "Like",
                column: "LikedUserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Like");

            migrationBuilder.RenameColumn(
                name: "LikeCount",
                table: "Stories",
                newName: "Like");
        }
    }
}
