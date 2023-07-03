using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using UserManagment2.Models;

namespace UserManagment2.Data
{
	public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
			: base(options)
		{
		}
		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);

			// Change table names
			builder.Entity<ApplicationUser>().ToTable("users");
			builder.Entity<IdentityRole>().ToTable("Roles");
			builder.Entity<IdentityUserRole<string>>().ToTable("UserRoles");
			builder.Entity<IdentityUserClaim<string>>().ToTable("UserClaim");
			builder.Entity<IdentityUserLogin<string>>().ToTable("UserLogins");
			builder.Entity<IdentityRoleClaim<string>>().ToTable("RoleClaims");
			builder.Entity<IdentityUserToken<string>>().ToTable("UserTokens");
		}
	}
}