using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MEInsight.Migrations.Migrations
{
    /// <inheritdoc />
    public partial class DBUpdate02 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Organizations_OrganizationTypes_RefOrganizationTypeId",
                table: "Organizations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Organizations",
                table: "Organizations");

            migrationBuilder.RenameTable(
                name: "Organizations",
                newName: "Organization");

            migrationBuilder.RenameIndex(
                name: "IX_Organizations_RefOrganizationTypeId",
                table: "Organization",
                newName: "IX_Organization_RefOrganizationTypeId");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Organization",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsOrganizationUnit",
                table: "Organization",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<double>(
                name: "Latitude",
                table: "Organization",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Longitude",
                table: "Organization",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ParentOrganizationId",
                table: "Organization",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RefLocationId",
                table: "Organization",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Organization",
                table: "Organization",
                column: "OrganizationId");

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    RefLocationId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LocationName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RefLocationTypeId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.RefLocationId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Organization_ParentOrganizationId",
                table: "Organization",
                column: "ParentOrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_Organization_RefLocationId",
                table: "Organization",
                column: "RefLocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Organization_Locations_RefLocationId",
                table: "Organization",
                column: "RefLocationId",
                principalTable: "Locations",
                principalColumn: "RefLocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Organization_OrganizationTypes_RefOrganizationTypeId",
                table: "Organization",
                column: "RefOrganizationTypeId",
                principalTable: "OrganizationTypes",
                principalColumn: "RefOrganizationTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Organization_Organization_ParentOrganizationId",
                table: "Organization",
                column: "ParentOrganizationId",
                principalTable: "Organization",
                principalColumn: "OrganizationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Organization_Locations_RefLocationId",
                table: "Organization");

            migrationBuilder.DropForeignKey(
                name: "FK_Organization_OrganizationTypes_RefOrganizationTypeId",
                table: "Organization");

            migrationBuilder.DropForeignKey(
                name: "FK_Organization_Organization_ParentOrganizationId",
                table: "Organization");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Organization",
                table: "Organization");

            migrationBuilder.DropIndex(
                name: "IX_Organization_ParentOrganizationId",
                table: "Organization");

            migrationBuilder.DropIndex(
                name: "IX_Organization_RefLocationId",
                table: "Organization");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "Organization");

            migrationBuilder.DropColumn(
                name: "IsOrganizationUnit",
                table: "Organization");

            migrationBuilder.DropColumn(
                name: "Latitude",
                table: "Organization");

            migrationBuilder.DropColumn(
                name: "Longitude",
                table: "Organization");

            migrationBuilder.DropColumn(
                name: "ParentOrganizationId",
                table: "Organization");

            migrationBuilder.DropColumn(
                name: "RefLocationId",
                table: "Organization");

            migrationBuilder.RenameTable(
                name: "Organization",
                newName: "Organizations");

            migrationBuilder.RenameIndex(
                name: "IX_Organization_RefOrganizationTypeId",
                table: "Organizations",
                newName: "IX_Organizations_RefOrganizationTypeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Organizations",
                table: "Organizations",
                column: "OrganizationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Organizations_OrganizationTypes_RefOrganizationTypeId",
                table: "Organizations",
                column: "RefOrganizationTypeId",
                principalTable: "OrganizationTypes",
                principalColumn: "RefOrganizationTypeId");
        }
    }
}
