using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UserManagment2.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddAdminUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO [dbo].[users] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [FirstName], [LastName], [ProfilePicture]) VALUES (N'6f25dff4-5f3a-41d5-968d-09067f24d826', N'Admin', N'ADMIN', N'Admin@testmail.com', N'ADMIN@TESTMAIL.COM', 0, N'AQAAAAIAAYagAAAAEH9UKWaX9pSpjFhZ82oATyIM4wYa1MGZHnJecv3nxofnTVDum3sNRR/duoG0KUoVuw==', N'6ULUX74GIHYHTD4LRHVZPRTHNND3D5PA', N'7c66c354-2f9d-4466-9596-03b44a5dff13', NULL, 0, 0, NULL, 1, 0, N'Ahmed', N'Muhammed', NULL)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELET FROM [dbo].[users] WHERE Id = '6f25dff4-5f3a-41d5-968d-09067f24d826' ");
        }
    }
}
