using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MEInsight.Migrations.Migrations
{
    /// <inheritdoc />
    public partial class New04 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Organizations_OrganizationTypes_RefOrganizationTypeId",
                table: "Organizations");

            migrationBuilder.AlterColumn<int>(
                name: "RefOrganizationTypeId",
                table: "Organizations",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Organizations_OrganizationTypes_RefOrganizationTypeId",
                table: "Organizations",
                column: "RefOrganizationTypeId",
                principalTable: "OrganizationTypes",
                principalColumn: "RefOrganizationTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Organizations_OrganizationTypes_RefOrganizationTypeId",
                table: "Organizations");

            migrationBuilder.AlterColumn<int>(
                name: "RefOrganizationTypeId",
                table: "Organizations",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Organizations_OrganizationTypes_RefOrganizationTypeId",
                table: "Organizations",
                column: "RefOrganizationTypeId",
                principalTable: "OrganizationTypes",
                principalColumn: "RefOrganizationTypeId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
