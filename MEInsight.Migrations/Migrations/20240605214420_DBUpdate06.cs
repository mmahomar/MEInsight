using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MEInsight.Migrations.Migrations
{
    /// <inheritdoc />
    public partial class DBUpdate06 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Organization_Locations_RefLocationId",
                table: "Organization");

            migrationBuilder.DropForeignKey(
                name: "FK_Participants_Locations_RefLocationId",
                table: "Participants");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Locations",
                table: "Locations");

            migrationBuilder.RenameTable(
                name: "Locations",
                newName: "RefLocation");

            migrationBuilder.AddColumn<string>(
                name: "OrganizationTypeCode",
                table: "OrganizationTypes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RefLocation",
                table: "RefLocation",
                column: "RefLocationId");

            migrationBuilder.CreateTable(
                name: "Program",
                columns: table => new
                {
                    ProgramId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProgramName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    RefProgramTypeId = table.Column<int>(type: "int", nullable: true),
                    RefProgramDeliveryTypeId = table.Column<int>(type: "int", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Max = table.Column<int>(type: "int", nullable: true),
                    Min = table.Column<int>(type: "int", nullable: true),
                    RefAttendanceUnitId = table.Column<int>(type: "int", nullable: true),
                    HasAssessment = table.Column<bool>(type: "bit", nullable: false),
                    DisplayMarks = table.Column<bool>(type: "bit", nullable: false),
                    RefOrganizationTypeId = table.Column<int>(type: "int", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CreatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ModifiedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DeletedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Program", x => x.ProgramId);
                    table.ForeignKey(
                        name: "FK_Program_OrganizationTypes_RefOrganizationTypeId",
                        column: x => x.RefOrganizationTypeId,
                        principalTable: "OrganizationTypes",
                        principalColumn: "RefOrganizationTypeId");
                });

            migrationBuilder.CreateTable(
                name: "Group",
                columns: table => new
                {
                    GroupId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrganizationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProgramId = table.Column<int>(type: "int", nullable: false),
                    GroupCode = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    GroupName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ParticipantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    RefGradeLevelId = table.Column<int>(type: "int", nullable: true),
                    CompletionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Closed = table.Column<bool>(type: "bit", nullable: true),
                    ClosedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ClosedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CreatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ModifiedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DeletedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Group", x => x.GroupId);
                    table.ForeignKey(
                        name: "FK_Group_Organization_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "Organization",
                        principalColumn: "OrganizationId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Group_Program_ProgramId",
                        column: x => x.ProgramId,
                        principalTable: "Program",
                        principalColumn: "ProgramId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProgramAssessment",
                columns: table => new
                {
                    ProgramAssessmentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProgramId = table.Column<int>(type: "int", nullable: false),
                    AssessmentName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    RefAssessmentTypeId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    TrackAttendance = table.Column<bool>(type: "bit", nullable: false),
                    Max = table.Column<int>(type: "int", nullable: true),
                    Min = table.Column<int>(type: "int", nullable: true),
                    RefAttendanceUnitId = table.Column<int>(type: "int", nullable: true),
                    MaximumScore = table.Column<int>(type: "int", nullable: true),
                    MinimumScore = table.Column<int>(type: "int", nullable: true),
                    CompletionScore = table.Column<int>(type: "int", nullable: true),
                    RefEvaluationStatusId = table.Column<int>(type: "int", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CreatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ModifiedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DeletedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProgramAssessment", x => x.ProgramAssessmentId);
                    table.ForeignKey(
                        name: "FK_ProgramAssessment_Program_ProgramId",
                        column: x => x.ProgramId,
                        principalTable: "Program",
                        principalColumn: "ProgramId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GroupEnrollment",
                columns: table => new
                {
                    GroupEnrollmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GroupId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ParticipantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EnrollmentDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Attendance = table.Column<int>(type: "int", nullable: true),
                    StatusDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RefEnrollmentStatusId = table.Column<int>(type: "int", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CreatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ModifiedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DeletedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupEnrollment", x => x.GroupEnrollmentId);
                    table.ForeignKey(
                        name: "FK_GroupEnrollment_Group_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Group",
                        principalColumn: "GroupId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GroupEnrollment_Participants_ParticipantId",
                        column: x => x.ParticipantId,
                        principalTable: "Participants",
                        principalColumn: "ParticipantId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GroupEvaluation",
                columns: table => new
                {
                    GroupEvaluationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GroupEnrollmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EvaluationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ProgramAssessmentId = table.Column<int>(type: "int", nullable: true),
                    Score = table.Column<int>(type: "int", nullable: true),
                    StatusDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RefEvaluationStatusId = table.Column<int>(type: "int", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CreatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ModifiedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DeletedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupEvaluation", x => x.GroupEvaluationId);
                    table.ForeignKey(
                        name: "FK_GroupEvaluation_GroupEnrollment_GroupEnrollmentId",
                        column: x => x.GroupEnrollmentId,
                        principalTable: "GroupEnrollment",
                        principalColumn: "GroupEnrollmentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GroupEvaluation_ProgramAssessment_ProgramAssessmentId",
                        column: x => x.ProgramAssessmentId,
                        principalTable: "ProgramAssessment",
                        principalColumn: "ProgramAssessmentId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Group_OrganizationId",
                table: "Group",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_Group_ProgramId",
                table: "Group",
                column: "ProgramId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupEnrollment_GroupId",
                table: "GroupEnrollment",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupEnrollment_ParticipantId",
                table: "GroupEnrollment",
                column: "ParticipantId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupEvaluation_GroupEnrollmentId",
                table: "GroupEvaluation",
                column: "GroupEnrollmentId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupEvaluation_ProgramAssessmentId",
                table: "GroupEvaluation",
                column: "ProgramAssessmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Program_RefOrganizationTypeId",
                table: "Program",
                column: "RefOrganizationTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ProgramAssessment_ProgramId",
                table: "ProgramAssessment",
                column: "ProgramId");

            migrationBuilder.AddForeignKey(
                name: "FK_Organization_RefLocation_RefLocationId",
                table: "Organization",
                column: "RefLocationId",
                principalTable: "RefLocation",
                principalColumn: "RefLocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Participants_RefLocation_RefLocationId",
                table: "Participants",
                column: "RefLocationId",
                principalTable: "RefLocation",
                principalColumn: "RefLocationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Organization_RefLocation_RefLocationId",
                table: "Organization");

            migrationBuilder.DropForeignKey(
                name: "FK_Participants_RefLocation_RefLocationId",
                table: "Participants");

            migrationBuilder.DropTable(
                name: "GroupEvaluation");

            migrationBuilder.DropTable(
                name: "GroupEnrollment");

            migrationBuilder.DropTable(
                name: "ProgramAssessment");

            migrationBuilder.DropTable(
                name: "Group");

            migrationBuilder.DropTable(
                name: "Program");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RefLocation",
                table: "RefLocation");

            migrationBuilder.DropColumn(
                name: "OrganizationTypeCode",
                table: "OrganizationTypes");

            migrationBuilder.RenameTable(
                name: "RefLocation",
                newName: "Locations");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Locations",
                table: "Locations",
                column: "RefLocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Organization_Locations_RefLocationId",
                table: "Organization",
                column: "RefLocationId",
                principalTable: "Locations",
                principalColumn: "RefLocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Participants_Locations_RefLocationId",
                table: "Participants",
                column: "RefLocationId",
                principalTable: "Locations",
                principalColumn: "RefLocationId");
        }
    }
}
