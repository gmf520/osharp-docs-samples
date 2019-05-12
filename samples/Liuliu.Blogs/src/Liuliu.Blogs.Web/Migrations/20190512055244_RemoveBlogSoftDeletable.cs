using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Liuliu.Blogs.Web.Migrations
{
    public partial class RemoveBlogSoftDeletable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "BlogUrlIndex",
                table: "Blog");

            migrationBuilder.DropColumn(
                name: "DeletedTime",
                table: "Blog");

            migrationBuilder.CreateIndex(
                name: "BlogUrlIndex",
                table: "Blog",
                column: "Url",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "BlogUrlIndex",
                table: "Blog");

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedTime",
                table: "Blog",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "BlogUrlIndex",
                table: "Blog",
                columns: new[] { "Url", "DeletedTime" },
                unique: true,
                filter: "[DeletedTime] IS NOT NULL");
        }
    }
}
