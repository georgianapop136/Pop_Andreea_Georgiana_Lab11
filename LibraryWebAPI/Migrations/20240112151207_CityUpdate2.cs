using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibraryWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class CityUpdate2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CityID",
                table: "City",
                newName: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ID",
                table: "City",
                newName: "CityID");
        }
    }
}
