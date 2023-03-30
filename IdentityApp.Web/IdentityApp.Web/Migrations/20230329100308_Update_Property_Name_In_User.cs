using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IdentityApp.Web.Migrations
{
    /// <inheritdoc />
    public partial class Update_Property_Name_In_User : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Birthday",
                table: "AspNetUsers",
                newName: "BirthDate");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BirthDate",
                table: "AspNetUsers",
                newName: "Birthday");
        }
    }
}
