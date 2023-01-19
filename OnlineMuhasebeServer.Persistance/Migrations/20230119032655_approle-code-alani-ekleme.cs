using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineMuhasebeServer.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class approlecodealaniekleme : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "Roles",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Code",
                table: "Roles");
        }
    }
}
