using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MEInsight.Migrations.Migrations
{
    /// <inheritdoc />
    public partial class DBUpdate04 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Participant",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "CreatedDate",
                table: "Participant",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeletedBy",
                table: "Participant",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "DeletedDate",
                table: "Participant",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Participant",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "Participant",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "ModifiedDate",
                table: "Participant",
                type: "datetimeoffset",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Participant");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Participant");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "Participant");

            migrationBuilder.DropColumn(
                name: "DeletedDate",
                table: "Participant");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Participant");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "Participant");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "Participant");
        }
    }
}
