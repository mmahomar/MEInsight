using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MEInsight.Migrations.Migrations
{
    /// <inheritdoc />
    public partial class DBUpdate05 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Participant_Locations_RefLocationId",
                table: "Participant");

            migrationBuilder.DropForeignKey(
                name: "FK_Participant_Organization_OrganizationId",
                table: "Participant");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Participant",
                table: "Participant"); 

            migrationBuilder.RenameTable(
                name: "Participant",
                newName: "Participants");

            migrationBuilder.RenameIndex(
                name: "IX_Participant_RefLocationId",
                table: "Participants",
                newName: "IX_Participants_RefLocationId");

            migrationBuilder.RenameIndex(
                name: "IX_Participant_OrganizationId",
                table: "Participants",
                newName: "IX_Participants_OrganizationId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Participants",
                table: "Participants",
                column: "ParticipantId");

            migrationBuilder.AddForeignKey(
                name: "FK_Participants_Locations_RefLocationId",
                table: "Participants",
                column: "RefLocationId",
                principalTable: "Locations",
                principalColumn: "RefLocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Participants_Organization_OrganizationId",
                table: "Participants",
                column: "OrganizationId",
                principalTable: "Organization",
                principalColumn: "OrganizationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Participants_Locations_RefLocationId",
                table: "Participants");

            migrationBuilder.DropForeignKey(
                name: "FK_Participants_Organization_OrganizationId",
                table: "Participants");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Participants",
                table: "Participants");

            migrationBuilder.RenameTable(
                name: "Participants",
                newName: "Participant");

            migrationBuilder.RenameIndex(
                name: "IX_Participants_RefLocationId",
                table: "Participant",
                newName: "IX_Participant_RefLocationId");

            migrationBuilder.RenameIndex(
                name: "IX_Participants_OrganizationId",
                table: "Participant",
                newName: "IX_Participant_OrganizationId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Participant",
                table: "Participant",
                column: "ParticipantId");

            migrationBuilder.AddForeignKey(
                name: "FK_Participant_Locations_RefLocationId",
                table: "Participant",
                column: "RefLocationId",
                principalTable: "Locations",
                principalColumn: "RefLocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Participant_Organization_OrganizationId",
                table: "Participant",
                column: "OrganizationId",
                principalTable: "Organization",
                principalColumn: "OrganizationId");
        }
    }
}
