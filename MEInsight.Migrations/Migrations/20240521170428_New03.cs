using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MEInsight.Migrations.Migrations
{
    /// <inheritdoc />
    public partial class New03 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "JSONData",
                table: "Organizations",
                newName: "Data");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Data",
                table: "Organizations",
                newName: "JSONData");
        }
    }
}
