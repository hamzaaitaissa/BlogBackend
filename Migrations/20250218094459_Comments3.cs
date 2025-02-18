using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace blogfolio.Migrations
{
    /// <inheritdoc />
    public partial class Comments3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BlogId",
                table: "comments",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_comments_BlogId",
                table: "comments",
                column: "BlogId");

            migrationBuilder.AddForeignKey(
                name: "FK_comments_Blogs_BlogId",
                table: "comments",
                column: "BlogId",
                principalTable: "Blogs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_comments_Blogs_BlogId",
                table: "comments");

            migrationBuilder.DropIndex(
                name: "IX_comments_BlogId",
                table: "comments");

            migrationBuilder.DropColumn(
                name: "BlogId",
                table: "comments");
        }
    }
}
