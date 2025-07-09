using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SMS.Migrations
{
    /// <inheritdoc />
    public partial class DBUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StudentAddress",
                table: "Students",
                newName: "Address");

            migrationBuilder.AlterColumn<string>(
                name: "MiddleName",
                table: "Students",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Parents",
                keyColumn: "EmailAddress",
                keyValue: null,
                column: "EmailAddress",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "EmailAddress",
                table: "Parents",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<DateOnly>(
                name: "BirthDate",
                table: "Parents",
                type: "date",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BirthDate",
                table: "Parents");

            migrationBuilder.RenameColumn(
                name: "Address",
                table: "Students",
                newName: "StudentAddress");

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "MiddleName",
                keyValue: null,
                column: "MiddleName",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "MiddleName",
                table: "Students",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "EmailAddress",
                table: "Parents",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");
        }
    }
}
