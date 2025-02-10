using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace blogfolio.Migrations
{
    /// <inheritdoc />
    public partial class createdDate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Blogs",
                type: "TEXT",
                nullable: false,
                defaultValueSql: "DATETIME('now')");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Blogs");
        }
    }
}
