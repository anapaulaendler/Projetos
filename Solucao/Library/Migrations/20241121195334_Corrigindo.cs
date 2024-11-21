using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Library.Migrations
{
    /// <inheritdoc />
    public partial class Corrigindo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "BorrowDate",
                table: "Books",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "BorrowedById",
                table: "Books",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ReturnDate",
                table: "Books",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Books_BorrowedById",
                table: "Books",
                column: "BorrowedById");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Members_BorrowedById",
                table: "Books",
                column: "BorrowedById",
                principalTable: "Members",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Members_BorrowedById",
                table: "Books");

            migrationBuilder.DropIndex(
                name: "IX_Books_BorrowedById",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "BorrowDate",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "BorrowedById",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "ReturnDate",
                table: "Books");
        }
    }
}
