using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UserManagment2.Data.Migrations
{
    /// <inheritdoc />
    public partial class AssingnAdminUserToAllRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO [UserRoles] (UserId,RoleId) SELECT '6f25dff4-5f3a-41d5-968d-09067f24d826',Id FROM [Roles]");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM [UserRoles] WHERE UserId = '6f25dff4-5f3a-41d5-968d-09067f24d826'");
        }
    }
}
