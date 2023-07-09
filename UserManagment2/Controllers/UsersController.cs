using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UserManagment2.Models;
using UserManagment2.ViewModels;

namespace UserManagment2.Controllers
{
	[Authorize(Roles = RolesName.AdminRole)]
	public class UsersController : Controller
	{
		private readonly UserManager<ApplicationUser> _userManager;
		private readonly RoleManager<IdentityRole> _roleManager;
		 
		public UsersController(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
		{
			_userManager = userManager;
			_roleManager = roleManager;
		}

		public async Task<IActionResult> Index()
		{
			var users = await _userManager.Users.Select(user => new UserViewModel
			{
				Id = user.Id,
				FirstName = user.FirstName,
				LastName = user.LastName,
				UserName = user.UserName,
				Email = user.Email,
				Roles = _userManager.GetRolesAsync(user).Result
			}).ToListAsync();

			return View(users);
		}
	}
}
