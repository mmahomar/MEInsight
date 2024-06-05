using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MEInsight.Migrations.Migrations
{
    /// <inheritdoc />
    public partial class DBUpdate03 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Organization",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "CreatedDate",
                table: "Organization",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeletedBy",
                table: "Organization",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "DeletedDate",
                table: "Organization",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Organization",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "Organization",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "ModifiedDate",
                table: "Organization",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Participant",
                columns: table => new
                {
                    ParticipantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RegistrationDate = table.Column<DateOnly>(type: "date", nullable: false),
                    OrganizationId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    RefParticipantTypeId = table.Column<int>(type: "int", nullable: false),
                    ParticipantCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MiddleName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RefSexId = table.Column<int>(type: "int", nullable: true),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Age = table.Column<int>(type: "int", nullable: true),
                    Disability = table.Column<bool>(type: "bit", nullable: true),
                    RefDisabilityTypeId = table.Column<int>(type: "int", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mobile = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Facebook = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InstantMessenger = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RefLocationId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AdditionalData = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Participant", x => x.ParticipantId);
                    table.ForeignKey(
                        name: "FK_Participant_Locations_RefLocationId",
                        column: x => x.RefLocationId,
                        principalTable: "Locations",
                        principalColumn: "RefLocationId");
                    table.ForeignKey(
                        name: "FK_Participant_Organization_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "Organization",
                        principalColumn: "OrganizationId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Participant_OrganizationId",
                table: "Participant",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_Participant_RefLocationId",
                table: "Participant",
                column: "RefLocationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Participant");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Organization");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Organization");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "Organization");

            migrationBuilder.DropColumn(
                name: "DeletedDate",
                table: "Organization");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Organization");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "Organization");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "Organization");
        }
    }
}
