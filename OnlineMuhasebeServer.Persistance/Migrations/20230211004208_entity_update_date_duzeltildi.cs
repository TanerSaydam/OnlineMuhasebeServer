using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineMuhasebeServer.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class entityupdatedateduzeltildi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UpdateDate",
                table: "UserAndCompanyRelationships",
                newName: "UpdatedDate");

            migrationBuilder.RenameColumn(
                name: "UpdateDate",
                table: "MainRoles",
                newName: "UpdatedDate");

            migrationBuilder.RenameColumn(
                name: "UpdateDate",
                table: "MainRoleAndUserRelationships",
                newName: "UpdatedDate");

            migrationBuilder.RenameColumn(
                name: "UpdateDate",
                table: "MainRoleAndRoleRelationships",
                newName: "UpdatedDate");

            migrationBuilder.RenameColumn(
                name: "UpdateDate",
                table: "Companies",
                newName: "UpdatedDate");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UpdatedDate",
                table: "UserAndCompanyRelationships",
                newName: "UpdateDate");

            migrationBuilder.RenameColumn(
                name: "UpdatedDate",
                table: "MainRoles",
                newName: "UpdateDate");

            migrationBuilder.RenameColumn(
                name: "UpdatedDate",
                table: "MainRoleAndUserRelationships",
                newName: "UpdateDate");

            migrationBuilder.RenameColumn(
                name: "UpdatedDate",
                table: "MainRoleAndRoleRelationships",
                newName: "UpdateDate");

            migrationBuilder.RenameColumn(
                name: "UpdatedDate",
                table: "Companies",
                newName: "UpdateDate");
        }
    }
}
