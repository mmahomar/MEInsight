using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MEInsight.Migrations.Migrations
{
    /// <inheritdoc />
    public partial class DBUpdate01 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EducationCenterPeriod",
                columns: table => new
                {
                    EducationCenterPeriodId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PeriodName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
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
                    table.PrimaryKey("PK_EducationCenterPeriod", x => x.EducationCenterPeriodId);
                });

            migrationBuilder.CreateTable(
                name: "RefDisabilityType",
                columns: table => new
                {
                    RefDisabilityTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    DisabilityType = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Data = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefDisabilityType", x => x.RefDisabilityTypeId);
                });

            migrationBuilder.CreateTable(
                name: "RefEducationCenterAdministrationType",
                columns: table => new
                {
                    RefEducationCenterAdministrationTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    EducationCenterAdministrationType = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefEducationCenterAdministrationType", x => x.RefEducationCenterAdministrationTypeId);
                });

            migrationBuilder.CreateTable(
                name: "RefEducationCenterLanguage",
                columns: table => new
                {
                    RefEducationCenterLanguageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    EducationCenterLanguage = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefEducationCenterLanguage", x => x.RefEducationCenterLanguageId);
                });

            migrationBuilder.CreateTable(
                name: "RefEducationCenterLocation",
                columns: table => new
                {
                    RefEducationCenterLocationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    EducationCenterLocation = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefEducationCenterLocation", x => x.RefEducationCenterLocationId);
                });

            migrationBuilder.CreateTable(
                name: "RefEducationCenterStatus",
                columns: table => new
                {
                    RefEducationCenterStatusId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    EduccationCenterStatus = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefEducationCenterStatus", x => x.RefEducationCenterStatusId);
                });

            migrationBuilder.CreateTable(
                name: "RefEducationCenterType",
                columns: table => new
                {
                    RefEducationCenterTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    EducationCenterType = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefEducationCenterType", x => x.RefEducationCenterTypeId);
                });

            migrationBuilder.CreateTable(
                name: "RefGradeLevel",
                columns: table => new
                {
                    RefGradeLevelId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    GradeLevel = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    GradeLevelId = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefGradeLevel", x => x.RefGradeLevelId);
                });

            migrationBuilder.CreateTable(
                name: "RefLocationType",
                columns: table => new
                {
                    RefLocationTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    LocationType = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    LocationLevel = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefLocationType", x => x.RefLocationTypeId);
                });

            migrationBuilder.CreateTable(
                name: "RefOrganizationType",
                columns: table => new
                {
                    RefOrganizationTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RefOrganizationTypeName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Code = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefOrganizationType", x => x.RefOrganizationTypeId);
                });

            migrationBuilder.CreateTable(
                name: "RefParticipantCohort",
                columns: table => new
                {
                    RefParticipantCohortId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    ParticipantCohort = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefParticipantCohort", x => x.RefParticipantCohortId);
                });

            migrationBuilder.CreateTable(
                name: "RefParticipantType",
                columns: table => new
                {
                    RefParticipantTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    ParticipantType = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefParticipantType", x => x.RefParticipantTypeId);
                });

            migrationBuilder.CreateTable(
                name: "RefProgramType",
                columns: table => new
                {
                    RefProgramTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    ProgramType = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefProgramType", x => x.RefProgramTypeId);
                });

            migrationBuilder.CreateTable(
                name: "RefSex",
                columns: table => new
                {
                    RefSexId = table.Column<int>(type: "int", nullable: false),
                    Sex = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SexId = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefSex", x => x.RefSexId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RefLocation",
                columns: table => new
                {
                    RefLocationId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LocationName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RefLocationTypeId = table.Column<int>(type: "int", nullable: false),
                    ParentLocationId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Latitude = table.Column<double>(type: "float", nullable: true),
                    Longitude = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefLocation", x => x.RefLocationId);
                    table.ForeignKey(
                        name: "FK_RefLocation_RefLocationType_RefLocationTypeId",
                        column: x => x.RefLocationTypeId,
                        principalTable: "RefLocationType",
                        principalColumn: "RefLocationTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RefLocation_RefLocation_ParentLocationId",
                        column: x => x.ParentLocationId,
                        principalTable: "RefLocation",
                        principalColumn: "RefLocationId");
                });

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
                        name: "FK_Program_RefOrganizationType_RefOrganizationTypeId",
                        column: x => x.RefOrganizationTypeId,
                        principalTable: "RefOrganizationType",
                        principalColumn: "RefOrganizationTypeId");
                    table.ForeignKey(
                        name: "FK_Program_RefProgramType_RefProgramTypeId",
                        column: x => x.RefProgramTypeId,
                        principalTable: "RefProgramType",
                        principalColumn: "RefProgramTypeId");
                });

            migrationBuilder.CreateTable(
                name: "Organization",
                columns: table => new
                {
                    OrganizationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrganizationName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RefOrganizationTypeId = table.Column<int>(type: "int", nullable: true),
                    ParentOrganizationId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    RefLocationId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Latitude = table.Column<double>(type: "float", nullable: true),
                    Longitude = table.Column<double>(type: "float", nullable: true),
                    IsOrganizationUnit = table.Column<bool>(type: "bit", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RegistrationDate = table.Column<DateOnly>(type: "date", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CreatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ModifiedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DeletedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Data = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organization", x => x.OrganizationId);
                    table.ForeignKey(
                        name: "FK_Organization_Organization_ParentOrganizationId",
                        column: x => x.ParentOrganizationId,
                        principalTable: "Organization",
                        principalColumn: "OrganizationId");
                    table.ForeignKey(
                        name: "FK_Organization_RefLocation_RefLocationId",
                        column: x => x.RefLocationId,
                        principalTable: "RefLocation",
                        principalColumn: "RefLocationId");
                    table.ForeignKey(
                        name: "FK_Organization_RefOrganizationType_RefOrganizationTypeId",
                        column: x => x.RefOrganizationTypeId,
                        principalTable: "RefOrganizationType",
                        principalColumn: "RefOrganizationTypeId");
                });

            migrationBuilder.CreateTable(
                name: "RefEducationCenterCluster",
                columns: table => new
                {
                    RefEducationCenterClusterId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    EducationCenterCluster = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    RefLocationId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefEducationCenterCluster", x => x.RefEducationCenterClusterId);
                    table.ForeignKey(
                        name: "FK_RefEducationCenterCluster_RefLocation_RefLocationId",
                        column: x => x.RefLocationId,
                        principalTable: "RefLocation",
                        principalColumn: "RefLocationId");
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
                    table.ForeignKey(
                        name: "FK_Group_RefGradeLevel_RefGradeLevelId",
                        column: x => x.RefGradeLevelId,
                        principalTable: "RefGradeLevel",
                        principalColumn: "RefGradeLevelId");
                });

            migrationBuilder.CreateTable(
                name: "Participant",
                columns: table => new
                {
                    ParticipantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RegistrationDate = table.Column<DateOnly>(type: "date", nullable: false),
                    OrganizationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RefParticipantTypeId = table.Column<int>(type: "int", nullable: false),
                    RefParticipantCohortId = table.Column<int>(type: "int", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: false),
                    MiddleName = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: false),
                    RefSexId = table.Column<int>(type: "int", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Age = table.Column<int>(type: "int", nullable: true),
                    Disability = table.Column<bool>(type: "bit", nullable: true),
                    RefDisabilityTypeId = table.Column<int>(type: "int", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Mobile = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(320)", maxLength: 320, nullable: true),
                    Facebook = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    InstantMessenger = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    RefLocationId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AdditionalData = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_Participant", x => x.ParticipantId);
                    table.ForeignKey(
                        name: "FK_Participant_Organization_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "Organization",
                        principalColumn: "OrganizationId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Participant_RefDisabilityType_RefDisabilityTypeId",
                        column: x => x.RefDisabilityTypeId,
                        principalTable: "RefDisabilityType",
                        principalColumn: "RefDisabilityTypeId");
                    table.ForeignKey(
                        name: "FK_Participant_RefLocation_RefLocationId",
                        column: x => x.RefLocationId,
                        principalTable: "RefLocation",
                        principalColumn: "RefLocationId");
                    table.ForeignKey(
                        name: "FK_Participant_RefParticipantCohort_RefParticipantCohortId",
                        column: x => x.RefParticipantCohortId,
                        principalTable: "RefParticipantCohort",
                        principalColumn: "RefParticipantCohortId");
                    table.ForeignKey(
                        name: "FK_Participant_RefParticipantType_RefParticipantTypeId",
                        column: x => x.RefParticipantTypeId,
                        principalTable: "RefParticipantType",
                        principalColumn: "RefParticipantTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Participant_RefSex_RefSexId",
                        column: x => x.RefSexId,
                        principalTable: "RefSex",
                        principalColumn: "RefSexId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EducationCenter",
                columns: table => new
                {
                    Code = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    RefEducationCenterTypeId = table.Column<int>(type: "int", nullable: true),
                    RefEducationCenterLocationId = table.Column<int>(type: "int", nullable: true),
                    RefEducationCenterLanguageId = table.Column<int>(type: "int", nullable: true),
                    RefEducationCenterAdministrationTypeId = table.Column<int>(type: "int", nullable: true),
                    PartnerId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsClusterCenter = table.Column<bool>(type: "bit", nullable: true),
                    RefEducationCenterClusterId = table.Column<int>(type: "int", nullable: true),
                    RefEducationCenterStatusId = table.Column<int>(type: "int", nullable: true),
                    HeadTeacher = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    OrganizationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EducationCenter", x => x.OrganizationId);
                    table.ForeignKey(
                        name: "FK_EducationCenter_Organization_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "Organization",
                        principalColumn: "OrganizationId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EducationCenter_RefEducationCenterAdministrationType_RefEducationCenterAdministrationTypeId",
                        column: x => x.RefEducationCenterAdministrationTypeId,
                        principalTable: "RefEducationCenterAdministrationType",
                        principalColumn: "RefEducationCenterAdministrationTypeId");
                    table.ForeignKey(
                        name: "FK_EducationCenter_RefEducationCenterCluster_RefEducationCenterClusterId",
                        column: x => x.RefEducationCenterClusterId,
                        principalTable: "RefEducationCenterCluster",
                        principalColumn: "RefEducationCenterClusterId");
                    table.ForeignKey(
                        name: "FK_EducationCenter_RefEducationCenterLanguage_RefEducationCenterLanguageId",
                        column: x => x.RefEducationCenterLanguageId,
                        principalTable: "RefEducationCenterLanguage",
                        principalColumn: "RefEducationCenterLanguageId");
                    table.ForeignKey(
                        name: "FK_EducationCenter_RefEducationCenterLocation_RefEducationCenterLocationId",
                        column: x => x.RefEducationCenterLocationId,
                        principalTable: "RefEducationCenterLocation",
                        principalColumn: "RefEducationCenterLocationId");
                    table.ForeignKey(
                        name: "FK_EducationCenter_RefEducationCenterStatus_RefEducationCenterStatusId",
                        column: x => x.RefEducationCenterStatusId,
                        principalTable: "RefEducationCenterStatus",
                        principalColumn: "RefEducationCenterStatusId");
                    table.ForeignKey(
                        name: "FK_EducationCenter_RefEducationCenterType_RefEducationCenterTypeId",
                        column: x => x.RefEducationCenterTypeId,
                        principalTable: "RefEducationCenterType",
                        principalColumn: "RefEducationCenterTypeId");
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
                        principalColumn: "GroupId");
                    table.ForeignKey(
                        name: "FK_GroupEnrollment_Participant_ParticipantId",
                        column: x => x.ParticipantId,
                        principalTable: "Participant",
                        principalColumn: "ParticipantId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EducationCenterClassroom",
                columns: table => new
                {
                    EducationCenterClassroomId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RegistrationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OrganizationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EducationCenterPeriodId = table.Column<int>(type: "int", nullable: false),
                    RefGradeLevelId = table.Column<int>(type: "int", nullable: false),
                    Classrooms = table.Column<int>(type: "int", nullable: true),
                    Classes = table.Column<int>(type: "int", nullable: true),
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
                    table.PrimaryKey("PK_EducationCenterClassroom", x => x.EducationCenterClassroomId);
                    table.ForeignKey(
                        name: "FK_EducationCenterClassroom_EducationCenterPeriod_EducationCenterPeriodId",
                        column: x => x.EducationCenterPeriodId,
                        principalTable: "EducationCenterPeriod",
                        principalColumn: "EducationCenterPeriodId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EducationCenterClassroom_EducationCenter_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "EducationCenter",
                        principalColumn: "OrganizationId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EducationCenterClassroom_RefGradeLevel_RefGradeLevelId",
                        column: x => x.RefGradeLevelId,
                        principalTable: "RefGradeLevel",
                        principalColumn: "RefGradeLevelId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EducationCenterEnrollment",
                columns: table => new
                {
                    EducationCenterEnrollmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RegistrationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OrganizationId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    EducationCenterPeriodId = table.Column<int>(type: "int", nullable: false),
                    RefParticipantTypeId = table.Column<int>(type: "int", nullable: false),
                    RefGradeLevelId = table.Column<int>(type: "int", nullable: false),
                    Male = table.Column<int>(type: "int", nullable: true),
                    Female = table.Column<int>(type: "int", nullable: true),
                    DisabledMale = table.Column<int>(type: "int", nullable: true),
                    DisabledFemale = table.Column<int>(type: "int", nullable: true),
                    SchoolPeriodId = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_EducationCenterEnrollment", x => x.EducationCenterEnrollmentId);
                    table.ForeignKey(
                        name: "FK_EducationCenterEnrollment_EducationCenterPeriod_SchoolPeriodId",
                        column: x => x.SchoolPeriodId,
                        principalTable: "EducationCenterPeriod",
                        principalColumn: "EducationCenterPeriodId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EducationCenterEnrollment_EducationCenter_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "EducationCenter",
                        principalColumn: "OrganizationId");
                    table.ForeignKey(
                        name: "FK_EducationCenterEnrollment_RefGradeLevel_RefGradeLevelId",
                        column: x => x.RefGradeLevelId,
                        principalTable: "RefGradeLevel",
                        principalColumn: "RefGradeLevelId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EducationCenterEnrollment_RefParticipantType_RefParticipantTypeId",
                        column: x => x.RefParticipantTypeId,
                        principalTable: "RefParticipantType",
                        principalColumn: "RefParticipantTypeId",
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
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_EducationCenter_RefEducationCenterAdministrationTypeId",
                table: "EducationCenter",
                column: "RefEducationCenterAdministrationTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_EducationCenter_RefEducationCenterClusterId",
                table: "EducationCenter",
                column: "RefEducationCenterClusterId");

            migrationBuilder.CreateIndex(
                name: "IX_EducationCenter_RefEducationCenterLanguageId",
                table: "EducationCenter",
                column: "RefEducationCenterLanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_EducationCenter_RefEducationCenterLocationId",
                table: "EducationCenter",
                column: "RefEducationCenterLocationId");

            migrationBuilder.CreateIndex(
                name: "IX_EducationCenter_RefEducationCenterStatusId",
                table: "EducationCenter",
                column: "RefEducationCenterStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_EducationCenter_RefEducationCenterTypeId",
                table: "EducationCenter",
                column: "RefEducationCenterTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_EducationCenterClassroom_EducationCenterPeriodId",
                table: "EducationCenterClassroom",
                column: "EducationCenterPeriodId");

            migrationBuilder.CreateIndex(
                name: "IX_EducationCenterClassroom_OrganizationId",
                table: "EducationCenterClassroom",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_EducationCenterClassroom_RefGradeLevelId",
                table: "EducationCenterClassroom",
                column: "RefGradeLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_EducationCenterEnrollment_OrganizationId",
                table: "EducationCenterEnrollment",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_EducationCenterEnrollment_RefGradeLevelId",
                table: "EducationCenterEnrollment",
                column: "RefGradeLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_EducationCenterEnrollment_RefParticipantTypeId",
                table: "EducationCenterEnrollment",
                column: "RefParticipantTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_EducationCenterEnrollment_SchoolPeriodId",
                table: "EducationCenterEnrollment",
                column: "SchoolPeriodId");

            migrationBuilder.CreateIndex(
                name: "IX_Group_OrganizationId",
                table: "Group",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_Group_ProgramId",
                table: "Group",
                column: "ProgramId");

            migrationBuilder.CreateIndex(
                name: "IX_Group_RefGradeLevelId",
                table: "Group",
                column: "RefGradeLevelId");

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
                name: "IX_Organization_ParentOrganizationId",
                table: "Organization",
                column: "ParentOrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_Organization_RefLocationId",
                table: "Organization",
                column: "RefLocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Organization_RefOrganizationTypeId",
                table: "Organization",
                column: "RefOrganizationTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Participant_OrganizationId",
                table: "Participant",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_Participant_RefDisabilityTypeId",
                table: "Participant",
                column: "RefDisabilityTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Participant_RefLocationId",
                table: "Participant",
                column: "RefLocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Participant_RefParticipantCohortId",
                table: "Participant",
                column: "RefParticipantCohortId");

            migrationBuilder.CreateIndex(
                name: "IX_Participant_RefParticipantTypeId",
                table: "Participant",
                column: "RefParticipantTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Participant_RefSexId",
                table: "Participant",
                column: "RefSexId");

            migrationBuilder.CreateIndex(
                name: "IX_Program_RefOrganizationTypeId",
                table: "Program",
                column: "RefOrganizationTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Program_RefProgramTypeId",
                table: "Program",
                column: "RefProgramTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ProgramAssessment_ProgramId",
                table: "ProgramAssessment",
                column: "ProgramId");

            migrationBuilder.CreateIndex(
                name: "IX_RefSchoolCluster_RefLocationId",
                table: "RefEducationCenterCluster",
                column: "RefLocationId");

            migrationBuilder.CreateIndex(
                name: "IX_RefLocation_ParentLocationId",
                table: "RefLocation",
                column: "ParentLocationId");

            migrationBuilder.CreateIndex(
                name: "IX_RefLocation_RefLocationTypeId",
                table: "RefLocation",
                column: "RefLocationTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "EducationCenterClassroom");

            migrationBuilder.DropTable(
                name: "EducationCenterEnrollment");

            migrationBuilder.DropTable(
                name: "GroupEvaluation");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "EducationCenterPeriod");

            migrationBuilder.DropTable(
                name: "EducationCenter");

            migrationBuilder.DropTable(
                name: "GroupEnrollment");

            migrationBuilder.DropTable(
                name: "ProgramAssessment");

            migrationBuilder.DropTable(
                name: "RefEducationCenterAdministrationType");

            migrationBuilder.DropTable(
                name: "RefEducationCenterCluster");

            migrationBuilder.DropTable(
                name: "RefEducationCenterLanguage");

            migrationBuilder.DropTable(
                name: "RefEducationCenterLocation");

            migrationBuilder.DropTable(
                name: "RefEducationCenterStatus");

            migrationBuilder.DropTable(
                name: "RefEducationCenterType");

            migrationBuilder.DropTable(
                name: "Group");

            migrationBuilder.DropTable(
                name: "Participant");

            migrationBuilder.DropTable(
                name: "Program");

            migrationBuilder.DropTable(
                name: "RefGradeLevel");

            migrationBuilder.DropTable(
                name: "Organization");

            migrationBuilder.DropTable(
                name: "RefDisabilityType");

            migrationBuilder.DropTable(
                name: "RefParticipantCohort");

            migrationBuilder.DropTable(
                name: "RefParticipantType");

            migrationBuilder.DropTable(
                name: "RefSex");

            migrationBuilder.DropTable(
                name: "RefProgramType");

            migrationBuilder.DropTable(
                name: "RefLocation");

            migrationBuilder.DropTable(
                name: "RefOrganizationType");

            migrationBuilder.DropTable(
                name: "RefLocationType");
        }
    }
}
